using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml.Style;
using System.Drawing;
using System;

namespace ExcelDemo
{
    class Program
    {
        static async Task Main(string[] args) // From c# 7 Main method can be async
        {
            // Propertie --> set to .Net 5
            // Installed nuget package epplus

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(@"C:\Users\ZoliRege\source\repos\TimCorey\ExcelDemoApp\YouTubeDemo.xlsx");

            var people = GetSetupData();

            await SaveExcelFile(people, file);

            List<PersonModel> peopleFromExcel = await LoadExcelFile(file);

            peopleFromExcel.ForEach(p => Console.WriteLine($"{p.Id}, {p.FirstName}, {p.LastName}"));
        }

        private static async Task<List<PersonModel>> LoadExcelFile(FileInfo file)
        {
            List<PersonModel> output = new();

            using var package = new ExcelPackage(file);

            await package.LoadAsync(file);

            var ws = package.Workbook.Worksheets[0];

            // The actual data starts from row 3 in out excel file.
            int row = 3;
            int col = 1;

            // Checking if the "Id" column has value
            while (string.IsNullOrWhiteSpace(ws.Cells[row,col].Value?.ToString()) == false)
            {
                PersonModel p = new();
                p.Id = int.Parse(ws.Cells[row, col].Value.ToString());
                p.FirstName = ws.Cells[row, col + 1].Value.ToString();
                p.LastName = ws.Cells[row, col + 2].Value.ToString();

                output.Add(p);
                row++;
            }

            return output;
        }

        private static async Task SaveExcelFile(List<PersonModel> people, FileInfo file)
        {
            DeleteIfExists(file);

            // Create and open the Excelfile
            using var package = new ExcelPackage(file); // From  c# 8 () and {} is not needed. method ending } will dispose it.

            var ws = package.Workbook.Worksheets.Add("MainReport");

            var range = ws.Cells["A2"].LoadFromCollection(people, true);
            range.AutoFitColumns();            

            // Formats the header
            ws.Cells["A1"].Value = "Our Cool Report";
            ws.Cells["A1:C1"].Merge = true;
            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(1).Style.Font.Size = 24;
            ws.Row(1).Style.Font.Color.SetColor(Color.Blue);

            ws.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Row(2).Style.Font.Bold = true;
            ws.Column(3).Width = 20;

            await package.SaveAsync();
        }

        private static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }

        /// <summary>
        /// This data will be stoed in Excel
        /// </summary>
        /// <returns></returns>
        private static List<PersonModel> GetSetupData()
        {
            List<PersonModel> output = new() // From c# 9 we can use new() instead of new List<PersonModel>()
            {
                new() { Id = 1, FirstName = "Tim", LastName = "Corey"},
                new() { Id = 2, FirstName = "Sue", LastName = "Storm" },
                new() { Id = 3, FirstName = "Jane", LastName = "Smith" }
            };

            return output;
        }
    }
}
