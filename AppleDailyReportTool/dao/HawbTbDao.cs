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
    public partial class HawbTbDao : BaseDAO<HawbTb>
    {

        public void AddHawbTbItemDAO(OleDbConnection conn, HawbTb hawbTb)
        {

            string sqlStr = @"INSERT INTO HawbTb (HAWBNo,HAWBTitle,AppleId,Shipper,SapPlantCode,Org,Coc,Poe,TotalCtn,TotalPlt,TotalWeigth,TotalVolumn,MailIncomeTime,FilePath,MailSubject) VALUES(@HAWBNo,@HAWBTitle,@AppleId,@Shipper,@SapPlantCode,@Org,@Coc,@Poe,@TotalCtn,@TotalPlt,@TotalWeigth,@TotalVolumn,@MailIncomeTime,@FilePath,@MailSubject)";
            OleDbParameter[] paras = hawbTb.ToInsertByParamArray();

            ExecuteSQLNonquery(conn, sqlStr, paras);

        }

        public List<HawbTb> FindAllHawbs(OleDbConnection conn)
        {
            string sql = "Select * from HawbTb;";

            List<HawbTb> list = queryDataTableEntity(conn, sql);

            return list;

        }

        public override HawbTb ToEntity(OleDbDataReader reader)
        {
            HawbTb hawbTb = new HawbTb();
            
            EntityUtils.FillEntity<HawbTb>(reader, hawbTb);
            return hawbTb;
        }

        public override HawbTb ToEntity(DataRow dataRow)
        {
            HawbTb hawbTb = new HawbTb();
           

            hawbTb.ID= Convert.ToInt32(dataRow["ID"].ToString());
            hawbTb.HAWBNo= dataRow["HAWBNo"].ToString();
            hawbTb.AppleId = dataRow["AppleId"].ToString();
            hawbTb.Shipper = dataRow["Shipper"].ToString();
            hawbTb.SapPlantCode = dataRow["SapPlantCode"].ToString();
            hawbTb.Org = dataRow["Org"].ToString();
            hawbTb.Coc = dataRow["Coc"].ToString();
            hawbTb.Poe = dataRow["Poe"].ToString();
            hawbTb.TotalCtn = dataRow["TotalCtn"].ToString();
            hawbTb.TotalPlt = dataRow["TotalPlt"].ToString();
            hawbTb.TotalWeigth = dataRow["TotalWeigth"].ToString();
            hawbTb.TotalVolumn = dataRow["TotalVolumn"].ToString();
            hawbTb.MailIncomeTime = Convert.ToDateTime(dataRow["MailIncomeTime"]);

            hawbTb.FilePath = dataRow["FilePath"].ToString();
            hawbTb.MailSubject = dataRow["MailSubject"].ToString();
            
            return hawbTb;
        }
    }
}
