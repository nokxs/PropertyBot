using System.Threading.Tasks;

namespace PropertyBot.Common.Settings
{
    public interface ISettingsReader<TSetting>
    {
        Task<SettingsContainer<TSetting>> ReadSettings(string path);
    }
}