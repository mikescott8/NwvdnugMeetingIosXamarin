using System;
using System.Net.Http;
using System.IO;
using System.Text;
using RestSharp;

namespace NWVDNUG.Core
{
	public class DataService
	{
		public DataService ()
		{

		}

		public static string FetchMeetings()
		{
			string responseStr = null;
			string uri = "http://www.nwvdnug.org/api/";

			var client = new RestClient (uri);

			var request = new RestRequest ("upcomingmeetings/");
			client.ExecuteAsync (request, response => {
				Console.WriteLine (response.Content);
			});
			return responseStr;
		}
	}
}

