using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpLoad
{
    class clsOld
    {
    //    private void uploadData()
    //    {
    //        if (!uploadAutoASS_Bolt()) return;
    //        uploadAutoASS_Keypart();
    //        uploadMoZu_Bolt();
    //        uploadMoZu_Keypart();
    //        uploadLeakage();
    //        uploadPresure();
    //        uploadEOL();
    //        MessageBox.Show("上传成功", "提示");
    //        clsLoad.status = "上传完成";
    //    }

    //    private bool uploadAutoASS_Bolt()
    //    {
    //        string mode, strPackSN, strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark;
    //        Int32 intErrMsg;
    //        try
    //        {
    //            clsLoad.status = "正在上传表AutoASS_Bolt";
    //            List<List<string>> data = new List<List<string>>();
    //            string sql = "select * from AutoASS_Bolt where dt between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and transfer=1 order by id desc";
    //            data = clsSql.GetStrings(sql, "sql");
    //            for (int i = 0; i < data.Count; i++)
    //            {
    //                if (data[i].Count == 0)
    //                {
    //                    if (MessageBox.Show("数据库查询出错，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                //mode = data[0];
    //                strPackSN = data[i][4].Trim();
    //                strProcType = "AutoASS_Bolt";
    //                strStationName = data[i][5].Trim();
    //                strPName = data[i][6];
    //                strPData = "T," + data[i][7] + ";A," + data[i][8] + ";R," + data[i][11] + ";DT," + data[i][2] + ";TID," + data[i][13];
    //                strLastMark = "0";
    //                strPackSNs = strPackSN.Trim();

    //                Ass_Bolt.OpenRemoting();
    //                bool strReturn = Ass_Bolt.SavePackProcInfo(strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark, out intErrMsg);
    //                /* if (intErrMsg != 2)
    //                 {
    //                     if (MessageBox.Show("数据上传报错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                     {
    //                         return false;
    //                     }
    //                 }*/

    //                Ass_Bolt.CloseRemoting();

    //                sql = "update AutoASS_Bolt set transfer=2 where SN='" + strPackSN + "'";
    //                if (!clsSql.SqlExecuteNonQuery(sql, "sql"))
    //                {
    //                    if (MessageBox.Show("AutoASS_Bolt transfer置2错误，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                clsLoad.WriteLog("uploadAutoASS_Bolt上传完成，SN：" + strPackSN);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            clsLoad.WriteLog("上传AutoASS_Bolt错误：" + ex.Message.ToString());
    //            return false;
    //        }
    //    }

    //    private bool uploadAutoASS_Keypart()
    //    {
    //        string transfer, strPackSN, strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark;
    //        Int32 intErrMsg;
    //        try
    //        {
    //            clsLoad.status = "正在上传表AutoASS_Keypart";
    //            List<List<string>> data = new List<List<string>>();
    //            string sql = "select * from AutoASS_Keypart where INPUT_DATE between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and transfer=1 order by id desc";
    //            data = clsSql.GetStrings(sql, "sql");
    //            for (int i = 0; i < data.Count; i++)
    //            {
    //                if (data[i].Count == 0)
    //                {
    //                    if (MessageBox.Show("数据库查询出错，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                strPackSN = data[i][5];
    //                strProcType = "AutoASS_Keypart";
    //                strStationName = data[i][4];
    //                strPName = data[i][7];
    //                strPData = "K," + data[i][6] + ";DT," + data[i][2] + ";TID," + data[i][9] + ";CSC," + data[i][10];
    //                strLastMark = "0";
    //                strPackSNs = strPackSN.Trim();

    //                Ass_Keypart.OpenRemoting();
    //                bool strReturn = Ass_Keypart.SavePackProcInfo(strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark, out intErrMsg);
    //                /* if (intErrMsg != 2)
    //                 {
    //                     if (MessageBox.Show("数据上传报错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                     {
    //                         return false;
    //                     }
    //                 }*/
    //                Ass_Keypart.CloseRemoting();

    //                sql = "update AutoASS_Keypart set transfer=2 where Product_SN='" + strPackSN + "'";
    //                if (!clsSql.SqlExecuteNonQuery(sql, "sql"))
    //                {
    //                    if (MessageBox.Show("AutoASS_Keypart transfer置2错误，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                clsLoad.WriteLog("uploadAutoASS_Keypart上传完成，SN号为：" + strPackSN);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            clsLoad.WriteLog("上传AutoASS_Keypart错误：" + ex.Message.ToString());
    //            return false;
    //        }
    //    }

    //    private bool uploadMoZu_Bolt()
    //    {
    //        string mode, strPackSN, strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark;
    //        Int32 intErrMsg;

    //        try
    //        {
    //            clsLoad.status = "正在上传表MoZu_Bolt";
    //            List<List<string>> data = new List<List<string>>();
    //            string sql = "select * from MoZu_Bolt where dt between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and transfer=1 order by id desc";
    //            data = clsSql.GetStrings(sql, "sql");

    //            for (int i = 0; i < data.Count; i++)
    //            {
    //                if (data[i].Count == 0)
    //                {
    //                    if (MessageBox.Show("数据库查询出错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                strPackSN = data[i][4];
    //                strProcType = "MoZu_Bolt";
    //                strStationName = data[i][5];
    //                strPName = data[i][6];
    //                strPData = "T," + data[i][7] + ";A," + data[i][8] + ";R," + data[i][11] + ";DT," + data[i][2] + ";TID," + data[i][13];
    //                strLastMark = "0";
    //                int L = strPackSN.Length;
    //                strPackSNs = strPackSN.Trim();

    //                MoZu_Bolt.OpenRemoting();

    //                bool strReturn = MoZu_Bolt.SavePackProcInfo(strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark, out intErrMsg);
    //                /*if (intErrMsg != 2)
    //                {
    //                    if (MessageBox.Show("数据上传报错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }*/
    //                MoZu_Bolt.CloseRemoting();

    //                sql = "update MoZu_Bolt set transfer=2 where SN='" + strPackSN + "'";
    //                if (!clsSql.SqlExecuteNonQuery(sql, "sql"))
    //                {
    //                    if (MessageBox.Show("MoZu_Bolt transfer置2错误，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                clsLoad.WriteLog("MoZu_Bolt上传完成，SN号为：" + strPackSN);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("上传异常", "提示");
    //            clsLoad.WriteLog("上传MoZu_Bolt错误：" + ex.Message.ToString());
    //            return false;
    //        }
    //    }

    //    private bool uploadMoZu_Keypart()
    //    {
    //        string transfer, strPackSN, strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark;
    //        Int32 intErrMsg;
    //        try
    //        {
    //            clsLoad.status = "正在上传表MoZu_Keypart";
    //            List<List<string>> data = new List<List<string>>();
    //            string sql = "select * from MoZu_Keypart where INPUT_DATE between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and transfer=1 order by id desc";
    //            data = clsSql.GetStrings(sql, "sql");

    //            for (int i = 0; i < data.Count; i++)
    //            {
    //                if (data[i].Count == 0)
    //                {
    //                    if (MessageBox.Show("数据库查询出错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                transfer = data[i][1];
    //                strPackSN = data[i][5];
    //                strProcType = "MoZu_Keypart";
    //                strStationName = data[i][4];
    //                strPName = data[i][7];
    //                strPData = "K," + data[i][6] + ";DT," + data[i][2] + ";TID," + data[i][9];
    //                strLastMark = "0";
    //                strPackSNs = strPackSN.Trim();

    //                MoZu_Keypart.OpenRemoting();
    //                bool strReturn = MoZu_Keypart.SavePackProcInfo(strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark, out intErrMsg);
    //                //strReturn = MoZu_Keypart.SavePackProcInfo("115099999999", strProcType, "11", "321", "K,B12000413314112474955;DT,2015-05-01 13:22:05;TID", strLastMark, out intErrMsg);
    //                /* if (intErrMsg != 2)
    //                 {
    //                     if (MessageBox.Show("数据上传报错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                     {
    //                         return false;
    //                     }
    //                 }*/
    //                MoZu_Keypart.CloseRemoting();

    //                sql = "update MoZu_Keypart set transfer=2 where Product_SN='" + strPackSN + "'";
    //                if (!clsSql.SqlExecuteNonQuery(sql, "sql"))
    //                {
    //                    if (MessageBox.Show("MoZu_Keypart transfer置2错误，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                clsLoad.WriteLog("MoZu_Keypart上传完成，SN号为：" + strPackSN);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("上传异常", "提示");
    //            clsLoad.WriteLog("MoZu_Keypart上传错误：" + ex.Message.ToString());
    //            return false;
    //        }
    //    }

    //    private bool uploadLeakage()
    //    {
    //        string mode, strPackSN, strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark;
    //        Int32 intErrMsg;
    //        try
    //        {
    //            clsLoad.status = "正在上传表Leakage";
    //            List<List<string>> data = new List<List<string>>();
    //            string sql = "select * from Leakage where dt between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and transfer=1 order by id desc";
    //            data = clsSql.GetStrings(sql, "sql");

    //            for (int i = 0; i < data.Count; i++)
    //            {
    //                if (data[i].Count == 0)
    //                {
    //                    if (MessageBox.Show("数据库查询出错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                strPackSN = data[i][4];
    //                strProcType = "Leakage";
    //                strStationName = data[i][5];
    //                strPName = data[i][6];
    //                strPData = "V1," + data[i][7] + ";V2," + data[i][8] + ";R," + data[i][9] + ";DT," + data[i][2] + ";TID," + data[i][11];
    //                strLastMark = "0";
    //                strPackSNs = strPackSN.Trim();

    //                Leakage.OpenRemoting();
    //                bool strReturn = Leakage.SavePackProcInfo(strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark, out intErrMsg);
    //                /* if (intErrMsg != 2)
    //                 {
    //                     if (MessageBox.Show("数据上传报错，是否继续上传", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                     {
    //                         return false;
    //                     }
    //                 }*/
    //                Leakage.CloseRemoting();

    //                sql = "update Leakage set transfer=2 where SN='" + strPackSN + "'";
    //                if (!clsSql.SqlExecuteNonQuery(sql, "sql"))
    //                {
    //                    if (MessageBox.Show("Leakage transfer置2错误，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }

    //                clsLoad.WriteLog("上传Leakage完成，SN号为：" + strPackSN);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("上传异常", "提示");
    //            clsLoad.WriteLog("Leakage上传错误：" + ex.Message.ToString());
    //            return false;
    //        }
    //    }


    //    private bool uploadPresure()
    //    {
    //        string mode, strPackSN, strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark;
    //        Int32 intErrMsg;
    //        try
    //        {
    //            clsLoad.status = "正在上传表Presure";
    //            List<List<string>> data = new List<List<string>>();
    //            string sql = "select * from Presure where dt between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and transfer=1 order by id desc";
    //            data = clsSql.GetStrings(sql, "sql");

    //            for (int i = 0; i < data.Count; i++)
    //            {
    //                if (data[i].Count == 0)
    //                {
    //                    if (MessageBox.Show("数据库查询出错，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }
    //                strPackSN = data[i][4];
    //                strProcType = "Presure";
    //                strStationName = data[i][5];
    //                strPName = "Presure";
    //                strPData = "V1," + data[i][6] + ";V2," + data[i][7] + ";V3," + data[i][8] + ";V4," + data[i][9] + ";R," + data[i][10] + ";DT," + data[i][2] + ";TID," + data[i][12];
    //                strLastMark = "0";
    //                strPackSNs = strPackSN.Trim();

    //                Presure.OpenRemoting();
    //                bool strReturn = Presure.SavePackProcInfo(strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark, out intErrMsg);
    //                /* if (intErrMsg != 2)
    //                 {
    //                     if (MessageBox.Show("数据上传报错，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                     {
    //                         return false;
    //                     }
    //                 }*/
    //                Presure.CloseRemoting();

    //                sql = "update Presure set transfer=2 where SN='" + strPackSN + "'";
    //                if (!clsSql.SqlExecuteNonQuery(sql, "sql"))
    //                {
    //                    if (MessageBox.Show("Presure transfer置2错误，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }

    //                clsLoad.WriteLog("Presure上传完成，SN号为：" + strPackSN);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("上传异常", "提示");
    //            clsLoad.WriteLog("Presure上传错误：" + ex.Message.ToString());
    //            return false;
    //        }
    //    }

    //    private bool uploadEOL()
    //    {
    //        string transfer, strPackSN, strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark;
    //        Int32 intErrMsg;
    //        try
    //        {
    //            clsLoad.status = "正在上传表EOL";
    //            List<List<string>> data = new List<List<string>>();
    //            string sql = "select * from EOL where dt between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and transfer=1 order by id desc";
    //            data = clsSql.GetStrings(sql, "sql");

    //            for (int i = 0; i < data.Count; i++)
    //            {
    //                if (data[i].Count == 0)
    //                {
    //                    if (MessageBox.Show("数据库查询出错，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }

    //                string[] items = data[i][8].Split(',');

    //                transfer = data[i][1];
    //                strPackSN = data[i][4];
    //                strProcType = "EOL";
    //                strStationName = data[i][5];
    //                strPName = "EOL";
    //                //strPData = "DT" + data[1] + ";WID" + data[8] + ";TID" + data[9];
    //                strLastMark = "1";
    //                strPackSNs = strPackSN.Trim();


    //                for (int j = 0; j < items.Length; j++)
    //                {
    //                    EOL.OpenRemoting();
    //                    strPData = "DT" + data[i][2] + ";TID" + data[i][10] + ";" + items[j];
    //                    if ((i + 1) == data.Count && (j + 1) == items.Length)
    //                    {
    //                        strLastMark = "1";
    //                    }
    //                    else
    //                    {
    //                        strLastMark = "0";
    //                    }
    //                    bool strReturn = EOL.SavePackProcInfo(strPackSNs, strProcType, strStationName, strPName, strPData, strLastMark, out intErrMsg);
    //                    /*  if (intErrMsg != 2)
    //                      {
    //                          if (MessageBox.Show("数据上传报错，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                          {
    //                              return false;
    //                          }
    //                      }*/
    //                    EOL.CloseRemoting();
    //                }


    //                sql = "update EOL set transfer=2 where SN='" + strPackSN + "'";
    //                if (!clsSql.SqlExecuteNonQuery(sql, "sql"))
    //                {
    //                    if (MessageBox.Show("EOLtransfer置2错误，是否继续", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
    //                    {
    //                        return false;
    //                    }
    //                }

    //                clsLoad.WriteLog("EOL上传完成，SN号为：" + strPackSN);
    //            }
    //            return true;
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("上传异常", "提示");
    //            clsLoad.WriteLog("EOL上传错误：" + ex.Message.ToString());
    //            return false;
    //        }
    //    }
    }
}
