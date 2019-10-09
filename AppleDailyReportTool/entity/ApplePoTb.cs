using AppleDailyReportTool.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AppleDailyReportTool.entity
{
    public partial class ApplePoTb
    {
        
        public ApplePoTb()
        {
            HAWBNo = "";
            ApplePo = "";
            ShipTo = "";
            Ctn = "";
            Plt = "";
            Weight = "";
            Volume = "";
            PNContained = "";
            CustomerPoid = "";
        }
        public long ID { get; set; }

        public string HAWBNo { get; set; }
        public string ApplePo { get; set; }

        public string ShipTo { get; set; }

        public string Ctn { get; set; }

        public string Plt { get; set; }

        public string Weight { get; set; }

        public string Volume { get; set; }

        public string PNContained { get; set; }

        public string CustomerPoid { get; set; }

        public OleDbParameter[] ToInsertByParamArray()
        {

            OleDbParameter[] param = {

                    new OleDbParameter("@HAWBNo", EntityUtils.SqlNull(HAWBNo)),
                    new OleDbParameter("@ApplePo", EntityUtils.SqlNull(ApplePo)),
                    new OleDbParameter("@ShipTo", EntityUtils.SqlNull(ShipTo)),
                    new OleDbParameter("@Ctn", EntityUtils.SqlNull(Ctn)),
                    new OleDbParameter("@Plt", EntityUtils.SqlNull(Plt)),
                    new OleDbParameter("@Weight", EntityUtils.SqlNull(Weight)),
                    new OleDbParameter("@Volume", EntityUtils.SqlNull(Volume)),
                    new OleDbParameter("@PNContained", EntityUtils.SqlNull(PNContained)),
                    new OleDbParameter("@CustomerPoid", EntityUtils.SqlNull(CustomerPoid))

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
                    new OleDbParameter("@ApplePo", EntityUtils.SqlNull(ApplePo)),
                    new OleDbParameter("@ShipTo", EntityUtils.SqlNull(ShipTo)),
                    new OleDbParameter("@Ctn", EntityUtils.SqlNull(Ctn)),
                    new OleDbParameter("@Plt", EntityUtils.SqlNull(Plt)),
                    new OleDbParameter("@Weight", EntityUtils.SqlNull(Weight)),
                    new OleDbParameter("@Volume", EntityUtils.SqlNull(Volume)),
                    new OleDbParameter("@PNContained", EntityUtils.SqlNull(PNContained)),
                    new OleDbParameter("@CustomerPoid", EntityUtils.SqlNull(CustomerPoid)),
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
