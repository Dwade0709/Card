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
        public Dictionary<string, string> _dict = new Dictionary<string, string>();

        /// <summary>
        /// Setter for field 
        /// </summary>
        /// <param name="key">field name</param>
        /// <param name="obj">field value</param>
        public void SetValue(string key, string obj)
        {
            if (_dict.ContainsKey(key))
                throw new ArgumentException($"Key {key} already added");
            _dict.Add(key, obj);
        }

        public T GetValue<T>(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return value on T type 
        /// </summary>
        /// <typeparam name="T">Type to cast</typeparam>
        /// <param name="key">Key</param>
        /// <returns>T obj from dict</returns>
        public string GetValue(string key)
        {
            string objResult;
            _dict.TryGetValue(key, out objResult);
            if (objResult == null)
                return string.Empty; //default(T);
            return objResult;
        }

        //Creator dynamic parametr
        public static DynamicParam CreateDynamic()
        {
            return new DynamicParam();
        }
    }
}
