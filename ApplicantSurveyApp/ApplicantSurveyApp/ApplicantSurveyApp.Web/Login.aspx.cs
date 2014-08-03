using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;

namespace ApplicantSurveyApp.Web
{
    public partial class Login : System.Web.UI.Page
    {
        string adminPage = "admin/admin.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsValidated"] != null)
                Response.Redirect(adminPage);
            if (!IsPostBack)
                txtUserName.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            PrincipalContext con;
            try { 
            using (con = new PrincipalContext(ContextType.ApplicationDirectory, ""))
            {
                if (!con.ValidateCredentials(userName, password))
                    labelResult.Text = "Login failed";
            }

            Session["IsValidated"] = true;
            Response.Redirect(adminPage);
            }
            catch (Exception ex) { 
                labelResult.Text=ex.Message.ToString();
            }
        }
    }
}