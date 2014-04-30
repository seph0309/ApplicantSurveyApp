using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace ApplicantSurveyApp 
{
	[Serializable]
	[DataContract]
    public class Survey
    {
		[DataMember]
        public int applicantID { get; set; }
		[DataMember]
        public int questionID { get; set; }
		[DataMember]
        public int rateID { get; set; }
		[DataMember]
		public string comment { get; set; }

    }
}
