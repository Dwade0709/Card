using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Client.Core;

namespace Core.Command.Command.Param
{
    [Serializable]
    public class ServerInfoParam : AParametr<ServerInfoParam>, IServerInfoParams
    {
        public ServerInfoParam(string adress, string version)
        {
            ServerAdress = adress;
            ServerVersion = version;
        }

        public ServerInfoParam()
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
