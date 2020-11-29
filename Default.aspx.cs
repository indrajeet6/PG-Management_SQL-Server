using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PG_Management
{
    public partial class _Default : Page
    {
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
            }
            catch (Exception e)
            {
                strReturnValue = e.Message.ToString();
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
                if (strReturnValue== "True")
                {
                    Show_Alert("Rent Status has been changed to paid for Tenant ID " + strID);
                    GridView1.DataBind();
                }
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["SQLServerDB"].ConnectionString;
            string strQuery = @"SELECT [Tenant_ID] AS 'ID', [Tenant_Phone_Number] AS 'Phone Number', [Tenant_Name] AS 'Name', CONCAT(Right([Pay_Date],2),'-',
            FORMAT(GETDATE(),'MMM')) AS 'Due Date', [Rent] FROM PG_Management.dbo.PG_Table WHERE ABS((CAST(RIGHT(CONVERT(VARCHAR(10), 
            getdate(), 111),2) AS int)- CAST(RIGHT([Pay_Date],2) AS int))) <= 7 AND [Current_Tenant]=1 AND [Paid_Status]=0";

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
                            }
                            else
                            {
                                Error_Msg.Text = "No Tenants Due To Pay";
                            }
                        }
                    }
                }
            }
        }
    }
}