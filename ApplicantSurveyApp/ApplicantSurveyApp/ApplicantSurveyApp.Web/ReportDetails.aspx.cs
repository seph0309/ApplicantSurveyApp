using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicantSurveyApp.Web.Admin
{
    public partial class ReportDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ConfigurationManager.AppSettings["ReportServerUrl"] != null &&
                    ConfigurationManager.AppSettings["FolderName"] != null &&
                    Request.QueryString["reportFileName"] != null)
                {
                    ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"].ToString());
                    ReportViewer1.ServerReport.ReportPath = String.Format("{0}{1}", ConfigurationManager.AppSettings["FolderName"].ToString(), Request.QueryString["reportFileName"].ToString()); 
                }
            }
        }
    }
}