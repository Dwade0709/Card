using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Db
{
    /// <summary>
    /// Database name 
    /// </summary>
    public class DatabaseNameAttribute : Attribute
    {
        public DatabaseNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
