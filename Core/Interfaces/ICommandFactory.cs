using System;
using Core.Command;

namespace Core.Interfaces
{
    public interface ICommandFactory<T> where T : class
    {
        ACommand<T> Create(Action<IParametr> command);

        ACommand<T> Create(Action<IParametr> command, IParametr param);

        ACommand<T> Create(IParametr param);
    }
}
