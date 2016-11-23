using Core.Command;
using Core.Interfaces;
using Core.Package;
using ProtoBuf.Meta;
using System;
using System.Reflection;

namespace Core.TCP
{
    public static class SerialazeMapping
    {
        public static TypeModel Sheme(Type package)
        {
            var type = TypeModel.Create();
            MetaType metatype = null;
            Type typeShort;

            var assembly = Assembly.Load(new AssemblyName("Core"));

            if (package == typeof(IPackage))
            {
                typeShort = assembly.GetType("Core.Package.Package");
                type.Add(typeof(IPackage), true).AddSubType(90, typeShort);
                metatype = type.Add(typeof(ICommand), true).AddSubType(33, typeof(ACommand));
                metatype = type.Add(typeof(ACommand), true);
                AddCommandTypes(metatype);
                metatype = type.Add(typeof(IParametr), true);
                AddParametrsTypes(metatype);
            }
            if (package == typeof(IShortPackage))
            {
                typeShort = assembly.GetType("Core.Package.ShortPackage");
                metatype = SetBaseStructure(type, typeShort);
            }
            if (package == typeof(ICommandPackage))
            {
                typeShort = assembly.GetType("Core.Package.CommandPackage");
                type.Add(typeof(ICommandPackage), true).AddSubType(90, typeShort);
                AddCommandTypes(metatype);
            }

            return type;
        }

        private static MetaType SetBaseStructure(RuntimeTypeModel type, Type typeShort)
        {
            type.Add(typeof(IShortPackage), true).AddSubType(90, typeShort);
            var metatype = type.Add(typeof(ICommand), true).AddSubType(33, typeof(ACommand));
            metatype = type.Add(typeof(ACommand), true);
            AddCommandTypes(metatype);
            metatype = type.Add(typeof(IParametr), true);
            AddParametrsTypes(metatype);
            return metatype;
        }

        private static void AddParametrsTypes(MetaType model)
        {
            var indexCommand = 1001;

            foreach (var command in Assembly.Load(new AssemblyName("Server.Core")).GetTypes())
                if (command.Namespace.Contains("Serer.Core.Param") && command.GetTypeInfo().MemberType == MemberTypes.TypeInfo)
                {
                    model.AddSubType(indexCommand, command);
                    indexCommand++;
                }

            foreach (var command in Assembly.Load(new AssemblyName("Core.Command")).GetTypes())
                if (command.Namespace.Contains("Core.Command.Command.Param") && command.GetTypeInfo().MemberType == MemberTypes.TypeInfo)
                {
                    model.AddSubType(indexCommand, command);
                    indexCommand++;
                }
        }

        private static void AddCommandTypes(MetaType model)
        {
            var indexCommand = 101;
            foreach (var command in Assembly.Load(new AssemblyName("Server.Core")).GetTypes())
                if (command.FullName.Contains("Server.Core.Command."))
                {
                    model.AddSubType(indexCommand, command);
                    indexCommand++;
                }

            foreach (var command in Assembly.Load(new AssemblyName("Core.Command")).GetTypes())
                if (command.FullName.Contains("Core.Command.Command."))
                {
                    model.AddSubType(indexCommand, command);
                    indexCommand++;
                }
        }
    }
}
