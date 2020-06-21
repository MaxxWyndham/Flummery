using System;

namespace Flummery.Plugin
{
    public class PluginCommand<InType, OutType> : ICommand
    {
        private Func<InType, OutType> paramAction;

        public PluginCommand(Func<InType, OutType> paramAction)
        {
            this.paramAction = paramAction;
        }

        public OutType Execute(InType param)
        {
            if (paramAction != null)
            {
                return paramAction.Invoke(param);
            }
            else
            {
                return default(OutType);
            }
        }
    }

    public class PluginCommand<OutType> : ICommand
    {
        private Func<OutType> action;

        public PluginCommand(Func<OutType> action)
        {
            this.action = action;
        }

        public OutType Execute()
        {
            if (action != null)
            {
                return action.Invoke();
            }
            else
            {
                return default(OutType);
            }
        }
    }
}