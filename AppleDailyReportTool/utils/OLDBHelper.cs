using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;

namespace AppleDailyReportTool.utils
{
    public partial class OLDBHelper
    {

        private static string driverNameStr;//Driver
        private static string persistSecurityStr;//PersistSecurity
        public static string dataSourceStr = "";
        private static string connStr;//connectStr
        private static ThreadLocal<OleDbConnection> tlConn = new ThreadLocal<OleDbConnection>();

        //初始化
        static OLDBHelper()
        {
            driverNameStr = ConfigurationManager.AppSettings["DriverNameStr"];

            persistSecurityStr = ConfigurationManager.AppSettings["PersistSecurityStr"];




        }

        public static OleDbConnection GetConnection()
        {

            connStr = driverNameStr + persistSecurityStr + dataSourceStr;
            OleDbConnection conn = tlConn.Value;//数据库连接

            if (conn == null)
            {

                conn = new OleDbConnection(connStr);

                tlConn.Value = conn;

            }

            return conn;
        }

        public static void CloseConnection()
        {
            OleDbConnection conn = tlConn.Value;//数据库连接
            if (conn != null && conn.State.Equals(ConnectionState.Open))
            {
                conn.Close();
                tlConn.Value = null;
            }
        }


        //释放数据库连接的资源
        private void DisposeDB()
        {
            OleDbConnection conn = tlConn.Value;//数据库连接
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
                tlConn.Value = null;
            }
        }

        ~OLDBHelper()
        {

            DisposeDB();
        }


    }
}
