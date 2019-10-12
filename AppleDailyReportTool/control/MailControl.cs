using Outlook = Microsoft.Office.Interop.Outlook;
using System.Configuration;
using AppleDailyReportTool.dao;
using AppleDailyReportTool.entity;
using AppleDailyReportTool.utils;
using System.Data.OleDb;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace AppleDailyReportTool.control
{
    public partial class MailControl
    {
        private ApplePoTbDao applePoTbDao = new ApplePoTbDao();
        private HawbTbDao hawbTbDao = new HawbTbDao();

        /// <summary>
        /// 将邮件内容存放到数据库中
        /// </summary>
        public void TransferMail()
        {

            foreach (Outlook.MailItem myItem in MailHelper.myFolderInbox.Items)
            {

                string mailAddress = myItem.SenderEmailAddress.Trim();

                string myGuid = Guid.NewGuid().ToString();
                string saveMailName = myGuid + myItem.ReceivedTime.ToString("yyyyMMddHHmmss");//邮件保存在公共盘上的名字
                string saveMailNamePath = MailHelper.MailFolder + saveMailName + ".msg";


                List<String> attachmentsList=SaveAttachments(myItem);


                AddMailToDB(myItem, attachmentsList, saveMailNamePath);//将接收到的邮件信息添加到数据库

                SaveMailItemToDisk(myItem, saveMailNamePath);//将邮件保存到公共盘
                myItem.Move(MailHelper.mySourceFolder);//将邮件移动到了Source文件夹
             



            }


        }

        /// <summary>
        /// 将邮件附件存到共享盘里面
        /// </summary>
        /// <param name="myItem">邮件的Item</param>
        /// <returns>邮件附件的路径列表</returns>
        private List<String> SaveAttachments(Outlook.MailItem myItem)
        {
            List<String> attachmentsList = new List<string>();

            for (int i = 1; i < myItem.Attachments.Count+1; i++)
            {
                
                string saveAttachPath = MailHelper.AttachFolder + myItem.Attachments[i].FileName;

                myItem.Attachments[i].SaveAsFile(saveAttachPath);

                attachmentsList.Add(saveAttachPath);
            }

            return attachmentsList;
        }



        /// <summary>
        /// 将邮件保存到公共盘
        /// </summary>
        /// <param name="myItem">要保存的邮件</param>
        /// <param name="mailSaveNameFilePath">保存邮件的完整路径</param>
        private void SaveMailItemToDisk(Outlook.MailItem myItem, string mailSaveNameFilePath)
        {

            myItem.SaveAs(mailSaveNameFilePath);

        }


        
        /// <summary>
        /// 将信息添加到数据库
        /// </summary>
        /// <param name="myItem"></param>
        /// <param name="attachmentsList"></param>
        private void AddMailToDB(Outlook.MailItem myItem, List<String> attachmentsList, string saveMailNamePath)
        {


            if (attachmentsList.Count > 0)
            {
                foreach (String attachFilePath in attachmentsList)
                {
                    HawbTb hawbTb = new HawbTb();

                    if (myItem.Subject != null)
                    {
                        hawbTb.MailSubject = myItem.Subject.Trim();//邮件主题
                    }


                    hawbTb.MailIncomeTime = Convert.ToDateTime(myItem.ReceivedTime.ToString("G"));


                    hawbTb.FilePath = saveMailNamePath;

                    string strFiles = File.ReadAllText(attachFilePath);
                   
                    strFiles = strFiles.Replace("<k>", "").Replace("<BR>", "\n").Replace("&nbsp;", " ");

                    hawbTb.HAWBNo = Path.GetFileNameWithoutExtension(attachFilePath);


                    hawbTb.HAWBTitle=RegexHelper.GetGroupStrByReg(strFiles, @"<B>(.*?)</B>",1);

                    hawbTb.AppleId = RegexHelper.GetGroupStrByReg(strFiles, @"APPLE ID :(.*?)</TD>", 1);

                    hawbTb.Shipper = RegexHelper.GetGroupStrByReg(strFiles, @"Shipper :(.*?)</TD>", 1);

                    hawbTb.SapPlantCode = RegexHelper.GetGroupStrByReg(strFiles, @"SAP Plant Code :(.*?)</TD>", 1);

                    hawbTb.Org = RegexHelper.GetGroupStrByReg(strFiles, @"ORG :(.*?)</TD>", 1);

                    hawbTb.Coc = RegexHelper.GetGroupStrByReg(strFiles, @"COC :(.*?)</TD>", 1);

                    hawbTb.Poe= RegexHelper.GetGroupStrByReg(strFiles, @"POE :(.*?)</TD>", 1);

                    hawbTb.TotalCtn = RegexHelper.GetGroupStrByReg(strFiles, @"Total CTN :(.*?)</TD>", 1);

                    hawbTb.TotalPlt = RegexHelper.GetGroupStrByReg(strFiles, @"Total PLT :(.*?)</TD>", 1);

                    hawbTb.TotalWeigth = RegexHelper.GetGroupStrByReg(strFiles, @"Total Weight (KG) :(.*?)</TD>", 1);

                    hawbTb.TotalVolumn = RegexHelper.GetGroupStrByReg(strFiles, @"Total Volume (CBM) :(.*?)</TD>", 1);

                    AddHawbTbToDB(hawbTb);

                    string tableMain =RegexHelper.GetFirstStrByRegex("<TABLE Border.+?</TABLE>", strFiles);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(tableMain);
                    XmlNodeList trs = doc.GetElementsByTagName("TR");

                    List<ApplePoTb> applePoTbLists = new List<ApplePoTb>();

                    for (int i = 1; i < trs.Count; i++)
                    {
                        ApplePoTb applePoTb = new ApplePoTb();
                        XmlNodeList tds = trs[i].ChildNodes;
                        applePoTb.ApplePo=tds[0].InnerText.Trim();
                        applePoTb.ShipTo = tds[1].InnerText.Trim();
                        applePoTb.Ctn = tds[2].InnerText.Trim();
                        applePoTb.Plt = tds[3].InnerText.Trim();
                        applePoTb.Weight = tds[4].InnerText.Trim();
                        applePoTb.Volume = tds[5].InnerText.Trim();
                        applePoTb.PNContained = tds[6].InnerText.Trim();
                        applePoTb.CustomerPoid = tds[7].InnerText.Trim();

                        applePoTbLists.Add(applePoTb);

                    }

                    BathAddApplePoTbToDB(applePoTbLists);




                }
            }
            else
            {

                HawbTb hawbTb = new HawbTb();

                if (myItem.Subject != null)
                {
                    hawbTb.MailSubject = myItem.Subject.Trim();//邮件主题
                }



                hawbTb.MailIncomeTime = Convert.ToDateTime(myItem.ReceivedTime.ToString("G"));


                hawbTb.FilePath = saveMailNamePath;

                //将邮件记录添加到DB中
                AddHawbTbToDB(hawbTb);


            }







        }



        private void AddApplePoTbToDB(ApplePoTb applePoTb)
        {
            try
            {
                OleDbConnection con = applePoTbDao.Begin();
                applePoTbDao.AddApplePoTbItemDAO(con, applePoTb);
                applePoTbDao.Commit();

            }
            catch (Exception)
            {
                applePoTbDao.RollBack();
                throw;
            }
            finally
            {
                applePoTbDao.Close();
            }
        }

        private void BathAddApplePoTbToDB(List<ApplePoTb> applePoTbs)
        {
            try
            {
                OleDbConnection con = applePoTbDao.Begin();
                foreach (ApplePoTb applePoTb in applePoTbs)
                {
                    applePoTbDao.AddApplePoTbItemDAO(con, applePoTb);
                }

                applePoTbDao.Commit();

            }
            catch (Exception)
            {
                applePoTbDao.RollBack();
                throw;
            }
            finally
            {
                applePoTbDao.Close();
            }
        }

        /// <summary>
        /// 向数据库添加单条HawbTb的记录 
        /// </summary>
        /// <param name = "hawbTb" ></ param >
        private void AddHawbTbToDB(HawbTb hawbTb)
        {
            try
            {
                OleDbConnection con = hawbTbDao.Begin();
                hawbTbDao.AddHawbTbItemDAO(con, hawbTb);
                hawbTbDao.Commit();

            }
            catch (Exception)
            {
                hawbTbDao.RollBack();
                throw;
            }
            finally
            {
                hawbTbDao.Close();
            }
        }

        private void BathAddHawbTbToDB(List<HawbTb> hawbTbs)
        {
            try
            {
                OleDbConnection con = hawbTbDao.Begin();
                foreach (HawbTb hawbTb in hawbTbs)
                {
                    hawbTbDao.AddHawbTbItemDAO(con, hawbTb);
                }

                hawbTbDao.Commit();

            }
            catch (Exception)
            {
                hawbTbDao.RollBack();
                throw;
            }
            finally
            {
                hawbTbDao.Close();
            }
        }



    }
}
