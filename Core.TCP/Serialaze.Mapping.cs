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
            if (package == typeof(IPackage))
            {
                metatype = type.Add(typeof(IPackage), true);
                AddCommandTypes(metatype);
            }
            if (package == typeof(IShortPackage))
            {
                var assembly = Assembly.Load(new AssemblyName("Core"));
                var typeShort =assembly.GetType("Core.Package.ShortPackage");
                type.Add(typeof(IShortPackage), true).AddSubType(90, typeShort);
                metatype = type.Add(typeof(ICommand), true).AddSubType(33, typeof(ACommand));
                metatype = type.Add(typeof(ACommand), true);
                AddCommandTypes(metatype);
                metatype = type.Add(typeof(IParametr), true);
                AddParametrsTypes(metatype);
            }
            if (package == typeof(ICommandPackage))
            {
                AddCommandTypes(metatype);
            }

            return type;
        }

        private static void AddParametrsTypes(MetaType model)
        {
         //   model.AddSubType(1001, typeof(ServerInfoParam));


        }

        private static void AddCommandTypes(MetaType model)
        {
            //model.AddSubType(101, typeof(PresentServerCommand));
            //model.AddSubType(102, typeof(DisconnectCommand));
        }
    }
}
