using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace UpLoad
{
    class clsLoad
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        
        public static string fileName = null;//log文件的文件名
        public static string status = "";



        public static string ReadIniStr(string section, string key)
        {
            string def = "";
            string filePath = System.IO.Directory.GetCurrentDirectory();
            filePath = filePath + "\\setting.ini";
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, filePath);
            return temp.ToString();
        }

        public static void WriteLog(string strErr)  //将错误写到文本文件
        {
            try
            {
                string logFileName = DateTime.Now.ToString("yyMMdd") + ".log";
                StreamWriter sw = File.AppendText(Application.StartupPath + "\\log\\" + logFileName);
                sw.WriteLine(DateTime.Now.ToString() + "     " + strErr);
                sw.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        public static void Delay(int delayTime)
        {
            DateTime now = DateTime.Now;
            double s;
            do
            {

                TimeSpan spand = DateTime.Now - now;
                s = spand.TotalMilliseconds;
                Application.DoEvents();
            }
            while (s < delayTime);

        }


    }
}
