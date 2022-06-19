using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PropertyBot.Provider.KSK.Entity;

namespace PropertyBot.Provider.KSK.WebClient
{
    public class KskWebClient : IKskWebClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<KskWebClient> _logger;

        public KskWebClient(ILogger<KskWebClient> logger)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _logger = logger;
        }

        public async Task<IEnumerable<Estate>> GetObjects(KskWebClientOptions options)
        {
            var estates = new List<Estate>();

            var firstPage = await GetPage(options, 1, options.MarketingUsageObjectType);

            estates.AddRange(firstPage.Embedded.Estate);

            for (int page = 2; page <= firstPage.PageCount; page++)
            {
                var pageContent = await GetPage(options, page, options.MarketingUsageObjectType);
                estates.AddRange(pageContent.Embedded.Estate);
            }
            
            return estates;
        }

        public async Task<Root> GetPage(KskWebClientOptions options, int page, string marketingUsageObjectType)
        {
            var resultString = await GetRawPage(options, page, marketingUsageObjectType);
            try
            {
                return JsonSerializer.Deserialize<Root>(resultString);
            }
            catch (JsonException e)
            {
                if (e.Message.Contains("'<' is an invalid start of a value"))
                {
                    // sometimes the KSK doesn't send valid json. This is just ignored as it works mostly the next time
                    return new Root { Embedded = new Embedded { Estate = new List<Estate>() } };
                }
                
                _logger.LogCritical($"Failed to parse JSON:{Environment.NewLine}{resultString}");

                throw;
            }
        }

        private async Task<string> GetRawPage(KskWebClientOptions options, int page, string marketingUsageObjectType)
        {
            var url = "https://www.kskbb.de/content/myif/ksk-boeblingen/work/filiale/de/home/misc/vps/gate/_jcr_content.bin/sip/api";
            using var request = new HttpRequestMessage(new HttpMethod("POST"), url);
            request.Content = new StringContent(
                $"{{\"route\":\"estate\",\"page\":\"{page}\",\"zip_city_estate_id\":\"{options.Zip}\",\"marketing_usage_object_type\":\"{marketingUsageObjectType}\",\"perimeter\":\"{options.RadiusInKm}\",\"sort_by\":\"distance_asc\",\"limit\":\"{options.Limit}\",\"regio_client_id\":\"{options.RegioClientId}\",\"return_data\":\"overview\"}}");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            try {
                var result = await _client.SendAsync(request);
                var resultString = await result.Content.ReadAsStringAsync();

                if (resultString.StartsWith("{\"pending"))
                {
                    return await GetRawPage(options, page, marketingUsageObjectType);
                }
                return resultString;
            } catch (Exception e) {
                throw new Exception($"Failed to get {url}", e);
            }
        }
    }
}
