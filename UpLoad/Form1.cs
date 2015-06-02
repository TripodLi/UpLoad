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
using MySql;
using MyLog;
using System.Xml;

namespace UpLoad
{
    public partial class Form1 : Form
    {
        string sql, dataTime, table;
        DataTable tb;
        DbUtility dbSql = new DbUtility(clsSql.strSqlConn, DbProviderType.SqlServer);
        XmlDocument xml = new XmlDocument();
        XmlElement xe;
        System.Timers.Timer tm = new System.Timers.Timer();
        bool auto = false;


        // Table
        Job2SystemTestData Ass_Bolt = new Job2SystemTestData();
        Job2SystemTestData Ass_Keypart = new Job2SystemTestData();
        Job2SystemTestData MoZu_Bolt = new Job2SystemTestData();
        Job2SystemTestData MoZu_Keypart = new Job2SystemTestData();
        Job2SystemTestData Leakage = new Job2SystemTestData();
        Job2SystemTestData EOL = new Job2SystemTestData();
        Job2SystemTestData Presure = new Job2SystemTestData();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                xml.Load("DatabaseConfig.xml");
                xe = xml.DocumentElement;
                foreach (XmlNode node in xe.ChildNodes)
                {
                    cmbTable.Items.Add(node.Name);
                }
                cmbTable.SelectedIndex = 0;

                dateTimePicker1.Value = DateTime.Now.AddDays(-1);
                dateTimePicker2.Value = DateTime.Now;

                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);

                tm.Elapsed += new System.Timers.ElapsedEventHandler(timerScan);

                init();
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化错误：" + ex.Message);
                Log.ErrLog.Error("初始化错误：" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            this.cmbTable.Enabled = false;
            this.groupBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            init();
            labelMessage.Text = "开始同步...";
            backgroundWorker.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.backgroundWorker.CancelAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = false;
            groupBox1.Enabled = false;
            textBox1.Enabled = false;

            auto = true;
            tm.Interval = Convert.ToInt32(textBox1.Text);
            tm.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("上传过程中请勿切换模式！");
                return;
            }
            button3.Enabled = false;
            button4.Enabled = true;
            groupBox1.Enabled = true;
            textBox1.Enabled = true;

            auto = false;
            tm.Stop();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void frmDataUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                e.Cancel = true;
                MessageBox.Show("请勿在上传过程中关闭窗口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            init();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            init();
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = cmbTable.Text;
            init();
        }

        private void init()
        {
            string sql;
            table = cmbTable.Text;
            dataTime = xe.SelectSingleNode(table).Attributes["datatime"].Value;
            if (!auto)
            {
                sql = "select id from " + cmbTable.Text + " where " + dataTime + " between '" + dateTimePicker1.Value +
                "' and '" + dateTimePicker2.Value + "' and transfer=1 order by id desc";
            }
            else
            {
                sql = "select id from " + cmbTable.Text + " where " + " transfer=1 order by id desc";
            }
            tb = dbSql.ExecuteDataTable(sql);
            toolStripStatusLabel1.Text = "需要上传的数据为" + tb.Rows.Count + "条";
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            SyncProductInfo(worker, e);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                button3_Click(null, null);
                Log.ErrLog.Error("同步错误:" + e.Error.Message);
                MessageBox.Show(e.Error.Message);
                this.Invoke(new EventHandler(delegate { labelMessage.Text = "同步错误。"; }));
            }
            else if (e.Cancelled)
            {
                this.Invoke(new EventHandler(delegate { labelMessage.Text = "同步中止。"; }));
            }
            else
            {
                this.Invoke(new EventHandler(delegate { labelMessage.Text = "同步完成。"; }));
            }
            if (!auto)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                cmbTable.Enabled = true;
                groupBox2.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate() { this.progressBar.Value = e.ProgressPercentage; });
        }

        private void timerScan(object source, System.Timers.ElapsedEventArgs e)
        {
            tm.Stop();
            for (int i = 0; i < cmbTable.Items.Count; i++)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    cmbTable.SelectedIndex = i;
                    init();
                    labelMessage.Text = "开始同步...";
                });
                backgroundWorker.RunWorkerAsync();
                while (backgroundWorker.IsBusy)
                { }
            }
            tm.Start();
        }

        private void SyncProductInfo(BackgroundWorker worker, DoWorkEventArgs e)
        {
            int syncNum = tb.Rows.Count;
            string sn, station,type,strType,parameters = "";
            string strPackSN, strProcType, strStationName, strPName, strPData, strLastMark;
            Int32 intErrMsg;
            XmlNode node;
            XmlNodeList nodeList;
            List<string> parameterList = new List<string>();
            List<string> typeRequire = new List<string>();

            node = xe.SelectSingleNode(table);
            sn = node.Attributes["sn"].Value;
            station = node.Attributes["station"].Value;
            type = node.Attributes["type"].Value;
            nodeList = xe.SelectNodes(table + "/item");
            foreach (XmlNode nd in nodeList)
            {
                parameters = parameters + nd.Attributes["value"].Value + ",";
                parameterList.Add(nd.Attributes["name"].Value);
                typeRequire.Add(nd.Attributes["typeRequire"].Value);
            }
            parameters = parameters.Substring(0, parameters.Length - 1);
            this.Invoke((MethodInvoker)delegate() { this.progressBar.Maximum = syncNum; });
            for (int i = 0; i < syncNum; ++i)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    sql = "select " + sn + "," + station+ "," + type  + "," + parameters + " from " + table + " where id='" + tb.Rows[i][0] + "'";
                    DataTable data = dbSql.ExecuteDataTable(sql);
                    if (data.Rows.Count != 1) throw new Exception("查询数据库出错");
                    strPackSN = data.Rows[0][0].ToString().Trim();
                    strProcType = table;
                    strLastMark = "0";                    
                    strStationName = data.Rows[0][1].ToString().Trim();
                    strType=data.Rows[0][2].ToString().Trim();
                    for (int j = 0; j < parameterList.Count; j++)
                    {
                        if(typeRequire[j]=="0") strPName = parameterList[j];
                        else  strPName = parameterList[j] +strType;
                        strPData = data.Rows[0][j + 3].ToString().Trim();


                        Ass_Bolt.OpenRemoting();
                        bool strReturn = Ass_Bolt.SavePackProcInfo(strPackSN, strProcType, strStationName,
                            strPName, strPData, strLastMark, out intErrMsg);
                        Ass_Bolt.CloseRemoting();
                        //if (intErrMsg != 2)
                        //{
                        //    if (MessageBox.Show("数据上传报错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        //    {
                        //        throw new Exception("数据上传报错");
                        //    }
                        //}
                    }
                    sql = "update " + table + " set transfer='2' where id='" + tb.Rows[i][0].ToString() + "'";
                    if (dbSql.ExecuteNonQuery(sql) < 1)
                    {
                        throw new Exception("更新transfer失败");
                    }
                    Log.InformationLog.Info("表：" + table + "    SN:" + strPackSN + "   上传成功");
                    this.Invoke(new EventHandler(delegate { this.toolStripStatusLabel1.Text = "需要上传的数据为 " + (syncNum - i - 1) + "条"; }));
                    worker.ReportProgress(i + 1);
                }
            }
        }


    }
}
