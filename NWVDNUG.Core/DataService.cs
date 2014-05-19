using System;
using System.Net.Http;
using System.IO;
using System.Text;
using RestSharp;
using System.Collections.Generic;
using NWVDNUG.Core.Contracts;

namespace NWVDNUG.Core
{
	public class DataService
	{
		public DataService ()
		{

		}

		public static void FetchMeetings(Action<List<MeetingInfo>> callback)
		{
			string uri = "http://www.nwvdnug.org/api/";

			var client = new RestClient (uri);

			var request = new RestRequest ("upcomingmeetings/");
			client.ExecuteAsync<List<MeetingInfo>> (request, response => {
				if (callback != null) {
					callback.Invoke(response.Data);
				}
			});
		}
	}
}

