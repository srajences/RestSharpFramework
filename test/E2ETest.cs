using Xunit;
using RestSharp;
using System.Text.Json;
using AventStack.ExtentReports;
[assembly:TestCaseOrderer("APITESTFRAMEWORK.NumericTestCaseOrderer","APITESTFRAMEWORK")]
namespace APITESTFRAMEWORK{
public  class E2ETest{
    private ExtentReporter extentReporter;
    public E2ETest(){
        extentReporter = new ExtentReporter("index.html");
    }
    private const string PostResponsePath = "C:\\Users\\srajen.singh\\Documents\\ApiFramework\\ApiTestFramework\\RestSharpFramework\\src\\Helpers\\PostResponse.json";
    private const string PostResponseSchemaPath = "C:\\Users\\srajen.singh\\Documents\\ApiFramework\\ApiTestFramework\\RestSharpFramework\\src\\Helpers\\PostRequestSchema.json";

        [Fact]
        public void TestCase1_CreatingUser()
        {
            
            ConfigReader configReader = new ConfigReader();
            string endpointUrl = configReader.ReadUrl("Creating_User_Endpoint");
            string appId = configReader.ReadHeaders("app-id");

            string firstName = TestUtilities.GenerateFirstName();
            string lastName = TestUtilities.GenerateLastName();
            string email = TestUtilities.GenerateEmail(firstName);
            var payload = new
            {
                firstName = firstName,
                lastName = lastName,
                email = email
            };
            var jsonPayload = JsonSerializer.Serialize(payload);
            var client = new RestClient(endpointUrl);
            extentReporter.createTest(nameof(TestCase1_CreatingUser));
            extentReporter.LogStep(Status.Info,"Starting Test Case Execution");
            var request = new RestRequest("",Method.Post);
            request.AddHeader("app-id",appId);
            request.AddJsonBody(jsonPayload);
            var response = client.Execute(request);
            File.WriteAllText(PostResponsePath, jsonRequestIndentator.jsonFormatter(response.Content));
            var schemaJson = File.ReadAllText(PostResponseSchemaPath);
            var validateSchema = SchemaValidator.validateSchema(response.Content,schemaJson);
            Assert.True(validateSchema);
            extentReporter.LogStep(Status.Pass, "Schema is validated");
            Assert.Equal(200,(int)response.StatusCode);
            extentReporter.LogStep(Status.Pass, "Request is successfull");
            extentReporter.FlushReport();

 }
       
        [Theory]
        [InlineData(200)]
        [InlineData(500)]
        public void TestCase2_VerifyingUser(int statusCode){
            ConfigReader configReader = new ConfigReader();
            string endpointUrl = configReader.ReadUrl("Getting_User_Endpoint");
            string appId = configReader.ReadHeaders("app-id");
            string id = configReader.ReadId("id");
            var client = new RestClient(endpointUrl+"/"+id);
            extentReporter.createTest(nameof(TestCase2_VerifyingUser));
            extentReporter.LogStep(Status.Info,"Starting Test Case Execution");
            var request = new RestRequest("",Method.Get);
            request.AddHeader("app-id",appId);
            var response = client.Execute(request);
            Assert.Equal(statusCode,(int)response.StatusCode);
            extentReporter.LogStep(Status.Pass, "Request is successfull");
            extentReporter.FlushReport();
            
        }
    }
}

