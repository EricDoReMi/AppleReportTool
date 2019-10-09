using AppleDailyReportTool.control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppleDailyReportTool.thread
{
    //用于Server的邮件程序的线程任务控制
    public partial class ThreadMain
    {
        private Thread thread;


        public static bool stop = false;
        public static bool isStart = false;
        private MailControl mailControl = new MailControl();

        public void StartMainThread()
        {

            if ((!stop) && (!isStart))
            {
                thread = new Thread(AppRun);
                thread.IsBackground = true;
                thread.Start();
                isStart = true;

            }

        }


        public void StopMainThread()
        {

            stop = true;

        }

        private void AppRun()
        {

            while (true)
            {
                if (stop)
                {
                    stop = false;
                    isStart = false;
                    return;
                }

                //try {
                mailControl.TransferMail();
                //      } catch (Exception e) {

                //MessageBox.Show(e.ToString());


                // };

            }

        }
    }
}
