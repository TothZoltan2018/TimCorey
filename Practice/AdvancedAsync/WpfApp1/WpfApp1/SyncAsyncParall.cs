using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace WpfApp1
{
    public class SyncAsyncParall
    {
        public static string DummyLongLastMethodSync(DummyData dummyData)
        {
            Thread.Sleep(dummyData.ExecTime);
            return $"{dummyData.Name} is ready\n";
        }

        public static async Task<string> DummyLongLastMethodAsync(DummyData dummyData)
        {            
            //This is the way for calling a synchronous task asynchronously
            await Task.Run( () => Thread.Sleep(dummyData.ExecTime));
            return $"{dummyData.Name} is ready\n";
        }

        public static List<string> MethodSync()
        {
            var dummyDataList =  CreateDummyDataList();
            List<string> output = new List<string>();

            foreach (var data in dummyDataList)
            {
                output.Add(DummyLongLastMethodSync(data));
            }

            return output;
        }

        public static List<string> MethodParallelSync()
        {
            var dummyDataList = CreateDummyDataList();
            // Adding strings togeather was not good: only the longest execution time was shown.
            // List of strings works as expected
            List<string> output = new List<string>();

            Parallel.ForEach<DummyData>(dummyDataList, data =>
            {
                output.Add(DummyLongLastMethodSync(data));
            });

            return output;
        }
        public static async Task<List<string>> MethodAsync()
        {
            var dummyDataList = CreateDummyDataList();
            List<string> output = new List<string>();

            foreach (var data in dummyDataList)
            {
                //It calls the same Synchronous method, but asynchronously by 'Task.Run'
                //string result = await DummyLongLastMethodAsync(data);

                //Alternatively, we can call our asynchronous method like this:
                string result = await Task.Run(() => DummyLongLastMethodSync(data));
                output.Add(result);
            }

            return output;
        }

        public static async Task<List<string>> MethodParallelAsync()
        {
            var dummyDataList = CreateDummyDataList();
            //List<string> output = new List<string>();
            List<Task<string>> taskList = new List<Task<string>>();

            foreach (var data in dummyDataList)
            {                
                //taskList.Add(Task.Run(() => DummyLongLastMethodSync(data)));
                taskList.Add(DummyLongLastMethodAsync(data));             
            }

            var results = await Task.WhenAll(taskList);

            return results.ToList();
        }

        private static List<DummyData> CreateDummyDataList()
        {
            List<DummyData> dummyData = new List<DummyData>()
            {
                new DummyData(){ ExecTime = 1500, Name = "A"},
                new DummyData(){ ExecTime = 500, Name = "B"},
                new DummyData(){ ExecTime = 2800, Name = "C"},
                new DummyData(){ ExecTime = 1000, Name = "D"},
            };

            return dummyData;
        }
    }

    public class DummyData
    {
        public int ExecTime { get; set; }
        public string Name { get; set; }
    }


}
