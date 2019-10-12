using AppleDailyReportTool.entity;
using AppleDailyReportTool.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AppleDailyReportTool.dao
{
    public partial class ApplePoTbDao : BaseDAO<ApplePoTb>
    {

        public void AddApplePoTbItemDAO(OleDbConnection conn, ApplePoTb applePoTb)
        {

            string sqlStr = @"INSERT INTO ApplePoTb (HAWBNo,ApplePo,ShipTo,Ctn,Plt,Weight,Volume,PNContained,CustomerPoid) VALUES(@HAWBNo,@ApplePo,@ShipTo,@Ctn,@Plt,@Weight,@Volume,@PNContained,@CustomerPoid)";
            OleDbParameter[] paras = applePoTb.ToInsertByParamArray();

            ExecuteSQLNonquery(conn, sqlStr, paras);

        }
        public override ApplePoTb ToEntity(OleDbDataReader reader)
        {
            ApplePoTb applePoTb = new ApplePoTb();
            EntityUtils.FillEntity<ApplePoTb>(reader, applePoTb);
            return applePoTb;
        }
    }
}
