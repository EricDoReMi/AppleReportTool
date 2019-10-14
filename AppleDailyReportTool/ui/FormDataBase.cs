using AppleDailyReportTool.control;
using AppleDailyReportTool.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppleDailyReportTool.ui
{
    public partial class FormDataBase : Form
    {
        ReportDataControl reportDataControl = new ReportDataControl();

        public FormDataBase()
        {
            InitializeComponent();
        }

        private void FormDataBase_Load(object sender, EventArgs e)
        {
            LoadFormData();
        }

        private void LoadFormData()
        {
         

            List<HawbTb> hawbTbList = reportDataControl.FindAllHawbs();
            List<ApplePoTb> applePoTbList = reportDataControl.FindAllApplePoTbs();

            if (hawbTbList.Count > 0)
            {
                dgvHawbTb.DataSource = hawbTbList;
            }

            if (applePoTbList.Count > 0)
            {
                dgvApplePoTb.DataSource = applePoTbList;
            }


        }
    }
}
