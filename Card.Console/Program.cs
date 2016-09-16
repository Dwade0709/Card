﻿using Core;
using Core.Services;
using Game.Interfaces;

namespace Card.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Core.Initialazer.Instance.InitServices();
            var logger = ServiceContainer.Instance.Get<ILoggerService>();
            var playerservice = ServiceContainer.Instance.Get<IPlayerService>();
            var userservice = ServiceContainer.Instance.Get<IUserService>();
            var gameservice = ServiceContainer.Instance.Get<IGamePublic>();
            var user = userservice.CreateUser("Name","Login");
            var player = playerservice.CreatePlayer(user);
            var game =gameservice.InitGame();
            gameservice.AddPlayer(game, player);
            gameservice.TakeCard(game);


            System.Console.ReadKey();
        }
    }
}
