using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparerSample
{
    public class EmployeeProfile
    {
        public string Address { get; set; }
        public Level Level { get; set; }

    }

    public enum Level
    {
        Junior,
        MidLevel,
        Senior
    }
}
