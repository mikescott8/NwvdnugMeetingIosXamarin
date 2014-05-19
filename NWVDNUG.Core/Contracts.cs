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

		public override string ToString ()
		{
			//return string.Format ("[MeetingInfo: Id={0}, Title={1}, Notes={2}, Location={3}, SpeakerName={4}, SpeakerBioLink={5}, MeetingStartTime={6}, MeetingEndTime={7}]", Id, Title, Notes, Location, SpeakerName, SpeakerBioLink, MeetingStartTime, MeetingEndTime);
			return string.Format ("{1} - {0}", Title, MeetingStartTime.Substring(0, MeetingStartTime.IndexOf(" ")-1));
		}
	}
}

