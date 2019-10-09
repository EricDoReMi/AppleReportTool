using AppleDailyReportTool.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AppleDailyReportTool.entity
{
    public partial class HawbTb
    {

        public HawbTb()
        {
                //数据库要求必须提供的默认值
                HAWBNo = "";
                HAWBTitle = "";
                AppleId = "";
                Shipper = "";
                SapPlantCode = "";
                Org = "";
                Coc = "";
                Poe = "";
                TotalCtn = "";
                TotalPlt = "";
                TotalWeigth = "";
                TotalVolumn = "";

        }
        

        public long ID { get; set; }

        public string HAWBNo { get; set; }
        public string HAWBTitle { get; set; }
        public string AppleId { get; set; }
        public string Shipper { get; set; }
        public string SapPlantCode { get; set; }
        public string Org { get; set; }
        public string Coc { get; set; }
        public string Poe { get; set; }
        public string TotalCtn { get; set; }
        public string TotalPlt { get; set; }
        public string TotalWeigth { get; set; }
        public string TotalVolumn { get; set; }
        public DateTime? MailIncomeTime { get; set; }
        public string FilePath { get; set; }
        public string MailSubject { get; set; }

        public OleDbParameter[] ToInsertByParamArray()
        {

            OleDbParameter[] param = {
                    
                    new OleDbParameter("@HAWBNo", EntityUtils.SqlNull(HAWBNo)),
                    new OleDbParameter("@HAWBTitle", EntityUtils.SqlNull(HAWBTitle)),
                    new OleDbParameter("@AppleId", EntityUtils.SqlNull(AppleId)),
                    new OleDbParameter("@Shipper", EntityUtils.SqlNull(Shipper)),
                    new OleDbParameter("@SapPlantCode", EntityUtils.SqlNull(SapPlantCode)),
                    new OleDbParameter("@Org", EntityUtils.SqlNull(Org)),
                    new OleDbParameter("@Coc", EntityUtils.SqlNull(Coc)),
                    new OleDbParameter("@Poe", EntityUtils.SqlNull(Poe)),
                    new OleDbParameter("@TotalCtn", EntityUtils.SqlNull(TotalCtn)),
                    new OleDbParameter("@TotalPlt", EntityUtils.SqlNull(TotalPlt)),
                    new OleDbParameter("@TotalWeigth", EntityUtils.SqlNull(TotalWeigth)),
                    new OleDbParameter("@TotalVolumn", EntityUtils.SqlNull(TotalVolumn)),
                    new OleDbParameter("@MailIncomeTime", EntityUtils.SqlNull(MailIncomeTime)),
                    new OleDbParameter("@FilePath", EntityUtils.SqlNull(FilePath)),
                    new OleDbParameter("@MailSubject", EntityUtils.SqlNull(MailSubject))
                   
            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }



            return param;

        }

        public OleDbParameter[] ToUpdateByParamArray()
        {
            OleDbParameter[] param = {

                new OleDbParameter("@HAWBNo", EntityUtils.SqlNull(HAWBNo)),
                    new OleDbParameter("@HAWBTitle", EntityUtils.SqlNull(HAWBTitle)),
                    new OleDbParameter("@AppleId", EntityUtils.SqlNull(AppleId)),
                    new OleDbParameter("@Shipper", EntityUtils.SqlNull(Shipper)),
                    new OleDbParameter("@SapPlantCode", EntityUtils.SqlNull(SapPlantCode)),
                    new OleDbParameter("@Org", EntityUtils.SqlNull(Org)),
                    new OleDbParameter("@Coc", EntityUtils.SqlNull(Coc)),
                    new OleDbParameter("@Poe", EntityUtils.SqlNull(Poe)),
                    new OleDbParameter("@TotalCtn", EntityUtils.SqlNull(TotalCtn)),
                    new OleDbParameter("@TotalPlt", EntityUtils.SqlNull(TotalPlt)),
                    new OleDbParameter("@TotalWeigth", EntityUtils.SqlNull(TotalWeigth)),
                    new OleDbParameter("@TotalVolumn", EntityUtils.SqlNull(TotalVolumn)),
                    new OleDbParameter("@MailIncomeTime", EntityUtils.SqlNull(MailIncomeTime)),
                    new OleDbParameter("@FilePath", EntityUtils.SqlNull(FilePath)),
                    new OleDbParameter("@MailSubject", EntityUtils.SqlNull(MailSubject)),
                    new OleDbParameter("@ID",ID)
            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }



            return param;

        }

        public override string ToString()
        {
            return "";
        }

    }
}
