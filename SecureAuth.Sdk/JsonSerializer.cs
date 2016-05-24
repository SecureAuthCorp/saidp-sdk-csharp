using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SecureAuth.Sdk
{
    internal static class JsonSerializer
    {
        internal static string Serialize(object model)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(model.GetType(), new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true 
            });
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, model);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        internal static T Deserialize<T>(string jsonString)
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), settings);
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}