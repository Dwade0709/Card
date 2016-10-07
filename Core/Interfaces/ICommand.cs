namespace Core.Interfaces
{
    /// <summary>
    /// Interface for command. All 
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executor for implemented command
        /// </summary>
        void Execute();

        /// <summary>
        /// Set parametrs to 
        /// </summary>
        /// <param name="parametrs"></param>
        void SetParametr(IParametr parametrs);
    }
}
