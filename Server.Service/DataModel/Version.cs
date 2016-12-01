using System;

namespace Server.Service.DataModel
{
    public class Version
    {
        public string Vers { get; set; }

        public DateTime StartedTime { get; set; }

        public bool IsActual { get; set; }

        public EVersionState State { get; set; }

    }
}
