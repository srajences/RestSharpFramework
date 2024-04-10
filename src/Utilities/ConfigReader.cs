using System.Text.Json;

namespace APITESTFRAMEWORK
{
    public class ConfigReader
    {
        private const string ConfigPath = "C:\\Users\\srajen.singh\\Documents\\ApiFramework\\ApiTestFramework\\RestSharpFramework\\src\\Helpers\\Config.json";
        public string ReadUrl(string url){
            var json = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(ConfigPath));
            return json.GetProperty("ApiConstructor").GetProperty(url).GetString();
        }
        public string ReadHeaders(string Headers){
            var json = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(ConfigPath));
            return json.GetProperty("ApiConstructor").GetProperty(Headers).GetString();
        }
    }
}