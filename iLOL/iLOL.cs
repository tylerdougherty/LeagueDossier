using System;
using Foundation;
using System.Json;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace iLOL
{
	/// <summary>
	/// This class contains both an interface to Riot's web API to fetch League of Legends
	/// 	data as well as definitions for each section of the API (ie. split up into
	/// 	Summoner, Champion, Item, etc.).
	/// </summary>
	public static class iLOL
	{
		#region Constants
		public static readonly string REGION = "na";
		public static readonly string API_KEY = "eb7fd599-6684-4d35-a682-2e9a131fbf63";
		public static readonly string VERSION_SUMMONER = "v1.4";
		public static readonly string VERSION_STATS = "v1.3";
		#endregion

		public static string ddversion;
		public static string language;

		/// <summary>
		/// Initialize the class for use. This must always be called before using other methods.
		/// </summary>
		public static void Init()
		{
			//Load the version numbers from the realms file
			var result = GetJson("https://ddragon.leagueoflegends.com/realms/na.json");

			ddversion = (string)result["v"];
			language = (string)result["l"];
		}

		public static JsonObject GetJson(string url)
		{
			var request = HttpWebRequest.CreateHttp(url);
			request.ContentType = "application/json";
			request.Method = "GET";

			using (var response = request.GetResponse() as HttpWebResponse)
			{
				//TODO: add more error handling here
				if (response.StatusCode != HttpStatusCode.OK)
					throw new Exception("Web request failed!");

				using (var reader = new StreamReader(response.GetResponseStream()))
					return JsonValue.Parse(reader.ReadToEnd()) as JsonObject;
			}
		}
	}
}