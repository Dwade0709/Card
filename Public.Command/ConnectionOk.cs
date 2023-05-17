using Core;
using Core.Command;
using Core.Services;

namespace Public.Command
{
    internal class ConnectionOk : ACommand
    {
        public override void Execute()
        {
            ServiceContainer.Instance.Get<ILoggerService>().Trace("Version is enabled");
        }
    }
}