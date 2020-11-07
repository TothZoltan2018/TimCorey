using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    /// <summary>
    /// Global config data. Readable for everybody.
    /// </summary>
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";

        public static IDataConnection Connection { get; private set; }

        public static void InitilaizeConnections(DatabaseType db)
        {
            if (db  == DatabaseType.Sql)
            {
                // TODO - Set up the SQL connector properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                // TODO - text connection
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        /// <summary>
        /// It goes to the TrackerUI.Appconfig and gets the connectionstring
        /// </summary>
        /// <param name="name">This name will be looked up</param>
        /// <returns></returns>
        public static string CnnString(string name)
        {
            // We had to add reference assembly System.Configuration
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
