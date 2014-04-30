using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data;

namespace ApplicantSurveyApp {
    [ServiceContract]
	interface IApplicantSurveyApp {
		[OperationContract]
		bool SaveSurveys(List<Survey> surveys, Applicant applicant);
		[OperationContract]
        List<Question> GetQuestions();
		[OperationContract]
		List<Rate> GetRates();
		[OperationContract]
		List<ImageDetail> GetImages();
		[OperationContract]
		List<ImageDetail> GetImagesFromDirectory(string localPath, string serverPath);
		[OperationContract]
		string GetLocalPath(); 
		[OperationContract]
		string ExportReport(string reportName, string outputPath);
	}
}
