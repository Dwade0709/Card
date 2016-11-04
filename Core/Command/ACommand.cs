using System;
using Core.Interfaces;
using ProtoBuf;
using ProtoBuf.Meta;

namespace Core.Command
{
    /// <summary>
    /// Command class
    /// </summary>
    /// <typeparam name="T">Type parameter</typeparam>
    [ProtoContract]
    public abstract class ACommand : ICommand//here T : class
    {
        private Action<IParametr> _command;

        [ProtoMember(1)]
        protected IParametr Parametrs;

        /// <summary>
        ///  .ctor
        /// </summary>
        /// <param name="command"></param>
        /// <param name="param"></param>
        protected ACommand(Action<IParametr> command, IParametr param)
        {
            _command = command;
            Parametrs = param;
        }

        protected ACommand(Action<IParametr> command)
        {
            _command = command;
        }


        protected ACommand(IParametr param)
        {
            Parametrs = param;
        }


        protected RuntimeTypeModel _ProtobufSerializer;

        protected ACommand()
        {
            //_ProtobufSerializer = TypeModel.Create();
            //var obj = _ProtobufSerializer.Add(typeof(ACommand), true);
            //_ProtobufSerializer.Add(typeof(T), true);
            //obj.AddSubType(110, typeof(T));

        }

        /// <summary>
        /// Execute 
        /// </summary>
        public virtual void Execute()
        {
            _command.Invoke(Parametrs);
        }

        public void SetParametr(IParametr parametrs)
        {
            Parametrs = parametrs;
        }

        public void SetAction(Action<IParametr> command)
        {
            _command = command;
        }
    }
}
