using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Xml;
using ApplicantSurveyApp;
using System.IO;

namespace ApplicantSurveyApp.Web {
	public partial class SurveyPageFinish : System.Web.UI.Page {

		
		protected void Page_Load(object sender, EventArgs e) {
			 
		}
		[WebMethod]
		public static List<ImageDetail> GetImages() {
			List<ImageDetail> imageDetails = new List<ImageDetail>();
			ApplicantSurveyApp applicantSurveyApp = new ApplicantSurveyApp();

			string serverPath = applicantSurveyApp.GetLocalPath();
			imageDetails = applicantSurveyApp.GetImagesFromDirectory(HttpContext.Current.Server.MapPath(serverPath), serverPath);
			 
			return imageDetails;
		}
		 
	}
}