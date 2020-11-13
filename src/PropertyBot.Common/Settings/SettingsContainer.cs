using System.Collections.Generic;

namespace PropertyBot.Common.Settings
{
    public class SettingsContainer<TSetting>
    {
        public IEnumerable<TSetting> Settings { get; set; }
    }
}