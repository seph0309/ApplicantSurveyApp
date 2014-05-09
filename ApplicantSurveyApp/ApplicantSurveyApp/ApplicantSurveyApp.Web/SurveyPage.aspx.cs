using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApplicantSurveyApp;

namespace ApplicantSurveyApp.Web
{
    public partial class SurveyPage : System.Web.UI.Page {
		#region Properties
		ApplicantSurveyApp applicantSurveyApp;
		List<Survey> surveys {
			get {
				if (ViewState["surveys"] != null)
					return ViewState["surveys"] as List<Survey>;
				else
					return null;
			}
			set { ViewState["surveys"] = value; }
		}
		List<Question> questions {
			get {
				if (ViewState["questions"] != null)
					return ViewState["questions"] as List<Question>;
				else
					return null;
			}
			set { ViewState["questions"] = value; }
		}
		List<Rate> rates {
			get {
				if (ViewState["rates"] != null)
					return ViewState["rates"] as List<Rate>;
				else
					return null;
			}
			set {
				ViewState["rates"] = value;
			}
		}
		Applicant applicant {
			get {
				if (ViewState["applicant"] != null)
					return ViewState["applicant"] as Applicant;
				else
					return null;
			}
			set {
				ViewState["applicant"] = value;
			}
		}
		int surveyStep {
			get {
				if (ViewState["surveyStep"] != null)
					return (int)ViewState["surveyStep"];
				else
					return 0;
			}
			set {
				ViewState["surveyStep"] = value;
			}
		}
		int rateID = 0;
		#endregion
		
		protected void Page_Load(object sender, EventArgs e) { 
			if (!Page.IsPostBack) {
				Session.Clear();
				GetSurveyQuestions();
				MultiView1.SetActiveView(applicantInformationView);
				surveys = new List<Survey>();
			}
			PopulateRateImageButtons();
		}
		#region ApplicantInformationView events
		protected void ApplicantInformationView_Activate(object sender, EventArgs e) {
			backImageButton.Visible = false;
			nextImageButton.Visible = true;
			submitImageButton.Visible = false;
			surveyStep = 0;
		}
		protected void ApplicantInformationView_Deactivate(object sender, EventArgs e) {
			applicant = new Applicant {
				firstName = firstNameTextBox.Text,
				lastName = lastNameTextBox.Text
			}; 
		}
		#endregion
		#region ImageButton Events
		protected void submitImageButton_Click(object sender, ImageClickEventArgs e) {
			if (surveyStep != 0)
				PopulateAnswer(surveyStep - 1);
			SaveSurvey();
		}

		protected void backImageButton_Click(object sender, ImageClickEventArgs e) {
			surveyStep -= 1;
			if (surveyStep > 0)
				surveys.RemoveAt(surveyStep - 1);
			ConfigureQuestion(surveyStep -1);
		}

		protected void nextImageButton_Click(object sender, ImageClickEventArgs e) {
			ProcessNextQuestion();
		}
		#endregion
		private void GetSurveyQuestions() {
			ApplicantSurveyApp applicantSurveyApp = new ApplicantSurveyApp();
			questions = applicantSurveyApp.GetQuestions();
		}
		
		private void ConfigureQuestion(int step) {
			Question question = new Question(questions[step]);
			MultiView1.SetActiveView(questionView); 

			nextImageButton.Visible = false;

			if (step + 1 > 1)
				backImageButton.Visible = true;
			else
				backImageButton.Visible = false;

			if (question.questionTypeID == 1) {
				ImageButtonsDiv.Visible = true;
				commentsTextBox.Visible = false;
				submitImageButton.Visible = false;
			}
			else {
				ImageButtonsDiv.Visible = false;
				commentsTextBox.Visible = true;
				submitImageButton.Visible = true;
				commentsTextBox.Text = "";
			}
			questionLabel.Text = question.questionDescription;
			countLabel.Text = "Question " + surveyStep.ToString() + " of " + questions.Count.ToString();
		}
		private void PopulateAnswer(int step) {
			if (rateID == 0) rateID = 0;
			surveys.Add(new Survey {
				questionID = questions[step].questionID,
				rateID =rateID,
				comment = commentsTextBox.Text
			});
		}  
		private void ProcessNextQuestion() {
			if (surveyStep != 0)
				PopulateAnswer(surveyStep - 1);
			surveyStep += 1;
			if (surveyStep > questions.Count)
				SaveSurvey();
			ConfigureQuestion(surveyStep - 1);
		}
		private void SaveSurvey() {
			applicantSurveyApp = new ApplicantSurveyApp();
			applicantSurveyApp.SaveSurveys(surveys, applicant);
			Response.Redirect("SurveyPageFinish.aspx");
		}
		private void PopulateRateImageButtons() {
			if (rates == null) {
				applicantSurveyApp = new ApplicantSurveyApp();
				rates = new List<Rate>();
				rates = applicantSurveyApp.GetRates();
			}
 
			ImageButton imageButton;
			LiteralControl literalControlspace; 

			//Initial Size. Standard size for smiley is 150px 
			int width = ChangeImageSize(200);
			int height = ChangeImageSize(200);


			foreach (Rate rate in rates) {
				imageButton = new ImageButton();
				imageButton.ImageUrl = rate.imageLocation;
				imageButton.CssClass = "imgButtonImg";
				imageButton.ID = rate.rateID.ToString();
				imageButton.AlternateText = rate.rateDescription.ToString();
				imageButton.Width = width;
				imageButton.Height = height;
				imageButton.Click += imageButton_Click;

				literalControlspace = new LiteralControl();
				literalControlspace.ID = "space_" + imageButton.ID;
				literalControlspace.Text = "&nbsp;&nbsp;&nbsp;&nbsp;";
				
				ImageButtonsDiv.Controls.Add(imageButton);
				ImageButtonsDiv.Controls.Add(literalControlspace);
			} 
		}
		private int ChangeImageSize(int size) {
			if (Request.Browser.IsMobileDevice) {
				string Browser = Request.UserAgent.ToString().ToLower();
				if (Browser.Contains("iphone"))
					size = size/2;
				else if (Browser.Contains("android")) //insert custom android image size
					size = size / 2;
			} 
			return size;
		}
		protected void imageButton_Click(object sender, ImageClickEventArgs e) {
			rateID = Convert.ToInt32(((ImageButton)sender).ID);
			ProcessNextQuestion();
		}
		 
    }
}