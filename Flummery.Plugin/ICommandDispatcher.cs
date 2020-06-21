namespace Flummery.Plugin
{
    public interface ICommandDispatcher
    {
        void Register(string key, ICommand command);
        O Execute<I, O>(string key, I args);
        O Execute<O>(string key);

        bool CanExecute(string key);
    }
}
