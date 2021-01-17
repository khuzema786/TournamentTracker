using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.DataAccess;

namespace TournamentLibrary
{
	public static class GlobalConfig
	{
		public const string PrizesFile = "PrizeModels.csv";
		public const string PersonFile = "PersonModels.csv";
		public const string TeamsFile = "TeamModels.csv";
		public const string TournamentsFile = "TournamentModels.csv";
		public const string MatchupFile = "MatchupModels.csv";
		public const string MatchupEntryFile = "MatchupEntryModels.csv";
		public static IDataConnection Connection { get; private set; }
		public static void InitializeConnections(DatabaseType db)
		{
			switch (db)
			{
				case DatabaseType.Sql:
					// TODO - Set up the SQL Connector properly
					SqlConnector sql = new SqlConnector();
					Connection = sql;
					break;
				case DatabaseType.TextFile:
					// TODO - Create Text Connection
					TextConnector text = new TextConnector();
					Connection = text;
					break;
				default:
					break;
			}
		}
		/// <summary>
		/// It will go to App.config and return the connection string.
		/// </summary>
		public static string CnnString(string name)
		{
			return ConfigurationManager.ConnectionStrings[name].ConnectionString;
		}
		public static string AppKeyLookup(string key)
        {
			return ConfigurationManager.AppSettings[key];
		}
	}
}
