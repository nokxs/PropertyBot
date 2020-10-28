using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoscoutLists.Converter;
using PropertyBot.Provider.ImmoscoutLists.WebClient;

namespace PropertyBot.Provider.ImmoscoutLists
{
    internal class ImmoscoutListClient : IPropertyProvider
    {
        private readonly IImmoscoutListWebClient _webClient;
        private readonly IImmoscoutListConverter _immoscoutListConverter;

        internal ImmoscoutListClient(IImmoscoutListWebClient webClient, IImmoscoutListConverter immoscoutListConverter)
        {
            _webClient = webClient;
            _immoscoutListConverter = immoscoutListConverter;
        }

        public string Name { get; } = "Immoscout List";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var ids = EnvironmentConstants.PROVIDER_IMMOSCOUT_LIST_IDS.GetAsMandatoryEnvironmentVariableList().ToList();
            var properties = new List<Property>();

            foreach (var id in ids)
            {
                var webClientOptions = new ImmoscoutListWebClientOptions(id);
                var immoscoutListProperties = await _webClient.GetObjects(webClientOptions);

                properties.AddRange(_immoscoutListConverter.ToProperties(immoscoutListProperties));
            }

            return properties;
        }
    }
}
