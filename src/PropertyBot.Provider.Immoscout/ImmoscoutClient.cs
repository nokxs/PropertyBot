using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
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
        private readonly ILogger<ImmoscoutClient> _logger;

        private readonly IDictionary<ImmoscoutWebClientOptions, int> _optionsToLastPageDictionary = new Dictionary<ImmoscoutWebClientOptions, int>();
        private ImmoscoutWebClientOptions _lastUsedOptions;

        public ImmoscoutClient(IImmoscoutWebClient webClient, IImmoscoutConverter immoscoutConverter, SettingsReader<ImmoscoutWebClientOptions> settingsReader, ILogger<ImmoscoutClient> logger)
        {
            _webClient = webClient;
            _immoscoutConverter = immoscoutConverter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "Immobilienscout24";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/Immobilienscout24.yml");

            var optionToUse = GetOptionsToUse(settingsContainer.Settings.ToList());
            var result = await _webClient.GetObjects(optionToUse.options, optionToUse.page);

            _optionsToLastPageDictionary[optionToUse.options] = result.NextPageNumber;
            _lastUsedOptions = optionToUse.options;

            return _immoscoutConverter.ToProperties(result.ImmoscoutProperties);
        }

        private (ImmoscoutWebClientOptions options, int page) GetOptionsToUse(ICollection<ImmoscoutWebClientOptions> settings)
        {
            SynchronizeSettingsWithDict(settings);

            if (_optionsToLastPageDictionary.Any())
            {
                var nextOption = GetNextOption();
                return (nextOption.Key, nextOption.Value);
            }

            return (settings.First(), 1);
        }

        private void SynchronizeSettingsWithDict(ICollection<ImmoscoutWebClientOptions> settings)
        {
            var settingsNotInDict = settings.Where(setting => !_optionsToLastPageDictionary.Keys.Contains(setting));
            foreach (var setting in settingsNotInDict)
            {
                _logger.LogInfo($"Found new setting, which will be added: {setting}");
                _optionsToLastPageDictionary[setting] = 1;
            }

            var settingsOnlyInDict = _optionsToLastPageDictionary.Keys.Where(option => !settings.Contains(option));
            foreach (var setting in settingsOnlyInDict)
            {
                _logger.LogInfo($"Found obsolete setting, which will be removed: {setting}.");
                _optionsToLastPageDictionary.Remove(setting);
            }
        }

        private KeyValuePair<ImmoscoutWebClientOptions, int> GetNextOption()
        {
            var remainingOptions = _optionsToLastPageDictionary.SkipWhile(kv => kv.Key != _lastUsedOptions).ToList();

            if (remainingOptions.Count > 1)
            {
                return remainingOptions.ElementAt(1);
            }

            // Element was last element in list or the last used option is not found
            return _optionsToLastPageDictionary.First();
        }
    }
}
