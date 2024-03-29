﻿using System;
using Server.Core;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using Client.Core;
using Core;
using Core.Interfaces;
using Core.Package;

namespace Server.TCP
{
    internal class ServerTcp : AServer
    {
        private TcpListener _listener;

        /// <summary>
        /// Start
        /// </summary>
        public override void StartServer()
        {
            try
            {
                _listener = new TcpListener(Adress.IpAdress, Adress.Port);
                LoggerService.Trace("Starting TCP server");
                _listener.Start();
                LoggerService.Trace($"Start TCP server on {Adress.IpAdress} port {Adress.Port}");
                while (true)
                {
                    try
                    {
                        var client = _listener.AcceptTcpClientAsync();
                        var tcpClient = ServiceContainer.Instance.Get<IClient>();
                        ((ITransport<TcpClient>)tcpClient).Client = client.Result;


                        tcpClient.Id = Guid.NewGuid();
                        IServerClient<AServer, IClient> clientObject = ServerClientTcp.CreateClient(this, tcpClient);


                        //Command for presentation 
                        //var command = ServiceContainer.Instance.Get<ICommandManager>().GetCommand("PresentServerCommand");
                        //var param = ServiceContainer.Instance.Get<ServerInfoParam>();
                        //param.ClientGuid = tcpClient.Id;
                        //command.SetParametr(param);
                        //var package = PackageFactory.GetFactory<IShortPackage>().Create(clientObject.Client.Id, command);

                        //((ITransport<TcpClient>)tcpClient).SendData(package);

                        Thread clientThread = new Thread(ServerListener);
                        clientThread.Start(clientObject);
                    }
                    catch (Exception ex)
                    {
                        LoggerService.Error(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.Error(ex);
            }
        }

        public override void StopServer()
        {
            foreach (var client in Clients)
            {
                client.Disconnect();

            }
            if (_listener != null)
            {
                _listener.Stop();
                LoggerService.Trace("Stop TCP server");
                Thread.Sleep(10000);
            }
        }

        private void ServerListener(object client)
        {
            ((IServerClient<AServer, IClient>)client).Client.ClientListener(false);
        }
    }
}
