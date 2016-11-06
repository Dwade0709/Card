using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Client.Core;
using Core.Command;
using ProtoBuf;
using Core.Interfaces;

namespace Serer.Core.Command.Param
{
    [ProtoContract]
    public class ServerInfoParam : AParametr<ServerInfoParam>, IServerInfoParams, IParametr
    {
        public ServerInfoParam() { }

        public ServerInfoParam(string adress, string version)
        {
            ServerAdress = adress;
            ServerVersion = version;
        }

        public ServerInfoParam(bool loadAssembly = false)
        {
            if (loadAssembly)
            {
                LoadAssemblies();
            }
        }

        private void LoadAssemblies()
        {
            ServerVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            Assemblies = new List<string>();
            foreach (var file in Directory.GetFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).Where(p => Path.GetExtension(p) == ".dll"))
                if (!file.Contains("Server.Run"))
                    Assemblies.Add(Assembly.Load(new AssemblyName(Path.GetFileName(file).Replace(".dll", ""))).ToString());
        }

        [ProtoMember(1)]
        public string ServerVersion { get; set; }

        [ProtoMember(2)]
        public string ServerAdress { get; set; }

        [ProtoMember(3)]
        public Guid ClientGuid { get; set; }

        [ProtoIgnore]
        public IList<string> Assemblies;
    }
}
