using System;

namespace NWVDNUG.Core.Contracts
{
	public class MeetingInfo
	{
		public int Id {
			get;
			set;
		}
		public string Title {
			get;
			set;
		}
		public string Notes {
			get;
			set;
		}
		public string Location {
			get;
			set;
		}
		public string SpeakerName {
			get;
			set;
		}
		public string SpeakerBioLink {
			get;
			set;
		}
		public string MeetingStartTime {
			get;
			set;
		}
		public string MeetingEndTime {
			get;
			set;
		}

		public MeetingInfo ()
		{

		}
	}
}

