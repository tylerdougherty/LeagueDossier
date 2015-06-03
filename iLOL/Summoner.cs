using System;
using System.Net;
using System.IO;
using System.Json;

namespace iLOL
{
	/// <summary>
	/// Represents a Summoner object.
	/// </summary>
	public class Summoner
	{
		public long ID { get; protected set; }
		public string Name { get; protected set; }
		private int profileIconID;
		public long Level { get; protected set; }

		public Summoner() {}

		/// <summary>
		/// Creates a Summoner object and loads its information.
		/// </summary>
		/// <param name="text">The summoner's name.</param>
		public Summoner(string name)
		{
			//Get the basic Summoner info
			var info = iLOL.GetJson(String.Format(
				"https://na.api.pvp.net/api/lol/{0}/{1}/summoner/by-name/{2}?api_key={3}",
				iLOL.REGION, iLOL.VERSION_SUMMONER, name, iLOL.API_KEY))[name];
			ID = info["id"];
			Name = info["name"];
			profileIconID = info["profileIconId"];
			Level = info["summonerLevel"];

			//Get the Summoner summary (aggregated stats)
			var summary = iLOL.GetJson(String.Format(
				"https://na.api.pvp.net/api/lol/{0}/{1}/stats/by-summoner/{2}/summary?api_key={3}",
				iLOL.REGION, iLOL.VERSION_STATS, ID, iLOL.API_KEY));


		}
	}
}