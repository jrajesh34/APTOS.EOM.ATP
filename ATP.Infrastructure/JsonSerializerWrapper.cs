using System.IO;
using ATP.Infrastructure.Interfaces;
using Newtonsoft.Json;

namespace ATP.Infrastructure
{
    public class JsonSerializerWrapper : IJsonSerializerWrapper
    {
        /// <inheritdoc />
        public string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <inheritdoc />
        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <inheritdoc />
        public void SerializeToFile(string filepath, object data)
        {
            using (var writer = new StreamWriter(filepath, false))
            {
                var serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                };
                serializer.Serialize(writer, data);
                writer.WriteLine();
            }
        }
    }
}
