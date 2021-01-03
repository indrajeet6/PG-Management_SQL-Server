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
    public partial class Modify_Tenant : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
            this.Form.Target = "_blank";
        }
        protected void BindGrid()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["RemoteDB"].ConnectionString;
            string strQuery = @"SELECT [Tenant_Details].[Tenant_ID] as 'Tenant ID', [Tenant_Details].[Name] AS 'Name',[Tenant_Details].[Mobile_Phone] AS 'Phone Number', 
                                            Right([PG_Table].[Pay_Date],2) AS 'Due Date', [Rent] FROM [Tenant_Details], [PG_Table] 
                                            WHERE [Tenant_Details].[Tenant_ID] = [PG_Table].[Tenant_ID] AND [Current_Tenant] = 1";
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
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            string strTenantID = GridView1.Rows[e.NewEditIndex].Cells[1].Text;
            string URL = "/Add_New_Tenant.aspx?strTenantId=" + strTenantID;
            Response.Redirect(URL,true);

        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int intTenantID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["RemoteDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE DBO.PG_Table SET [Current_Tenant] = 0 WHERE [Tenant_ID] = @TenantID"))
                {
                    cmd.Parameters.AddWithValue("@TenantID", intTenantID);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }
    }
}