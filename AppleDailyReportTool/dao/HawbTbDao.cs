using AppleDailyReportTool.entity;
using AppleDailyReportTool.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AppleDailyReportTool.dao
{
    public partial class HawbTbDao : BaseDAO<HawbTb>
    {

        public void AddHawbTbItemDAO(OleDbConnection conn, HawbTb hawbTb)
        {

            string sqlStr = @"INSERT INTO HawbTb (HAWBNo,HAWBTitle,AppleId,Shipper,SapPlantCode,Org,Coc,Poe,TotalCtn,TotalPlt,TotalWeigth,TotalVolumn,MailIncomeTime,FilePath,MailSubject) VALUES(@HAWBNo,@HAWBTitle,@AppleId,@Shipper,@SapPlantCode,@Org,@Coc,@Poe,@TotalCtn,@TotalPlt,@TotalWeigth,@TotalVolumn,@MailIn@comeTime,@FilePath,@MailSubject)";
            OleDbParameter[] paras = hawbTb.ToInsertByParamArray();

            ExecuteSQLNonquery(conn, sqlStr, paras);

        }

        public override HawbTb ToEntity(OleDbDataReader reader)
        {
            HawbTb hawbTb = new HawbTb();
            EntityUtils.FillEntity<HawbTb>(reader, hawbTb);
            return hawbTb;
        }
    }
}
