using System;
using System.Net.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NWVDNUG.Core
{
	public class DataService
	{
		public DataService ()
		{

		}

		public static async Task<string> FetchMeetings()
		{
			string responseStr = null;
			string uri = "http://www.nwvdnug.org/api/upcomingmeetings/";

			// Create a json string with a single key/value pair.
			//var json = new JObject(new JProperty("json-key-name", value)).ToString();

			using (var httpClient = new HttpClient())
			{        
				//create the http request content
				//HttpContent content = new StringContent(json);
				HttpContent content = new StringContent("");

				try
				{
					// Send the json to the server using POST
					Task<HttpResponseMessage> getResponse = httpClient.PostAsync(uri, content);

					// Wait for the response and read it to a string var
					HttpResponseMessage response = await getResponse;
					responseStr = await response.Content.ReadAsStringAsync();
				}
				catch (Exception e)
				{
					Console.WriteLine("Error communicating with the server: " + e.Message);
				}
			}
			return responseStr;
		}
	}
}

