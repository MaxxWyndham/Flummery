using System.Collections.Generic;

namespace Flummery.Plugin
{
    public class PluginCommandDispatcher : ICommandDispatcher
    {
        private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        public void Register(string key, ICommand command)
        {
            commands.Add(key, command);
        }

        public OutType Execute<OutType>(string key)
        {
            if (CanExecute(key))
            {
                PluginCommand<OutType> cmd = (PluginCommand<OutType>)commands[key];
                return cmd.Execute();
            }
            else
            {
                return default(OutType);
            }
        }

        public OutType Execute<InType, OutType>(string key, InType args)
        {
            if (CanExecute(key))
            {
                PluginCommand<InType, OutType> cmd = (PluginCommand<InType, OutType>)commands[key];
                return cmd.Execute(args);
            }
            else
            {
                return default(OutType);
            }
        }

        public bool CanExecute(string key)
        {
            return commands.ContainsKey(key);
        }
    }
}
