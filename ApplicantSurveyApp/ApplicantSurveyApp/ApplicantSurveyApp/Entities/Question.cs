using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace ApplicantSurveyApp {
	[Serializable]
	[DataContract]
	public class Question {
		public Question(Question question) {
			questionID = question.questionID;
			questionDescription = question.questionDescription;
			questionTypeID = question.questionTypeID;
		}
		public Question() { 
		}
		[DataMember]
		public int questionID { get; set; }
		[DataMember]
		public string questionDescription { get; set; }
		[DataMember]
		public int questionTypeID { get; set; }
	}
}
