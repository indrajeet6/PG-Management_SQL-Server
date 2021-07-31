using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;
using System.Data;

namespace PG_Management.Classes
{
    public class LogClass
    {
        public static int Information = 0;
        public static int Low = 1;
        public static int Medium = 2;
        public static int Critical = 3;
        public static int Fatal = 4;
        public int Level { get; set; }
        public string LogMessage { get; set; }
        private string RunSQL(string strSQLCmd)
        {
            string strReturnValue = string.Empty;
            string strConnString = ConfigurationManager.ConnectionStrings["SQLServerDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);
            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = strSQLCmd;
            conn.Open();
            try
            {
                strReturnValue = sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                strReturnValue = e.Message.ToString();
                //Show_Alert("Error Adding Data (RUN SQL): \n" + e.Message.ToString());
            }
            return strReturnValue;
        }
        public string AddLog()
        {
            string strQuery = "EXEC [DBO].[AddLogMessage] '" + LogMessage.ToString() + "', " + Level.ToString();
            return RunSQL(strQuery);
        }

    }
}