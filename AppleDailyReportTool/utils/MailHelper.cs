using Outlook = Microsoft.Office.Interop.Outlook;
using System.Configuration;

namespace AppleDailyReportTool.utils
{
    public partial class MailHelper
    {

        //公共邮箱地址
        private static string MailAddressName;
        //Inbox名称
        private static string InboxName;
        //邮件存储箱
        private static string SourceboxName;
        //不使用的邮件存储箱
        private static string OutboxName;
        //用于存储邮件的共享盘目录
        public static string MailFolder;
        //用于存储邮件附件的目录
        public static string AttachFolder;

        private static Outlook.Application myOutlookApp;
        private static Outlook.NameSpace myNameSpace;
        public static Outlook.Folders mailFolders;
        public static Outlook.MAPIFolder myFolderInbox;//Inbox
        public static Outlook.MAPIFolder mySourceFolder;//Source
        public static Outlook.MAPIFolder myOutFolder;//Out

        static MailHelper()
        {
            MailAddressName = ConfigurationManager.AppSettings["MailAddressName"];
            InboxName = ConfigurationManager.AppSettings["InboxName"];
            SourceboxName = ConfigurationManager.AppSettings["SourceboxName"];
            OutboxName = ConfigurationManager.AppSettings["OutboxName"];
            MailFolder = ConfigurationManager.AppSettings["MailFolder"];
            AttachFolder= ConfigurationManager.AppSettings["AttachFolder"];

            myOutlookApp = new Outlook.Application();
            myNameSpace = myOutlookApp.GetNamespace("MAPI");
            mailFolders = myNameSpace.Folders;

            myFolderInbox = mailFolders[MailAddressName].Folders[InboxName];

            mySourceFolder = myFolderInbox.Folders[SourceboxName];
            myOutFolder = myFolderInbox.Folders[OutboxName];
        }



        ~MailHelper()
        {

            myOutlookApp = null;
            myNameSpace = null;

            mailFolders = null;

            myFolderInbox = null;//inbox
            mySourceFolder = null;//source

            myOutFolder = null;//存储邮件的目录路径
        }





    }
}
