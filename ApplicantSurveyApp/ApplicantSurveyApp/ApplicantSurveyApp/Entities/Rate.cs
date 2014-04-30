using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace ApplicantSurveyApp {
	[Serializable]
	[DataContract]
	public class Rate {
		[DataMember]
		public int rateID { get; set; }
		[DataMember]
		public string rateDescription { get; set; }
		[DataMember]
		public string imageLocation{get;set;}
	}
}
