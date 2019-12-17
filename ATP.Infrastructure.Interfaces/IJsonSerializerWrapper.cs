namespace ATP.Infrastructure.Interfaces
{
    public interface IJsonSerializerWrapper
    {
        /// <summary>
        /// Serializes the object to a JSON string
        /// </summary>
        /// <param name="data">Object to serialize</param>
        /// <returns></returns>
        string Serialize(object data);

        /// <summary>
        /// JSON string to deserialize into the Type
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="data">Object to serialize</param>
        /// <returns></returns>
        T Deserialize<T>(string data);

        /// <summary>
        /// Serializes the object to a file. If the file does not exist,
        /// it creates it. If the file exists, it overwrites the contents
        /// of the file with the JSON serialization of the object.
        /// </summary>
        /// <param name="filepath">File path and name</param>
        /// <param name="data">Object to serialize</param>
        void SerializeToFile(string filepath, object data);
    }
}
