using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PG_Management.Classes;

namespace PG_Management
{
    public partial class _Default : Page
    {
        LogClass LogObject = new LogClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridView1.RowCommand += new GridViewCommandEventHandler(GridView1_RowCommand);
                this.BindGrid();
            }
        }
        protected void Show_Alert(string strMessage)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' " + strMessage + "')", true);
            LogObject.LogMessage = "Showing Alert with Message <" + strMessage + ">";
            LogObject.Level = LogClass.Information;
            LogObject.AddLog();
        }
        protected string RunSQL(string strSQLCmd)
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
                LogObject.LogMessage = "SQL Command Successful";
                LogObject.Level = LogClass.Information;
                LogObject.AddLog();
            }
            catch (Exception e)
            {
                strReturnValue = e.Message.ToString();
                LogObject.LogMessage = "SQL Command Failed";
                LogObject.Level = LogClass.Fatal;
                LogObject.AddLog();
            }
            return strReturnValue;
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs eventArgs)
        {
            if(eventArgs.CommandName== "Rent_Paid")
            {
                string strID = eventArgs.CommandArgument.ToString();
                //EXEC SetRentPaidStatus 41,1
                string strQuery = "EXEC SetRentPaidStatus " + strID + ", 1";
                string strReturnValue = RunSQL(strQuery);
                LogObject.LogMessage = "Attempting to set rent status to paid for Tenant ID " + strID;
                LogObject.Level = LogClass.Medium;
                LogObject.AddLog();
                if (strReturnValue== "TRUE")
                {
                    Show_Alert("Rent Status has been changed to paid for Tenant ID " + strID);
                    LogObject.LogMessage = "Rent status changed to paid for Tenant ID " + strID;
                    LogObject.Level = LogClass.Medium;
                    LogObject.AddLog();
                    GridView1.DataBind();
                }
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["SQLServerDB"].ConnectionString;
            string strQuery = @"SELECT [PG_Table].[Tenant_ID] AS [ID], [Tenant_Details].[Name],CONCAT(Right([PG_Table].[Pay_Date],2),'-',FORMAT(GETDATE(),'MMM')) AS [Due Date],
                                              [PG_Table].[Rent],[Tenant_Details].[Mobile_Phone] FROM [PG_Table], [Tenant_Details] WHERE [PG_Table].[Tenant_ID] = [Tenant_Details].[Tenant_ID] 
                                              AND [Current_Tenant]=1 AND [Paid_Status]=0";

            LogObject.LogMessage = "Running SQL Command to get Tenant ID, Name, Due Date and Mobile Phone Number for the Home Page Table";
            LogObject.Level = LogClass.Information;
            LogObject.AddLog();
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand(strQuery))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count>0)
                            {
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                LogObject.LogMessage = "Data for " + dt.Rows.Count.ToString()+" tenants extracted";
                                LogObject.Level = LogClass.Information;
                                LogObject.AddLog();
                            }
                            else
                            {
                                Error_Msg.Text = "No Tenants Due To Pay";
                                LogObject.LogMessage = "Tenant Info Extracted - No tenants due to pay";
                                LogObject.Level = LogClass.Information;
                                LogObject.AddLog();
                            }
                        }
                    }
                }
            }
        }
    }
}