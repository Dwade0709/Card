﻿using Client.Core;
using System.Net.Sockets;
using Core.TCP;
using System;
using System.Reflection;
using Core.Interfaces;
using Core.Package;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Command;
using Core.Services;

namespace Client.TCP
{
    public class ClientTcp : TransportTcp, IClient
    {
        private Guid _id;

        private int _i;

        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                    _id = Guid.NewGuid();
                return _id;
            }
            set { _id = value; }
        }

        public Version ClientVersion
        {
            get { return Assembly.GetEntryAssembly().GetName().Version; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        public void Disconnect()
        {
            Client?.Dispose();
        }

        public bool Connect(string ip, int port)
        {

            try
            {
                var tcpClient = new TcpClient();
                tcpClient.ConnectAsync(ip, port);
                Client = tcpClient;
                if (tcpClient.Connected)
                {
                    var dynParam = new DynamicParam();
                    //TODO SOME problems with serialazible objects
                    dynParam.SetValue("clientVersion", ClientVersion.ToString());
                    Transport<TcpClient>().SendData(PackageFactory.GetFactory<ICommandPackage>().Create(Id, Guid.NewGuid(), true, false, ECommandType.ConnectionNewClient, dynParam));
                    Logger.Trace($"Client {Id} was connected");
                    return true;
                }
                Logger.Trace($"Server unavaliable");
                _i++;
                if (_i < 5)
                    Reconnect(ip, port);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Logger.Trace(ex.Message);
                return false;
            }
        }

        public void ClientListener(object stopError)
        {
            while (true)
            {
                try
                {
                    Type obj;
                    var package = ReceiveData(out obj);
                    if (package == null) continue;
                    if (obj == typeof(IBasePackage))
                    {
                        //((IBasePackage)package).Command?.Execute();
                    }
                    if (obj == typeof(IShortPackage))
                        ((IShortPackage)package).Command?.Execute();
                    if (obj == typeof(ICommandPackage))
                    {
                        var command = ServiceContainer.Instance.Get<ICommandManager>().GetCommand(((ICommandPackage)package).Type.ToString());
                        command.SetParametr(((ICommandPackage)package).Params);
                        command.ClientId = this.Id;
                        if (((ICommandPackage)package).IsAsync)
                            Task.Run(() => command.Execute());
                        else
                            command.Execute();
                    }
                }
                catch (Exception ex)
                {
                    ServiceContainer.Instance.Get<ILoggerService>().Error(ex);
                    if ((bool)stopError)
                        break;
                }
            }
        }

        public ITransport<TCpClient> Transport<TCpClient>()
        {
            return (ITransport<TCpClient>)this;
        }

        public void Reconnect(string ip, int port)
        {
            Logger.Trace("Try reconecting...");
            Thread.Sleep(new TimeSpan(0, 0, 0, 5));
            Connect(ip, port);
        }
    }
}
