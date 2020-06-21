namespace Flummery.Plugin
{
    public interface IPlugin
    {
        string Name { get; }

        ICommandDispatcher Commands { get; }

        IPluginHandler PluginHandler { get; }
    }
}
