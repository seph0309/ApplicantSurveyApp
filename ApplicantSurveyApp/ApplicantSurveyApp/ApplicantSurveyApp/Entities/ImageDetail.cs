using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ApplicantSurveyApp {
	[Serializable]
	[DataContract]
	public class ImageDetail {
		[DataMember]
		public int imageID { get; set; }
		[DataMember]
		public string location { get; set; }
		[DataMember]
		public string comment { get; set; }
		[DataMember]
		public int width { get; set; }
		[DataMember]
		public int height { get; set; }
	}
}
