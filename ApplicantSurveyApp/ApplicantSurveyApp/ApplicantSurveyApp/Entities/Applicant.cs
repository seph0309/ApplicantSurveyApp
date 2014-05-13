using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace ApplicantSurveyApp{
	[Serializable]
	[DataContract]
	public class Applicant {
		[DataMember]
		public string firstName { get; set; }
		[DataMember]
		public string lastName { get; set; }
        [DataMember]
        public string position { get; set; }
    }
}
