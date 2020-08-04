using MyLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Shapes
{    
    public interface IShapes// : ICalculator
    {
        //double Area { get; set; }
        //double Perimeter { get; set; }

        //void Process();

        void CalculateArea();

        void CalculatePerimeter();
    }
}
