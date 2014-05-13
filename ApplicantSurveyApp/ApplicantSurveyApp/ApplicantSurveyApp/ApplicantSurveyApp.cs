using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ApplicantSurveyApp;
using System.IO;

namespace ApplicantSurveyApp
{
	public class ApplicantSurveyApp : IApplicantSurveyApp 
	{
        DataSet ds;
        DBConn.DBConn conn;

		private int SaveApplicant(Applicant applicant) {
            ds = new DataSet();
            conn = new DBConn.DBConn();
            ds = conn.execSQLCommand(String.Format("EXEC spSaveApplicant '{0}', '{1}', '{2}' ", applicant.firstName, applicant.lastName, applicant.position));
            if (Convert.ToInt32(ds.Tables[0].Rows.Count) > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            else
                return 0;
		}

		private bool SaveSurvey(Survey survey, int applicantID) {
            string param = "EXEC spSaveSurvey '" + applicantID + "', ";
			param = param + "'" + survey.questionID + "', '" + survey.rateID + "','" + survey.comment + "'";
            conn = new DBConn.DBConn();
            conn.execSQLCommand(param);
            return true;
		}

		public bool SaveSurveys(List<Survey> surveys, Applicant applicant) {
			int applicantID = SaveApplicant(applicant);

			foreach (Survey survey in surveys) {
				SaveSurvey(survey, applicantID);
			}
			return true;
		}

		public List<Question> GetQuestions() {
			List<Question> questions = new List<Question>();

            ds = new DataSet();
            conn = new DBConn.DBConn();

            ds = conn.execSQLCommand("SELECT * FROM ViewQuestions");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                questions.Add(new Question {
                    questionID = Convert.ToInt32( row["questionID"]),
                    questionDescription = Convert.ToString(row["questionDescription"]),
                    questionTypeID = Convert.ToInt32(row["questionTypeID"])                
                });
            }
			return questions;
		}

		public List<ImageDetail> GetImages() {
			ds = new DataSet();
			conn = new DBConn.DBConn();
			List<ImageDetail> imageDetail = new List<ImageDetail>();

			ds = conn.execSQLCommand("SELECT * FROM ImageDetail  WHERE Active=1 ORDER BY ImageID ASC");
			foreach (DataRow row in ds.Tables[0].Rows) {
				imageDetail.Add(new ImageDetail {
					imageID = Convert.ToInt32(row["ImageID"]),
					location = Convert.ToString(row["Location"]),
					comment = Convert.ToString(row["Comment"]),
					width = Convert.ToInt32(row["Width"]),
					height = Convert.ToInt32(row["Height"])
				});
			}
			return imageDetail;
		}
		public List<ImageDetail> GetImagesFromDirectory(string localPath, string serverPath) {

			List<ImageDetail> imageDetail = new List<ImageDetail>();
			List<string> imageFiles = new List<string>();


			if (Directory.Exists(localPath)) {
				// This path is a directory
				imageFiles = Directory.GetFiles(localPath, "*.*", SearchOption.TopDirectoryOnly)
					.Where(fileName => 
						fileName.EndsWith(".jpg")
						|| fileName.EndsWith(".JPG") 
						|| fileName.EndsWith(".png")
						|| fileName.EndsWith(".PNG")).ToList();

				foreach (string imgFile in imageFiles) {
					imageDetail.Add(new ImageDetail {
						imageID = 0,
						location = serverPath + "/" + Path.GetFileName(imgFile),
						comment = "",
						width = 0,
						height = 0
					});

				}
			}
			else {
				throw new Exception("Directory not found");
			}         
		 
			return imageDetail;
		}
		public List<Rate> GetRates() {
			ds = new DataSet();
			conn = new DBConn.DBConn();
			List<Rate> rates = new List<Rate>();

			ds = conn.execSQLCommand("SELECT * FROM Rate ORDER BY rateID DESC");
			foreach (DataRow row in ds.Tables[0].Rows) {
				rates.Add(new Rate {
					rateID = Convert.ToInt32(row["rateID"]),
					rateDescription = Convert.ToString(row["rateDescription"]),
					imageLocation = Convert.ToString(row["imageLocation"])
				});
			}
			return rates;
		}
		public string GetLocalPath() {
			ds = new DataSet();
			conn = new DBConn.DBConn();
			string path = "";

			List<ImageDetail> imageDetail = new List<ImageDetail>();
			ds = conn.execSQLCommand("SELECT * FROM ImageDirectory");
			if (ds.Tables[0].Rows.Count != 0) {
				path = Convert.ToString(ds.Tables[0].Rows[0][0]);
			}
			return path;
		} 
		 
		public string ExportReport(string reportName, string outputPath) {
			ds = new DataSet();
			conn = new DBConn.DBConn();
			string sqlQuery = "";
			string fileName = "";

			if (reportName == "SurveyStatistics") {
				fileName = "SurveyStatistics";
				sqlQuery = "spViewSurveyStatistics";
			}
			else if (reportName == "SurveyPercentage") {
				fileName = "SurveyPercentage";
				sqlQuery = "spViewSurveyPercentage";
			}

			sqlQuery = "EXEC " + sqlQuery;

			fileName = fileName + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".csv";
			ds = conn.execSQLCommand(sqlQuery);

			DataTabletoCSV(ds.Tables[0], outputPath + fileName);
			return fileName;

		}
		private void DataTabletoCSV(DataTable dt, string outputPath) {

			StringBuilder sb = new StringBuilder();

			IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
											  Select(column => column.ColumnName);
			sb.AppendLine(string.Join(",", columnNames));

			foreach (DataRow row in dt.Rows) {

				IEnumerable<string> fields = row.ItemArray.Select(field => StripQuotes(field.ToString()));
				sb.AppendLine(string.Join(",", fields));
			}

			File.WriteAllText(outputPath, sb.ToString());
		}
		private string StripQuotes(string val) {

			val = val.Replace(",", "");
			return val;

		}
	}
}
