﻿using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using Core.Helper;
using Core.Interfaces;
using Core.Package;
using Core.Services;

namespace Core.TCP
{
    /// <summary>
    /// TCP realization transport layer
    /// </summary>
    public abstract class TransportTcp : ITransport<TcpClient>
    {
        protected readonly ILoggerService Logger;

        protected TransportTcp()
        {
            Logger = ServiceContainer.Instance.Get<ILoggerService>();
        }

        public TcpClient Client { get; set; }

        /// <summary>
        /// Receive data. Read stream and return deserialaze object
        /// </summary>
        public object ReceiveData(out Type obj)
        {
            obj = typeof(object);
            try
            {
                var stream = Client.GetStream();
                if (stream.DataAvailable)
                {
                    Client.ReceiveTimeout = 20;
                    byte[] byteData = StreamHelper.ConvertNetworkstreamToArray(stream);

                    //Check type of package 1-IPackage 2-IShortPackage 3-ICommandPackage
                    if (byteData[0] == 1)
                    {
                        obj = typeof(IBasePackage);
                        return SerialazerHelper.Deserialaze<IBasePackage>(new MemoryStream(byteData.Skip(1).ToArray()), SerialazeMapping.Sheme(typeof(IBasePackage)));
                    }
                    if (byteData[0] == 2)
                    {
                        obj = typeof(IShortPackage);
                        return SerialazerHelper.Deserialaze<IShortPackage>(new MemoryStream(byteData.Skip(1).ToArray()), SerialazeMapping.Sheme(typeof(IShortPackage)));
                    }
                    if (byteData[0] == 3)
                    {
                        obj = typeof(ICommandPackage);
                        return SerialazerHelper.Deserialaze<ICommandPackage>(new MemoryStream(byteData.Skip(1).ToArray()), SerialazeMapping.Sheme(typeof(ICommandPackage)));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Logger.Trace("Connection close");
                //Client?.Close();
            }
            return null;
        }

        public void SendData(ICommandPackage pack)
        {
            SendData<ICommandPackage>(pack);
        }

        public void SendData(IShortPackage pack)
        {
            SendData<IShortPackage>(pack);
        }

        public void SendData(IBasePackage pack)
        {
            SendData<IBasePackage>(pack);
        }

        private void SendData<T>(T pack)
        {

            var data = SerialazerHelper.Serialaze(pack, SerialazeMapping.Sheme(typeof(T)));
            var stream = Client.GetStream();
            var byteData = new byte[data.Length + 1];

            //add to bits at start. 1-IPackage 2-IShortPackage 3-ICommandPackage
            if (typeof(T) == typeof(IBasePackage))
                byteData[0] = 1;
            else if (typeof(T) == typeof(IShortPackage))
                byteData[0] = 2;
            else if (typeof(T) == typeof(ICommandPackage))
                byteData[0] = 3;
            Array.Copy(data, 0, byteData, 1, data.Length);
            stream.Write(byteData, 0, byteData.Length);
        }
    }
}
