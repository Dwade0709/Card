using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Client.Core;
using Core.Command;
using Core.Interfaces;

namespace Server.Core.Command.Param
{
    public class ServerInfo : AParametr<ServerInfo>, IServerInfoParams
    {
        public ServerInfo()
        {
            ServerVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Assemblies = new List<Assembly>();
            foreach (var file in Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Where(p => Path.GetExtension(p) == ".dll"))
                Assemblies.Add(Assembly.LoadFile(file));
        }

        public string ServerVersion { get; set; }

        public string ServerAdress { get; set; }

        public IList<Assembly> Assemblies;
    }
}
