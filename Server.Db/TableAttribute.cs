using System;

namespace Server.Db
{
    /// <summary>
    /// Table attribute set table name on DB
    /// </summary>
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// .ctor to creation
        /// </summary>
        /// <param name="name">Table name</param>
        public TableAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Table name
        /// </summary>
        public string Name { get; }
    }
}
