using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicantSurveyApp.Web.Admin {
	public partial class Admin : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
            if (Session["IsValidated"] == null)
                Response.Redirect("../Login.aspx");
		}
  
		[WebMethod]
		public static string ViewReport(string reportName) {
            return string.Format("../ReportDetails.aspx?reportFileName={0}", reportName);
		}

        [WebMethod]
        public static List<string> GetReportNames()
        {
            string _sql = string.Empty;
            ApplicantSurveyApp app = new ApplicantSurveyApp();
            List<string> ret = new List<string>();

            if (ConfigurationManager.AppSettings["ReportDB"] != null &&
                ConfigurationManager.AppSettings["FolderName"] != null)
            {
                ret = app.GetReports(ConfigurationManager.AppSettings["ReportDB"].ToString(),
                    ConfigurationManager.AppSettings["FolderName"].ToString());
            }

            return ret;
        
        }
	}
}