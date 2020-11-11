using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.Immoscout.Converter;
using PropertyBot.Provider.Immoscout.WebClient;

namespace PropertyBot.Provider.Immoscout
{
    internal class ImmoscoutClient : IPropertyProvider
    {
        private readonly IImmoscoutWebClient _webClient;
        private readonly IImmoscoutConverter _immoscoutConverter;
        private readonly SettingsReader<ImmoscoutWebClientOptions> _settingsReader;

        private readonly IDictionary<ImmoscoutWebClientOptions, int> _optionsToLastPageDictionary = new Dictionary<ImmoscoutWebClientOptions, int>();
        private ImmoscoutWebClientOptions _lastUsedOptions;

        internal ImmoscoutClient(IImmoscoutWebClient webClient, IImmoscoutConverter immoscoutConverter, SettingsReader<ImmoscoutWebClientOptions> settingsReader)
        {
            _webClient = webClient;
            _immoscoutConverter = immoscoutConverter;
            _settingsReader = settingsReader;
        }

        public string Name { get; } = "Immobilienscout24";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/Immobilienscout24.yml");

            var optionToUse = GetOptionsToUse(settingsContainer.Settings);
            var result = await _webClient.GetObjects(optionToUse.options, optionToUse.page);

            _optionsToLastPageDictionary[optionToUse.options] = result.NextPageNumber;
            _lastUsedOptions = optionToUse.options;

            return _immoscoutConverter.ToProperties(result.ImmoscoutProperties);
        }

        private (ImmoscoutWebClientOptions options, int page) GetOptionsToUse(IEnumerable<ImmoscoutWebClientOptions> settings)
        {
            if (_optionsToLastPageDictionary.Any())
            {
                var nextOption = GetNextOption();
                return (nextOption.Key, nextOption.Value);
            }

            return (settings.First(), 1);
        }

        private KeyValuePair<ImmoscoutWebClientOptions, int> GetNextOption()
        {
            var remainingOptions = _optionsToLastPageDictionary.SkipWhile(kv => kv.Key != _lastUsedOptions).ToList();

            if (remainingOptions.Any() && remainingOptions.Count() == 1)
            {
                // Element was last element in list
                return _optionsToLastPageDictionary.First();
            }

            return remainingOptions.ElementAt(1);
        }
    }
}
