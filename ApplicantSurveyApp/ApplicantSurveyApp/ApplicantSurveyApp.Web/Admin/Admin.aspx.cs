using System;
using System.Collections.Generic;
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
		
		}
  
		[WebMethod]
		public static string GetReport(string reportName) {
			try {
				string folderPath = "../Downloads/";
				string fullPath = HttpContext.Current.Server.MapPath(folderPath);
				ApplicantSurveyApp app = new ApplicantSurveyApp();

				string retValue = app.ExportReport(reportName, fullPath);
				return folderPath + retValue;
			}
			catch (Exception ex) {
				return ex.Message.ToString();
			}	
		
		}
	}
}