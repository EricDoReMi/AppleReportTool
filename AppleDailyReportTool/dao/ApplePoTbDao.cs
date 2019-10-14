using AppleDailyReportTool.entity;
using AppleDailyReportTool.utils;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<ApplePoTb> FindAllApplePoTbs(OleDbConnection conn)
        {
            string sql = "Select * from ApplePoTb;";

            List<ApplePoTb> list = queryDataTableEntity(conn, sql);

            return list;

        }

        public override ApplePoTb ToEntity(OleDbDataReader reader)
        {
            ApplePoTb applePoTb = new ApplePoTb();
            EntityUtils.FillEntity<ApplePoTb>(reader, applePoTb);
            return applePoTb;
        }

        public override ApplePoTb ToEntity(DataRow dataRow)
        {
            ApplePoTb applePoTb = new ApplePoTb();
            
            applePoTb.ID= Convert.ToInt32(dataRow["ID"].ToString());
            applePoTb.HAWBNo= dataRow["HAWBNo"].ToString();
            applePoTb.ApplePo = dataRow["ApplePo"].ToString();
            applePoTb.ShipTo = dataRow["ShipTo"].ToString();
            applePoTb.Ctn = dataRow["Ctn"].ToString();
            applePoTb.Plt = dataRow["Plt"].ToString();
            applePoTb.Weight = dataRow["Weight"].ToString();
            applePoTb.Volume = dataRow["Volume"].ToString();
            applePoTb.PNContained = dataRow["PNContained"].ToString();
            applePoTb.CustomerPoid = dataRow["CustomerPoid"].ToString();

            return applePoTb;
        }
    }
}
