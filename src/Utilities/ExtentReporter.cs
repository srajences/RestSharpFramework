using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Xunit.Abstractions;

public class ExtentReporter
{
    private ExtentReports extent;
    private ExtentTest test;


    public ExtentReporter( string fileName){
        var htmlReporter = new ExtentHtmlReporter(fileName);
        extent =  new ExtentReports();
        extent.AttachReporter(htmlReporter);
    }


    public void createTest(string TestCaseName){
        test = extent.CreateTest(TestCaseName);
    }
    public void LogStep(Status status, string message){
        test.Log(status,message);
    }
    public void FlushReport(){
        extent.Flush();
    }
}

 