using Core;
using Core.Command;
using Core.Services;

namespace Client.Core.Command
{
    public class ConnactionOkCommand : ACommand
    {
        public override void Execute()
        {
            ServiceContainer.Instance.Get<IInformService>().ShowInfo(Parametrs.GetValue("result"));
        }
    }
}
