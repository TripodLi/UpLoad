using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MUC2012;

namespace UpLoad
{
    public partial class Form1 : Form
    {
        string SN = "";
        int start = 0;

        int[] CanRead = new int[2];
        Thread newThread;
        bool threadOK = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            start = Convert.ToInt32(textBox2.Text);
            CanRead[0] = Convert.ToInt32(start);

            if (threadOK == true)
            {             
                if (CanRead[0] > CanRead[1])
                {
                    clsLoad.status = "开始上传数据";
                    SN = "testSN-R-009";//此处给SN号赋值
                    pictureBox1.BackColor = Color.Lime;
                    textBox1.Text = SN;
                    threadOK = false;
                    newThread = new Thread(new ThreadStart(uploadData));
                    newThread.Start();

                }
                if (CanRead[0] < CanRead[1])
                {
                    clsLoad.status = "上传数据完成";
                    pictureBox1.BackColor = Color.Silver;
                    textBox1.Text = "";
                }
                CanRead[1] = CanRead[0];
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CanRead[0] = 0;
            CanRead[1] = 0;
        }

        private void uploadData( )
        {
            try
            {
                uploadAutoASS_Bolt();
                uploadAutoASS_Keypart();
                
                
                uploadMoZu_Bolt();
                uploadMoZu_Keypart();
				uploadLeakage();
                uploadPresure();
				uploadEOL();
                textBox2.Text ="0";
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog(DateTime.Now.ToString() + " 错误uploadData：" + ex.Message.ToString());
            }
            finally
            {
                threadOK = true;
                if (newThread.IsAlive)
                {
                    newThread.Abort();
                }
            }
        }

        private void uploadAutoASS_Bolt()
        {
            clsLoad.status = "正在上传表AutoASS_Bolt";
            string mode,strPackSN, strProcType, strStationName, strPName, strPData, strLastMark;
            Int32 intErrMsg;

            List<string> data = new List<string>();
            string sql = "select * from AutoASS_Bolt where SN='" + SN + "'";
            data = clsSql.GetStrings(sql, "sql");

            mode = data[2];
            strPackSN = data[3];
            strProcType = "AutoASS_Bolt";
            strStationName = data[4];            
            strPName = data[5];
            strPData = "T" + data[6] + ";A" + data[7] + ",P" + data[8] + ";C" + data[9] + ";R" + data[10] + ";DT" + data[1] + ";WID" + data[11] + ";TID" + data[12];
             strLastMark = "0";

            if (mode == "1")
            {
                //此处上传函数
                //bool strReturn = SavePackProcInfo(string strPackSN,string strProcType, string strStationName, string strPName,string strPData,string strLastMark,  out Int32intErrMsg);
            }
         }

        private void uploadAutoASS_Keypart()
        {
            clsLoad.status = "正在上传表AutoASS_Keypart";
            string mode, strPackSN, strProcType, strStationName, strPName, strPData, strLastMark;
            Int32 intErrMsg;

            List<string> data = new List<string>();
            string sql = "select * from AutoASS_Keypart where Product_SN='" + SN + "'";
            data = clsSql.GetStrings(sql, "sql");

            mode = data[2];
            strPackSN = data[5];
            strProcType = "AutoASS_Keypart";
            strStationName = data[3];
            strPName = data[7];
            strPData = "K" + data[6] + ";DT" + data[4] + ";WID" + data[8] + ";TID" + data[9]; 
            strLastMark = "0";

            if (mode == "1")
            {
                //此处上传函数
                //bool strReturn = SavePackProcInfo(string strPackSN,string strProcType, string strStationName, string strPName,string strPData,string strLastMark,  out Int32intErrMsg);
            }
        }

        private void uploadEOL()
        {
            clsLoad.status = "正在上传表EOL";
            string mode, strPackSN, strProcType, strStationName, strPName, strPData, strLastMark;
            Int32 intErrMsg;

            List<string> data = new List<string>();
            string sql = "select * from EOL where SN='" + SN + "'";
            data = clsSql.GetStrings(sql, "sql");

            mode = data[2];
            strPackSN = data[3];
            strProcType = "EOL";
            strStationName = data[4];
            strPName = data[5];
            strPData = "DT" + data[1] + ";WID" + data[6] + ";TID" + data[7];
            strLastMark = "0";

            if (mode == "1")
            {
                //此处上传函数
                //bool strReturn = SavePackProcInfo(string strPackSN,string strProcType, string strStationName, string strPName,string strPData,string strLastMark,  out Int32intErrMsg);
            }
        }

        private void uploadLeakage()
        {
            clsLoad.status = "正在上传表Leakage";
            string mode, strPackSN, strProcType, strStationName, strPName, strPData, strLastMark;
            Int32 intErrMsg;

            List<string> data = new List<string>();
            string sql = "select * from Leakage where SN='" + SN + "'";
            data = clsSql.GetStrings(sql, "sql");

            mode = data[2];
            strPackSN = data[3];
            strProcType = "Leakage";
            strStationName = data[4];
            strPName = data[5];
            strPData = "V1" + data[6] + ";V2" + data[7] + ";R" + data[8] + ";DT" + data[1] + ";WID" + data[9] + ";TID" + data[10];
            strLastMark = "0";

            if (mode == "1")
            {
                //此处上传函数
                //bool strReturn = SavePackProcInfo(string strPackSN,string strProcType, string strStationName, string strPName,string strPData,string strLastMark,  out Int32intErrMsg);
            }
        }

        private void uploadMoZu_Bolt()
        {
            clsLoad.status = "正在上传表MoZu_Bolt";
            string mode, strPackSN, strProcType, strStationName, strPName, strPData, strLastMark;
            Int32 intErrMsg;

            List<string> data = new List<string>();
            string sql = "select * from MoZu_Bolt where SN='" + SN + "'";
            data = clsSql.GetStrings(sql, "sql");

            mode = data[2];
            strPackSN = data[3];
            strProcType = "MoZu_Bolt";
            strStationName = data[4];
            strPName = data[5];
            strPData = "T" + data[6] + ";A" + data[7] + ",P" + data[8] + ";C" + data[9] + ";R" + data[10] + ";DT" + data[1] + ";WID" + data[11] + ";TID" + data[11];
            strLastMark = "0";

            if (mode == "1")
            {
                //此处上传函数
                //bool strReturn = SavePackProcInfo(string strPackSN,string strProcType, string strStationName, string strPName,string strPData,string strLastMark,  out Int32intErrMsg);
            }
        }

        private void uploadMoZu_Keypart()
        {
            clsLoad.status = "正在上传表MoZu_Keypart";
            string mode, strPackSN, strProcType, strStationName, strPName, strPData, strLastMark;
            Int32 intErrMsg;

            List<string> data = new List<string>();
            string sql = "select * from MoZu_Keypart where Product_SN='" + SN + "'";
            data = clsSql.GetStrings(sql, "sql");

            mode = data[2];
            strPackSN = data[5];
            strProcType = "AutoASS_Keypart";
            strStationName = data[3];
            strPName = data[7];
            strPData = "K" + data[6] + ";DT" + data[4] + ";WID" + data[8] + ";TID" + data[9];
            strLastMark = "0";

            if (mode == "1")
            {
                //此处上传函数
                //bool strReturn = SavePackProcInfo(string strPackSN,string strProcType, string strStationName, string strPName,string strPData,string strLastMark,  out Int32intErrMsg);
            }
        }

        private void uploadPresure()
        {
            clsLoad.status = "正在上传表Presure";
            string mode, strPackSN, strProcType, strStationName, strPName, strPData, strLastMark;
            Int32 intErrMsg;

            List<string> data = new List<string>();
            string sql = "select * from Presure where SN='" + SN + "'";
            data = clsSql.GetStrings(sql, "sql");

            mode = data[2];
            strPackSN = data[3];
            strProcType = "Presure";
            strStationName = data[4];
            strPName = data[5];
            strPData = "V1" + data[5] + ";V2" + data[6] + ";V3" + data[7] + ";V4" + data[8] + ";R" + data[9] + ";DT" + data[1] + ";WID" + data[10] + ";TID" + data[11];
            strLastMark = "1";

            if (mode == "1")
            {
                //此处上传函数
                //bool strReturn = SavePackProcInfo(string strPackSN,string strProcType, string strStationName, string strPName,string strPData,string strLastMark,  out Int32intErrMsg);
            }
        }
    }
}
