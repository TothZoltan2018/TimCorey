using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public static class Examples
    {
        public static string ExampleLoadTextFile(string file)
        {
            if (file.Length < 10)
            {
                throw new ArgumentException("The file name was too short", "file"); // "file" is the param name caused the exception
                //throw new System.IO.FileNotFoundException();
            }

            return "The file was correctly loaded.";
        }
    }
}
