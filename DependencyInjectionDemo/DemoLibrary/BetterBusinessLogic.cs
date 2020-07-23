using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BetterBusinessLogic : IBusinessLogic
    {
        ILogger _logger;
        IDataAccess _dataAccess;

        // Constructor injection. This is the preferred way. --> The class can't be static.
        public BetterBusinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }
        public void ProcessData()
        {
            Console.WriteLine($"BusinessLogic name is {nameof(BetterBusinessLogic)}\n");
            _logger.Log("Starting the processing of data.");
            Console.WriteLine();
            Console.WriteLine("Processing the data");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            Console.WriteLine();
            _logger.Log("Finished processing of the data.");
            Console.WriteLine();
        }
    }
}
