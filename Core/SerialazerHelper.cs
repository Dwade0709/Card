using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    /// <summary>
    /// Helper for work binary serialization and deserialization
    /// </summary>
    public static class SerialazerHelper
    {
        /// <summary>
        /// Deserialaze
        /// </summary>
        /// <typeparam name="T">Return type object</typeparam>
        /// <param name="stream">Stream to deserialization</param>
        public static T Deserialaze<T>(Stream stream)
        {
            var formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }

        /// <summary>
        /// Serialaze object
        /// </summary>
        /// <param name="package">Object to serialization</param>
        public static byte[] Serialaze(object package)
        {
            if (package == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, package);
                return ms.ToArray();
            }
        }
    }
}
