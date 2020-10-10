using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace PG_Management
{
    public partial class Add_New_Tenant : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Submit.Text = "Modify Tenant Details";
            Page.Title = "Modify Tenant Details";
            Submit.OnClientClick = "ModifyTenantDetails";
            string strTenantId;
            if (!String.IsNullOrEmpty(Request.QueryString["strTenantId"]))
            {
                // Query string value is there so now use it
                strTenantId = Request.QueryString["strTenantId"];
                ModifyTenantDetails(blnShowAsEdit: true, strTenantID: strTenantId);
            }
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
                //Show_Alert("Error Adding Data (RUN SQL): \n" + e.Message.ToString());
            }
            return strReturnValue;
        }
        protected void Show_Alert(string strMessage)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' " + strMessage + "')", true);
        }
        protected string Add_PG_Table_Details(bool blnModify = false, string strTenantID = null) 
        {
            //EXEC [PG_Management].[dbo].AddToPGTable '9873672742','Indrajeet Roy',1,8000,'2020-05-21',1,0,'2020-01-01',8000,'2020-02-21'
            string strValues = string.Empty;
            string strSQLCmd;
            strValues = @"'" + txtTenantMobile.Text.Trim().ToString() + "', '" + txtTenantName.Text.Trim().ToString() + "', " + "1, '" + txtTenantRent.Text.Trim().ToString() + "', "
                + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + "1, 0, '2020-01-01', "+ "'" + txtTenantRent.Text.Trim().ToString() + "', " + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            if (blnModify == false)
            {
                strTenantID = string.Empty;
                strSQLCmd = "EXEC [PG_Management].[dbo].AddToPGTable " + strValues;
                strTenantID = RunSQL(strSQLCmd);
            }
            else 
            {
                strSQLCmd = "EXEC [PG_Management].[dbo].AddToPGTable " + strValues + ", 1, '" + strTenantID +"'";
                strTenantID = RunSQL(strSQLCmd);
            }
            if (strTenantID=="1")
            {
                return true.ToString();
            }
            else
            {
                return false.ToString();
            }
        }
        protected bool Add_Father_Details(int intTenantID, bool blnModify = false)
        {
            //EXEC PG_Management.dbo.AddToFatherDetails 51,'Test Record','test Occupation','Gali No. 420','Gali No. 420','Gali No. 420','9873672742'
            string strValues = string.Empty;
            string strSQLCmd = string.Empty;
            string strErrorMsg = string.Empty;

            strValues = intTenantID.ToString() + ",'" + txtFatherName.Text.Trim().ToString() + "','" + txtFatherJob.Text.Trim().ToString() + "','" + txtFatherResidence.Text.Trim().ToString() + "','"
                + txtFatherOffice.Text.Trim().ToString() + "','"  + txtFatherPermAddress.Text.Trim().ToString() + "','"  + txtFatherMobile.Text.Trim().ToString()+"'" ;
            if (blnModify == false)
            {
                strSQLCmd = "EXEC PG_Management.dbo.AddToFatherDetails " + strValues;
            }
            else
            {
                strSQLCmd = "EXEC PG_Management.dbo.AddToFatherDetails " + strValues + ", 1";
            }
            strErrorMsg = RunSQL(strSQLCmd);
            if (strErrorMsg == "True")
            {
                return true;
            }
            else
            {
                Show_Alert("Data Not Added:  " + strErrorMsg);
                return false;
            }
        }
        protected bool Add_Tenant_Details(int intTenantID, bool blnModify = false)
        {
            string strValues = string.Empty;
            string strSQLCmd = string.Empty;
            string strErrorMsg = string.Empty;
            //EXEC PG_Management.dbo.AddToTenantDetails 51,'Test Name','Test Job','Gali 420','Gali 420','Gali 420','1234567890'
            strValues = intTenantID.ToString() + ",'" + txtTenantName.Text.Trim().ToString() + "','" + txtTenantJob.Text.Trim().ToString() + "','" + txtTenantResidence.Text.Trim().ToString() + "','"
                + txtTenantOffice.Text.Trim().ToString() + "','" + txtTenantPermAddress.Text.Trim().ToString() + "','" + txtTenantMobile.Text.Trim().ToString() + "'";
            if (blnModify == false)
            {
                strSQLCmd = "EXEC [PG_Management].[dbo].[AddToTenantDetails] " + strValues;
            }
            else
            {
                strSQLCmd = "EXEC [PG_Management].[dbo].[AddToTenantDetails] " + strValues + ", 1";
            }
            strErrorMsg = RunSQL(strSQLCmd);
            if (strErrorMsg == "True")
            {
                return true;
            }
            else
            {
                Show_Alert("Data Not Added:  " + strErrorMsg);
                return false;
            }

        }
        protected bool Add_LG_Details(int intTenantID, bool blnModify = false)
        {
            string strValues = string.Empty;
            string strSQLCmd = string.Empty;
            string strErrorMsg = string.Empty;
            //EXEC PG_Management.[dbo].[AddToLGDetails] 51,'Test Name','Test Job','Gali 420','Gali 420','Gali 420','3216549870'
            strValues = intTenantID.ToString() + ",'" + txtLGName.Text.Trim().ToString() + "','" + txtLGJob.Text.Trim().ToString() + "','" + txtLGResidence.Text.Trim().ToString() + "','"
                +  txtLGOffice.Text.Trim().ToString() + "','" + txtLGPermAddress.Text.Trim().ToString() + "','" + txtLGMobile.Text.Trim().ToString() + "'";
            if (blnModify == false)
            {
                strSQLCmd = "EXEC [PG_Management].[dbo].[AddToLGDetails] " + strValues;
            }
            else
            {
                strSQLCmd = "EXEC [PG_Management].[dbo].[AddToLGDetails] " + strValues + ", 1";
            }
            strErrorMsg = RunSQL(strSQLCmd);
            if (strErrorMsg == "True")
            {
                return true;
            }
            else
            {
                Show_Alert("Data Not Added:  " + strErrorMsg);
                return false;
            }
        }
        protected  void GetCurrentDetails(string strTenantID)
        {
            //Write Code to get current details of the tenant.
        }
        protected void ModifyTenantDetails(bool blnShowAsEdit = false, string strTenantID = null)
        {
            if (blnShowAsEdit == true)
            {
                int intTenantID;
                bool blnConversionSuccess;
                try
                {
                    bool blnSuccess = bool.Parse(Add_PG_Table_Details(blnShowAsEdit, strTenantID));
                    if (blnSuccess)
                    {
                        blnConversionSuccess = Int32.TryParse(strTenantID, out intTenantID);
                        blnSuccess = Add_Tenant_Details(intTenantID, blnShowAsEdit);
                        if (blnSuccess)
                        {
                            blnSuccess = Add_Tenant_Details(intTenantID, blnShowAsEdit);
                            if (blnSuccess)
                            {
                                blnSuccess = Add_LG_Details(intTenantID, blnShowAsEdit);
                                if (blnSuccess)
                                    Show_Alert("Data Added Successfully, Tenant ID = " + strTenantID);
                                else
                                    Show_Alert("Data Not Added:  " + strTenantID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Show_Alert("Could not update data for Tenant ID " + strTenantID + " due to " + "'" + ex.Message.ToString());
                }



            }
        }
        protected void Add_New_Tenant_Details(object sender, CommandEventArgs e)
        {
            if(Page.IsValid)
            {
                bool blnShowAsEdit = false;
                string strTenantID;
                strTenantID = Add_PG_Table_Details(blnShowAsEdit);
                int intTenantID = 0;
                bool  blnSuccess;
                if (Int32.TryParse(strTenantID, out intTenantID))
                {
                    blnSuccess= Add_Father_Details(intTenantID, blnShowAsEdit);
                    if(blnSuccess)
                    {
                        blnSuccess = Add_Tenant_Details(intTenantID, blnShowAsEdit);
                        if (blnSuccess)
                        {
                            blnSuccess = Add_LG_Details(intTenantID, blnShowAsEdit);
                            if (blnSuccess)
                                Show_Alert("Data Added Successfully, Tenant ID = " + strTenantID);
                            else
                                Show_Alert("Data Not Added:  " + strTenantID);
                        }
                    }
                }
                else
                {
                    Show_Alert("Data Not Added:  " + strTenantID);
                }
                
            }            
        }
    }
}