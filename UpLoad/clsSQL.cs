using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace UpLoad
{
    class clsSql
    {
        public static string strSqlConn
        {
            get
            {
                return clsLoad.ReadIniStr("DB", "conSqlStr");
            }
        }

        public static string strAccessConn
        {
            get
            {
                return clsLoad.ReadIniStr("DB", "conAccessStr");
            }
        }

        public static Boolean bolConnect()
        {
            try
            {
                SqlConnection thisConnection = new SqlConnection(strSqlConn);
                thisConnection.Open();
                thisConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog(DateTime.Now.ToString() + "bolConnect函数" + ex.ToString());
                return false;
            }
        }

        
        public static List<List<string >> GetStrings(string sqlCommand, string sqlType)
        {
            List<List<string>> columns = new List<List<string>>();
            try
            {
                switch (sqlType)
                {
                    //case "off":
                    //    OleDbConnection myConn1 = new OleDbConnection(strAccessConn);
                    //    OleDbCommand cmd1 = new OleDbCommand(sqlCommand, myConn1);
                    //    myConn1.Open();
                    //    OleDbDataReader reader1 = cmd1.ExecuteReader();
                    //    while (reader1.Read())
                    //    {
                    //        if (reader1[0].ToString() != "")
                    //        {
                    //            columns.Add(reader1[0].ToString());
                    //        }
                    //    }
                    //    myConn1.Close();
                    //    break;
                    case "sql":
                        SqlConnection myConn2 = new SqlConnection(strSqlConn);
                        SqlCommand cmd2 = new SqlCommand(sqlCommand, myConn2);
                        myConn2.Open();
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            List<string> co = new List<string>();
                            for (int i = 0; i < reader2.FieldCount; i++)
                            {                                
                                co.Add(reader2[i].ToString());
                            }
                            columns.Add(co);
                        }
                        myConn2.Close();
                        break;
                    default:
                        break;
                }
                return columns;
            }

            catch (Exception ex)
            {
                clsLoad.WriteLog(DateTime.Now.ToString() + "函数GetStrings出错：" + ex.Message.ToString());
                //MessageBox.Show("函数GetColumns出错：" + ex.Message.ToString());
                return columns;
            }
        }

        

        public static string GetString(string sqlCommand, string sqlType)
        {
            string ct = "";
            string conStr = "";

            try
            {
                switch (sqlType)
                {
                    case "off":
                        conStr = strAccessConn;
                        OleDbConnection connection1 = new OleDbConnection(conStr);
                        OleDbCommand command1 = new OleDbCommand(sqlCommand, connection1);
                        connection1.Open();
                        ct = command1.ExecuteScalar().ToString();
                        connection1.Close();
                        break;
                    case "sql":
                        conStr = strSqlConn;
                        SqlConnection connection2 = new SqlConnection(conStr);
                        SqlCommand command2 = new SqlCommand(sqlCommand, connection2);
                        connection2.Open();
                        ct = command2.ExecuteScalar().ToString();
                        connection2.Close();
                        break;
                    default:
                        break;
                }
                return ct;
            }

            catch (Exception ex)
            {
                clsLoad.WriteLog(DateTime.Now.ToString() + " 函数GetCount出错：" + ex.Message.ToString());
                //MessageBox.Show("函数GetCount出错：" + ex.Message.ToString());
                return ct;
            }
        }

        public static bool SqlExecuteNonQuery(string sqlCommand, string sqlType)
        {
            int i = 0;
            string conStr = "";
            try
            {
                switch (sqlType)
                {
                    case "off":
                        conStr = strAccessConn;
                        OleDbConnection myConn1 = new OleDbConnection(conStr);
                        OleDbCommand cmd1 = new OleDbCommand(sqlCommand, myConn1);
                        myConn1.Open();
                        i = cmd1.ExecuteNonQuery();
                        myConn1.Close();
                        break;
                    case "sql":
                        conStr = strSqlConn;
                        SqlConnection myConn2 = new SqlConnection(conStr);
                        SqlCommand cmd2 = new SqlCommand(sqlCommand, myConn2);
                        myConn2.Open();
                        i = cmd2.ExecuteNonQuery();
                        myConn2.Close();
                        break;
                    default:
                        break;
                }
                return i > 0 ? true : false;
            }

            catch (Exception ex)
            {
                clsLoad.WriteLog(DateTime.Now.ToString() + " 函数SqlExecuteNonQuery出错：" + ex.Message.ToString());
                return false;
            }
        }

        public static OleDbDataReader GetReader(string sqlCommand)
        {
            OleDbDataReader reader = null;
            try
            {
                OleDbConnection myConn1 = new OleDbConnection(strAccessConn);
                OleDbCommand cmd1 = new OleDbCommand(sqlCommand, myConn1);
                myConn1.Open();
                reader = cmd1.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog(DateTime.Now.ToString() + "函数GetReader出错：" + ex.Message.ToString());
                //MessageBox.Show("函数GetColumns出错：" + ex.Message.ToString());
                return reader;
            }

        }
    }
}
