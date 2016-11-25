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
            Type typeShort = null;

            var assembly = Assembly.Load(new AssemblyName("Core"));

            if (package == typeof(IPackage))
                typeShort = assembly.GetType("Core.Package.Package");
            if (package == typeof(IShortPackage))
                typeShort = assembly.GetType("Core.Package.ShortPackage");
            if (package == typeof(ICommandPackage))
                typeShort = assembly.GetType("Core.Package.CommandPackage");

            metatype = SetBaseStructure(package, type, typeShort);
            return type;
        }

        private static MetaType SetBaseStructure(Type package, RuntimeTypeModel type, Type typeShort)
        {
            type.Add(package, true).AddSubType(90, typeShort);
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
            model.AddSubType(indexCommand, typeof(DynamicParam));
            indexCommand++;
            try
            {
                foreach (var command in Assembly.Load(new AssemblyName("Server.Core")).GetTypes())
                    if (command.Namespace.Contains("Serer.Core.Param") && command.GetTypeInfo().MemberType == MemberTypes.TypeInfo)
                    {
                        model.AddSubType(indexCommand, command);
                        indexCommand++;
                    }
            }
            catch (Exception ex)
            {

            }
            try
            {
                foreach (var command in Assembly.Load(new AssemblyName("Server.Core.Command")).GetTypes())
                    if (command.Namespace.Contains("Server.Core.Command.Param") && command.GetTypeInfo().MemberType == MemberTypes.TypeInfo)
                    {
                        model.AddSubType(indexCommand, command);
                        indexCommand++;
                    }
            }
            catch (Exception ex)
            {

            }
        }

        private static void AddCommandTypes(MetaType model)
        {
            var indexCommand = 101;
            try
            {
                foreach (var command in Assembly.Load(new AssemblyName("Server.Core")).GetTypes())
                    if (command.FullName.Contains("Server.Core.Command."))
                    {
                        model.AddSubType(indexCommand, command);
                        indexCommand++;
                    }
            }
            catch (Exception ex)
            {

            }
            try
            {
                foreach (var command in Assembly.Load(new AssemblyName("Server.Core.Command")).GetTypes())
                    if (command.FullName.Contains("Server.Core.Command.Command"))
                    {
                        model.AddSubType(indexCommand, command);
                        indexCommand++;
                    }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
