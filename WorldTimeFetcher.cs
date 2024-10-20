using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public static class WorldTimeFetcher
{
	private static readonly HttpClient client = new HttpClient();

	public static async Task<string> FetchCurrentDateTimeAsync()
	{
		try
		{
			string url = "http://worldtimeapi.org/api/timezone/Etc/UTC";
			HttpResponseMessage response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();

			string responseBody = await response.Content.ReadAsStringAsync();
			JObject json = JObject.Parse(responseBody);

			string dateTime = json["datetime"]?.ToString() ?? "N/A";
      return dateTime;
		}
		catch (HttpRequestException e)
		{
			Console.WriteLine($"Request error: {e.Message}");
      return "N/A";
		}
	}

}