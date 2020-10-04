using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Global config data. Readable for everybody.
    /// </summary>
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitilaizeConnections(bool database, bool textFiles)
        {
            if (database)
            {
                // TODO - Set up the SQL connector properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                // TODO - text connection
                TextConnecton text = new TextConnecton();
                Connections.Add(text);
            }
        }
    }
}
