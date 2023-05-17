using ProtoBuf.Meta;
using System.IO;

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
        public static T Deserialaze<T>(Stream stream, TypeModel model)
        {
            object obj = null;
            return (T)model.Deserialize(stream, obj, typeof(T));
        }

        /// <summary>
        /// Serialaze object
        /// </summary>
        /// <param name="package">Object to serialization</param>
        public static byte[] Serialaze(object package, TypeModel model)
        {

            if (package == null)
                return null;
            using (var ms = new MemoryStream())
            {
                //ProtoBuf.Serializer.Serialize(ms, package);
                model.Serialize(ms, package);
                return ms.ToArray();
            }
        }
    }
}
