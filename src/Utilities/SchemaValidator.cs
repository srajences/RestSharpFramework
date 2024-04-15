using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

public class SchemaValidator
{
    public static bool validateSchema(string jsonResponse, string schemaJson){
        var schema = JSchema.Parse(schemaJson);
        var jObject = JObject.Parse(jsonResponse);
        var validateSchema = jObject.IsValid(schema);
        return validateSchema;
    }
}