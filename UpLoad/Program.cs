using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyLog;
using MyLog.Init;
using System.Threading;

namespace UpLoad
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Log.LogKeepPeriod = LogExpired.Threemonthes;
            LogEnviromentOperation.Instance.InitializeSetting();
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.ErrLog.Error(e.Exception.Message);
            MessageBox.Show(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.ErrLog.Error(e.ExceptionObject.ToString());
            MessageBox.Show(e.ExceptionObject.ToString());
        }
    }
}
