using Core.Command;
using Core.Helper;
using Newtonsoft.Json;
using ProtoBuf;
using ProtoBuf.Meta;
using System.IO;
using System.Net.Sockets;
using System.Text;

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
            return Serializer.Deserialize<T>(stream);
            //return JsonConvert.DeserializeObject<T>(Encoding.Unicode.GetString(StreamHelper.ConvertNetworkstreamToArray((NetworkStream)stream)));
        }

        /// <summary>
        /// Serialaze object
        /// </summary>
        /// <param name="package">Object to serialization</param>
        public static byte[] Serialaze(object package)
        {
            if (package == null)
                return null;
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, package);
                return ms.ToArray();
            }
            //return Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(package));
        }
    }
}
