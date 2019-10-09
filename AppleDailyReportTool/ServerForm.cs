using AppleDailyReportTool.thread;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppleDailyReportTool
{
    public partial class ServerForm : Form
    {
        ThreadMain tdMain;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnServerStart_Click(object sender, EventArgs e)
        {

            StartMailServerTask();

        }

        private void btnServerStop_Click(object sender, EventArgs e)
        {
            StopMailServerTask();

        }

        /// <summary>
        /// Start按钮按下后，开启程序任务
        /// </summary>
        private void StartMailServerTask()
        {
            if (tdMain == null && !ThreadMain.isStart && !ThreadMain.stop)
            {

                tdMain = new ThreadMain();
                tdMain.StartMainThread();

                this.TxtServerStatus.Text = "Run";

            }
        }

        /// <summary>
        /// Stop按钮按下后，结束程序任务
        /// </summary>
        private void StopMailServerTask()
        {
            if (tdMain != null)
            {
                tdMain.StopMainThread();

                this.TxtServerStatus.Text = "Stop";

                tdMain = null;
            }
        }

        //定时器，用于自动启动或自动关闭任务
        private void AutoStartTimer_Tick(object sender, EventArgs e)
        {
            string startTimeStr = this.dateTimePickerStartTime.Value.ToShortTimeString();
            string stopTimeStr = this.dateTimePickerStopTime.Value.ToShortTimeString();

            string nowTimeStr = DateTime.Now.ToString("t");

            if (nowTimeStr.Equals(startTimeStr))
            {
                StartMailServerTask();
            }

            if (nowTimeStr.Equals(stopTimeStr))
            {
                StopMailServerTask();
            }
        }

    }
}
