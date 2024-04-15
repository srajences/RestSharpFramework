using System.Text.Json;

namespace APITESTFRAMEWORK
{
    public class ConfigReader
    {
        private const string ConfigPath = "C:\\Users\\srajen.singh\\Documents\\ApiFramework\\ApiTestFramework\\RestSharpFramework\\src\\Helpers\\Config.json";
         private const string jsonResponsePath = "C:\\Users\\srajen.singh\\Documents\\ApiFramework\\ApiTestFramework\\RestSharpFramework\\src\\Helpers\\PostResponse.json";

        public string ReadUrl(string url){
            var json = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(ConfigPath));
            return json.GetProperty("ApiConstructor").GetProperty(url).GetString();
        }
        public string ReadHeaders(string Headers){
            var json = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(ConfigPath));
            return json.GetProperty("ApiConstructor").GetProperty(Headers).GetString();
        }
            public string ReadId(string Id){
            var json = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(jsonResponsePath));
            return json.GetProperty(Id).GetString();
        }
    }
}