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
                   
                    strFiles = strFiles.Replace("<k>", "").Replace("<BR>", "\n");

                    string 

                    string tableMain=RegexHelper.GetFirstStrByRegex("<TABLE Border.+?</TABLE>", strFiles);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(tableMain);
                    XmlNodeList trs = doc.GetElementsByTagName("TR");
                    XmlNodeList tds = trs[1].ChildNodes;
                    foreach (XmlNode td in tds)
                    {
                        string strTd = td.InnerText;
                        
                    }

                    

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
                //AddRecordToDB(hawbTb);


            }







        }



  

        /// <summary>
        /// 向数据库添加单条Record的记录 
        /// </summary>
        /// <param name="record"></param>
        //private void AddRecordToDB(HawbTb record)
        //{
        //    try
        //    {
        //        OleDbConnection con = recordDao.Begin();
        //        recordDao.AddRecordItemDAO(con, record);
        //        recordDao.Commit();

        //    }
        //    catch (Exception)
        //    {
        //        recordDao.RollBack();
        //        throw;
        //    }
        //    finally
        //    {
        //        recordDao.Close();
        //    }
        //}

        //private void BathAddRecordsToDB(List<Record> records)
        //{
        //    try
        //    {
        //        OleDbConnection con = recordDao.Begin();
        //        foreach (Record record in records)
        //        {
        //            recordDao.AddRecordItemDAO(con, record);
        //        }

        //        recordDao.Commit();

        //    }
        //    catch (Exception)
        //    {
        //        recordDao.RollBack();
        //        throw;
        //    }
        //    finally
        //    {
        //        recordDao.Close();
        //    }
        //}



    }
}
