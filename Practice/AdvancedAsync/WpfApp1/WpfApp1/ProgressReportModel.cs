using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public List<string> ReadyProcessNames { get; set; } = new List<string>();
    }
}
