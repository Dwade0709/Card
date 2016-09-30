using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Client.Core;
using Core.Interfaces;

namespace Server.Core
{
    public class ServerInfo : IServerInfoParams
    {
        public ServerInfo()
        {
            ServerVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Assemblies = new List<Assembly>();
            foreach (var file in Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Where(p => Path.GetExtension(p) == ".dll"))
                Assemblies.Add(Assembly.LoadFile(file));
        }

        public ServerInfo(string adress)
        {
            ServerAdress = adress;
        }

        public IParametr<IServerInfoParams> CreateParameter()
        {
            return this;
        }

        public IServerInfoParams Instance => this.Instance;

        public string ServerVersion { get; set; }

        public string ServerAdress { get; set; }

        public IList<Assembly> Assemblies;
    }
}
