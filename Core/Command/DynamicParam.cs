using System;
using System.Collections.Generic;
using Core.Interfaces;
using ProtoBuf;

namespace Core.Command
{
    /// <summary>
    /// Dynamic parametr. It's dict with value 
    /// </summary>
    [ProtoContract]
    public sealed class DynamicParam : IParametr
    {
        //Storage for values
        [ProtoMember(99)]
        // ReSharper disable once InconsistentNaming
        public Dictionary<string, object> _dict = new Dictionary<string, object>();

        /// <summary>
        /// Setter for field 
        /// </summary>
        /// <param name="key">field name</param>
        /// <param name="obj">field value</param>
        public void SetValue(string key, object obj)
        {
            if (_dict.ContainsKey(key))
                throw new ArgumentException($"Key {key} already added");
            _dict.Add(key, obj);
        }

        /// <summary>
        /// Return value on T type 
        /// </summary>
        /// <typeparam name="T">Type to cast</typeparam>
        /// <param name="key">Key</param>
        /// <returns>T obj from dict</returns>
        public T GetValue<T>(string key)
        {
            object objResult;
            _dict.TryGetValue(key, out objResult);
            if (objResult == null)
                return default(T);
            return (T)objResult;
        }

        //Creator dynamic parametr
        public static DynamicParam CreateDynamic()
        {
            return new DynamicParam();
        }
    }
}
