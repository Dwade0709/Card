using System;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Class for generation random object
    /// </summary>
    internal class Randomizer : IRandomizer
    {
        /// <summary>
        /// Get random GUID
        /// </summary>
        /// <returns>New GUI</returns>
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// Get random value from range
        /// </summary>
        /// <param name="from">Start value. Default-0</param>
        /// <param name="to">Finished value. Default-2147483647</param>
        /// <returns>Random integer</returns>
        public int GetRandomInt(int from = 0, int to = int.MaxValue)
        {
            var random = new Random();
            return random.Next(from, to);
        }

        /// <summary>
        /// Get random object from list
        /// </summary>
        /// <typeparam name="T">Type of return object</typeparam>
        /// <param name="data">List object type T.</param>
        /// <returns>Exist object form list</returns>
        public T GetRandomObject<T>(IList<T> data)
        {
            if (data == null)
                throw new ArgumentNullException("Randomizer list data");
            return (T)data[GetRandomInt(0, data.Count)];
        }
    }
}
