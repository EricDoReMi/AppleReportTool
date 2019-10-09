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
        public override ApplePoTb ToEntity(OleDbDataReader reader)
        {
            ApplePoTb applePoTb = new ApplePoTb();
            EntityUtils.FillEntity<ApplePoTb>(reader, applePoTb);
            return applePoTb;
        }
    }
}
