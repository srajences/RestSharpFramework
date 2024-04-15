using System.Text.Json;

public class jsonRequestIndentator
{
    public static string jsonFormatter(string response){
            var options = new JsonSerializerOptions{WriteIndented = true};
            var formattedResponse = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(response),options);
            return formattedResponse;
    }
}