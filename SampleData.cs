using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparerSample
{
    public static class SampleData
    {
        public static List<Employee> PrepareEmployeeFirstData()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    Age = 25,
                    Name = "Jeff Vo",
                    EntryDate = DateTime.MinValue,
                    Profile = new EmployeeProfile()
                    {
                        Level = Level.Junior,
                        Address = "Somewhere on earth"
                    }
                },
                new Employee()
                {
                    EmployeeId = 2,
                    Age = 28,
                    Name = "Da hell is this guy",
                    EntryDate = DateTime.MinValue,
                    Profile = new EmployeeProfile()
                    {
                        Level = Level.Senior,
                        Address = "Somewhere on Mars"
                    }
                },
                new Employee()
                {
                    EmployeeId = 3,
                    Age = 35,
                    Name = "Dont know who is this one",
                    EntryDate = DateTime.Now, //call 2nd so wrong ticks
                    Profile = new EmployeeProfile()
                    {
                        Level = Level.MidLevel,
                        Address = "Somewhere on earth 102"
                    }
                }
            };
        }

        public static List<Employee> PrepareEmployeeSecondData()
        {
            var result = PrepareEmployeeFirstData();
            result[0].Age = 49;
            result[1].Name = "2nd changes";
            result[2].Profile.Address = "Viettel Complex Building";
            result.Add(new Employee()
            {
                EmployeeId = 5,
                Age = 35,
                Name = "Dont know who is this one",
                EntryDate = DateTime.Now,
                Profile = new EmployeeProfile()
                {
                    Level = Level.MidLevel,
                    Address = "Somewhere on earth 102"
                }
            });
            return result;
        }
    }
}
