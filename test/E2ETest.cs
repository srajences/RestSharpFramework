using Xunit;
using RestSharp;
using System.Text.Json;
[assembly:TestCaseOrderer("APITESTFRAMEWORK.NumericTestCaseOrderer","APITESTFRAMEWORK")]
namespace APITESTFRAMEWORK{
public  class ApiTests{
    private const string PostResponsePath = "C:\\Users\\srajen.singh\\Documents\\ApiFramework\\ApiTestFramework\\RestSharpFramework\\src\\Helpers\\PostResponse.json";
    private const string PostResponseSchemaPath = "C:\\Users\\srajen.singh\\Documents\\ApiFramework\\ApiTestFramework\\RestSharpFramework\\src\\Helpers\\PostRequestSchema.json";

        [Fact]
        public void TestCase1()
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
            var request = new RestRequest("",Method.Post);
            request.AddHeader("app-id",appId);
            request.AddJsonBody(jsonPayload);
            var response = client.Execute(request);
            File.WriteAllText(PostResponsePath, jsonRequestIndentator.jsonFormatter(response.Content));
            var schemaJson = File.ReadAllText(PostResponseSchemaPath);
            var validateSchema = SchemaValidator.validateSchema(response.Content,schemaJson);
            Assert.True(validateSchema);
            Assert.Equal(200,(int)response.StatusCode);
 }
    }
}

