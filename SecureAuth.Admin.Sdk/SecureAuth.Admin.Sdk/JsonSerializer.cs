using Newtonsoft.Json;

namespace SecureAuth.Admin.Sdk
{
    internal static class JsonSerializer
    {
        internal static string Serialize(object model)
        {            
            string jsonString = JsonConvert.SerializeObject(model);

            return jsonString;
        }

        internal static T Deserialize<T>(string jsonString)
        {   
            T obj = JsonConvert.DeserializeObject<T>(jsonString);

            return obj;
        }
    }
}