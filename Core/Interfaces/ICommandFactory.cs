using System;
using Core.Command;

namespace Core.Interfaces
{
    public interface ICommandFactory<T> where T : class
    {
        ACommand Create(Action<IParametr> command);

        ACommand Create(Action<IParametr> command, IParametr param);

        ACommand Create(IParametr param);

        ACommand Create();
    }
}
