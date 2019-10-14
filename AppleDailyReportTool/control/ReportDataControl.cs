using AppleDailyReportTool.dao;
using AppleDailyReportTool.entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AppleDailyReportTool.control
{
    public partial class ReportDataControl
    {
        private ApplePoTbDao applePoTbDao = new ApplePoTbDao();
        private HawbTbDao hawbTbDao = new HawbTbDao();

        public List<HawbTb> FindAllHawbs()
        {
            List<HawbTb> hawbsList = null;
            try
            {
                
                OleDbConnection con = hawbTbDao.Begin();
                hawbsList = hawbTbDao.FindAllHawbs(con);
                hawbTbDao.Commit();
                return hawbsList;
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

        public List<ApplePoTb> FindAllApplePoTbs()
        {
            List<ApplePoTb> applePoTbList = null;
            try
            {

                OleDbConnection con = applePoTbDao.Begin();
                applePoTbList = applePoTbDao.FindAllApplePoTbs(con);
                applePoTbDao.Commit();
                return applePoTbList;
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
    }
}
