using System;

namespace Server.Service.DataModel
{
    /// <summary>
    /// Data model for validation version. This object describe client version for server 
    /// </summary>
    public class Version
    {
        /// <summary>
        /// Version client 
        /// </summary>
        public string Vers { get; set; }

        /// <summary>
        /// Start date for support
        /// </summary>
        public DateTime StartedTime { get; set; }

        /// <summary>
        /// Is actuAL VERSION
        /// </summary>
        public bool IsActual { get; set; }

        /// <summary>
        /// State for describe PRODUCTION|DEV|TEST
        /// </summary>
        public EVersionState State { get; set; }

    }
}
