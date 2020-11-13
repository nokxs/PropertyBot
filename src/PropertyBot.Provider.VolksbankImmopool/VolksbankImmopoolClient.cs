using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankImmopool.Converter;
using PropertyBot.Provider.VolksbankImmopool.WebClient;

namespace PropertyBot.Provider.VolksbankImmopool
{
    internal class VolksbankImmopoolClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _volksbankConverter;
        private readonly SettingsReader<VolksbankWebClientOptions> _settingsReader;

        internal VolksbankImmopoolClient(IVolksbankWebClient webClient, IVolksbankConverter volksbankConverter, SettingsReader<VolksbankWebClientOptions> settingsReader)
        {
            _webClient = webClient;
            _volksbankConverter = volksbankConverter;
            _settingsReader = settingsReader;
        }

        public string Name { get; } = "Volksbank (Immopool)";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/VolksbankImmopool.yml");

            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var volksbankProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_volksbankConverter.ToProperties(volksbankProperties));
            }

            return properties;
        }
    }
}
