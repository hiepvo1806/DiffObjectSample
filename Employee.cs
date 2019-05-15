using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparerSample
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime EntryDate { get; set; }

        public EmployeeProfile Profile { get; set; }
        public int  EmployeeId { get; set; }

    }
}
