using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Utilities
{
    public class DataAccess : IDataAccess
    {
        ILogger _logger;

        // Let make a constructor to receive a logger
        public DataAccess(ILogger logger)
        {
            _logger = logger;
        }
        public void LoadData()
        {
            Console.WriteLine("Loading Data");
            _logger.Log("Loading Data (in DataAccess class)");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
            _logger.Log("Saving Data (in DataAccess class)");
        }
    }
}
