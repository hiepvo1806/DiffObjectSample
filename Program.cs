using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;

namespace ComparerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> OldList = SampleData.PrepareEmployeeFirstData();
            List<Employee> NewList = SampleData.PrepareEmployeeSecondData();
            Console.WriteLine("Application Started");

            var compareLogic = GetCompareLogicConfig();
            ComparisonResult result = compareLogic.Compare(OldList, NewList);
            if (!result.AreEqual)
            {
                //PrintAllTheDifferences(result);
                PrintFormattedDifferences(result);
            }
            Console.ReadLine();
        }

        private static CompareLogic GetCompareLogicConfig()
        {
            CompareLogic compareLogic = new CompareLogic();
            compareLogic.Config.MaxDifferences = Int32.MaxValue;
            compareLogic.Config.IgnoreCollectionOrder = true;

            var spec = new Dictionary<Type, IEnumerable<string>>();
            spec.Add(typeof(Employee), new[] { "EmployeeId" });
            compareLogic.Config.CollectionMatchingSpec = spec;
            return compareLogic;
        }

        #region Presentation

        private static void PrintFormattedDifferences(ComparisonResult result)
        {
            List<DisplayDiffModel> displayDiffList = new List<DisplayDiffModel>();
            if (!result.AreEqual && result.Differences != null && result.Differences.Count > 0)
            {
                foreach (var diff in result.Differences
                )
                {
                    displayDiffList.Add(new DisplayDiffModel
                    {
                        PropertyName = diff.PropertyName,
                        Object1Value = diff.Object1Value,
                        Object2Value = diff.Object2Value,
                        TypeOfObject = (diff.ParentObject1 != null ? diff.ParentObject1.GetType().ToString() : (diff.ParentObject2?.GetType().ToString()))
                    });
                }
            }
            Console.WriteLine(JsonConvert.SerializeObject(
                displayDiffList
                    .Where(q=>!string.IsNullOrEmpty(q.TypeOfObject))
                
                , Formatting.Indented));
        }

        private static void PrintAllTheDifferences(ComparisonResult result)
        {
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
        #endregion
    }

    public class DisplayDiffModel
    {
        public string PropertyName { get; set; }
        public string Object1Value { get; set; }
        public string Object2Value { get; set; }
        public string TypeOfObject { get; set; }
    }
}
