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


namespace AppleDailyReportTool.control
{
    public partial class MailControl
    {
        private EmpDAO empDao = new EmpDAO();
        private RecordDAO recordDao = new RecordDAO();

        private static long mailNum = 0;//用于标记邮件个数,存储邮件时作为唯一标识
        /// <summary>
        /// 将邮件内容存放到数据库中
        /// </summary>
        public void TransferMail()
        {




            foreach (Outlook.MailItem myItem in MailHelper.myFolderInbox.Items)
            {

                string mailAddress = myItem.SenderEmailAddress.Trim();
                string saveMailItemPath; //将邮件存到公共盘的路径  

                AddMailToDB(myItem, out saveMailItemPath);//将接收到的邮件信息添加到数据库
                SaveMailItemToDisk(myItem, saveMailItemPath);//将邮件保存到公共盘
                myItem.Move(MailHelper.mySourceFolder);//将邮件移动到了Source文件夹
                mailNum++;

                preAsignRequest();

            }


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
        /// 将邮件信息存储到数据库中
        /// </summary>
        /// <param name="myItem">邮件Item</param>
        /// <param name="saveMailNamePath">传出参数，传出要存储的路径</param>
        private void AddMailToDB(Outlook.MailItem myItem, out string saveMailNamePath)
        {

            Record record = new Record();

            if (myItem.Subject != null)
            {
                record.M_subject = myItem.Subject.Trim();//邮件主题
            }

            if (myItem.Importance != null)
            {
                record.M_importance = ((int)myItem.Importance).ToString();
            }

            record.M_sender = myItem.SenderName.Trim();

            record.M_mailincometime = Convert.ToDateTime(myItem.ReceivedTime.ToString("G"));
            record.JOBID = record.M_subject + "-" + DateTime.Now.ToString();
            record.T1 = Convert.ToDateTime(DateTime.Now.ToString("G"));




            string mailBody = myItem.Body.Trim();


            record.M_statu = "0";
            int? preAsignEmpId = 0;



            string subjectStrGet = RegexHelper.ReplaceStrByRegex(@"RE:|FW:|回复：", record.M_subject, "");

            string stationDepartment = RegexHelper.GetFirstStrByRegex(@"[A-Za-z]{3}\s+[A-Za-z]{3}", subjectStrGet);

            string stationStr = "";
            string departmentStr = "";

            record.M_statue = "0";
            record.M_asign = 0;

            if (stationDepartment.Length > 6)
            {
                stationStr = stationDepartment.Substring(0, 3).Trim();
                departmentStr = stationDepartment.Substring(stationDepartment.Length - 3, 3).Trim();
            }


            record.M_requestID = stationStr;
            record.M_actiontype = departmentStr;


            string saveMailName = new Guid().ToString() + myItem.ReceivedTime.ToString("yyyyMMddHHmmss") + mailNum.ToString();//邮件保存在公共盘上的名字

            saveMailNamePath = MailHelper.MailFolder + saveMailName + ".msg";
            record.M_filePath = saveMailNamePath;

            record = preAsignRequestToReceivedRecord(record);

            //将邮件记录添加到DB中
            AddRecordToDB(record);




        }


        /// <summary>
        /// 从subjectStr中匹配出StationCode
        /// </summary>
        /// <param name="subjectStr"></param>
        /// <returns></returns>
        private string FindStationCode(string subjectStr)
        {
            List<Emp> emps = FindAllEmpsForAllocate();
            foreach (Emp emp in emps)
            {

                if (emp.M_station.Length > 0 && subjectStr.ToUpper().Contains(emp.M_station.ToUpper()))
                {
                    return emp.M_station;
                }

            }
            return "";
        }

        /// <summary>
        /// 给record预分配case
        /// </summary>
        /// <param name="record">要进行预分配的record</param>
        /// <returns>record</returns>
        private Record preAsignRequestToReceivedRecord(Record record)
        {


            //找出全部员工
            List<Emp> allocateEmps = FindAllEmpsForAllocate();

            //找出不可以用于分配的员工
            HashSet<int?> couldNotAllocateIds = FindCouldNotAllocateEmps();

            //员工表和要被分配的records的数量
            int allocateEmpsCount = allocateEmps.Count;


            int nextRequestEmpId = Emp.nextRequestEmpId;
            int nextPoint = nextRequestEmpId - 1;//用于循环中从nextRequestEmpId指向下一个的指针

            //分配case
            for (int i = 0; i < allocateEmpsCount; i++)
            {

                //如果员工登录，并没有case在做,就分配case给该名员工
                if (allocateEmps[nextPoint].M_login == "1" && allocateEmps[nextPoint].M_statue == "1" && allocateEmps[nextPoint].M_isAutoAsign == 1 && (!couldNotAllocateIds.Contains(allocateEmps[nextPoint].M_id)))
                {

                    record.M_asign = allocateEmps[nextPoint].M_id;

                    record.M_statu = "4";
                    nextRequestEmpId = allocateEmps[nextPoint].M_id + 1;


                    if (nextRequestEmpId > allocateEmpsCount)
                    {
                        nextRequestEmpId = 1;
                    }

                    break;

                }

                nextPoint++;
                if (nextPoint > allocateEmpsCount - 1)
                {
                    nextPoint = 0;
                }

            }


            Emp.nextRequestEmpId = nextRequestEmpId;


            return record;
        }

        /// <summary>
        /// 将未asign的case分配给可以接收case的员工
        /// </summary>
        private void preAsignRequest()
        {
            //找出可以用于分配的员工
            List<Emp> allocateEmps = FindAllEmpsForAllocate();
            //找出可以用于分配的case
            List<Record> allocateRecords = FindRecordsToAllocate();

            //找出不可以用于分配的员工
            HashSet<int?> couldNotAllocateIds = FindCouldNotAllocateEmps();

            //员工表和要被分配的records的数量
            int allocateEmpsCount = allocateEmps.Count;
            int allocateRecordsCount = allocateRecords.Count;

            int nextRequestEmpId = Emp.nextRequestEmpId;
            int nextPoint = nextRequestEmpId - 1;//用于循环中从nextRequestEmpId指向下一个的指针

            //分配case
            for (int i = 0; i < allocateEmpsCount; i++)
            {

                //如果员工登录，并没有case在做,就分配case给该名员工
                if (allocateEmps[nextPoint].M_login == "1" && allocateEmps[nextPoint].M_statue == "1" && allocateEmps[nextPoint].M_isAutoAsign == 1 && (!couldNotAllocateIds.Contains(allocateEmps[nextPoint].M_id)))
                {

                    if (i < allocateRecordsCount)
                    {


                        allocateRecords[i].M_asign = allocateEmps[nextPoint].M_id;

                        allocateRecords[i].M_statu = "4";
                        nextRequestEmpId = allocateEmps[nextPoint].M_id + 1;
                        if (nextRequestEmpId > allocateEmpsCount)
                        {
                            nextRequestEmpId = 1;
                        }

                    }

                }

                nextPoint++;
                if (nextPoint > allocateEmpsCount - 1)
                {
                    nextPoint = 0;
                }

            }


            Emp.nextRequestEmpId = nextRequestEmpId;
            BathUpdateRecordsToDB(allocateRecords);



        }

        private List<Emp> FindAllEmpsForAllocate()
        {
            List<Emp> emps = null;
            try
            {
                OleDbConnection con = empDao.Begin();
                emps = empDao.FindAllEmpDAO(con);
                empDao.Commit();
                return emps;
            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally
            {
                empDao.Close();
            }

        }

        //查找不能够被分配case的项目
        private HashSet<int?> FindCouldNotAllocateEmps()
        {
            HashSet<int?> empsIdsHashSet = new HashSet<int?>();
            List<Record> empCouldNotAllocateList = null;
            try
            {
                OleDbConnection con = recordDao.Begin();
                empCouldNotAllocateList = recordDao.FindCouldNotAllocateDAO(con);
                recordDao.Commit();
                foreach (Record record in empCouldNotAllocateList)
                {
                    empsIdsHashSet.Add(record.M_asign);
                }


                return empsIdsHashSet;
            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally
            {
                empDao.Close();
            }

        }

        private List<Record> FindRecordsToAllocate()
        {
            List<Record> records = null;
            try
            {
                OleDbConnection con = recordDao.Begin();
                records = recordDao.FindRecordsToAllocateDAO(con);
                recordDao.Commit();
                return records;
            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }

        }






        /// <summary>
        ///按subjectStr寻找最近一次complete或incomplete的case，并且做这一票的Emp要在职，在线
        /// </summary>
        /// <param name="subjectStr"></param>
        /// <returns></returns>
        private int? FindRecordByRequest(string subjectStr)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                int? asignId = recordDao.FindRecordByRequestIDDAO(con, subjectStr);
                recordDao.Commit();
                return asignId;

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }

        }

        private void UpdateRecordToDB(Record record)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                recordDao.UpdateRecordItemDAO(con, record);
                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }



        private void BathUpdateRecordsToDB(List<Record> records)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                foreach (Record record in records)
                {
                    recordDao.UpdateRecordItemDAO(con, record);
                }

                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }

        private void BathUpdateEmpsToDB(List<Emp> emps)
        {
            try
            {
                OleDbConnection con = empDao.Begin();
                foreach (Emp emp in emps)
                {
                    empDao.UpdateEmpItemDAO(con, emp);
                }

                empDao.Commit();

            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally
            {
                empDao.Close();
            }
        }



        /// <summary>
        /// 向数据库添加单条Record的记录 
        /// </summary>
        /// <param name="record"></param>
        private void AddRecordToDB(Record record)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                recordDao.AddRecordItemDAO(con, record);
                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }

        private void BathAddRecordsToDB(List<Record> records)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                foreach (Record record in records)
                {
                    recordDao.AddRecordItemDAO(con, record);
                }

                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }



    }
}
