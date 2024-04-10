using System.Text.RegularExpressions;
using Xunit.Abstractions;
using Xunit.Sdk;
namespace APITESTFRAMEWORK{
public class NumericTestCaseOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
        where TTestCase : ITestCase
    {
        // Extract test case numbers from names
        return testCases.OrderBy(t =>
        {
            var match = Regex.Match(t.DisplayName, @"TestCase(?<number>\d+)");
            return match.Success ? int.Parse(match.Groups["number"].Value) : int.MaxValue;
        });
    }
}
}
