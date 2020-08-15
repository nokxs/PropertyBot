using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PropertyBot.Provider.VolksbankStuttgart.Entity;

namespace PropertyBot.Provider.VolksbankStuttgart.WebClient
{
    internal class VolksbankWebClient : IVolksbankWebClient
    {
        private readonly HttpClient _client;

        public VolksbankWebClient()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<VolksbankProperty>> GetObjects(VolksbankWebClientOptions options)
        {
            var resultString = await GetRawPage(options);
            var properties = ParseHtml(resultString);
            return properties;
        }

        private async Task<string> GetRawPage(VolksbankWebClientOptions options)
        {
            var content = new Dictionary<string, string>
            {
                {"kdnr", options.CustomerId.ToString()},
                {"version", "3"},
                {"pageSize", options.Limit.ToString()},
                {"pageIndex", "0"},
                {"objkat", options.ObjectCategory.ToString()}, // house
                {"geosl", options.GeoSl},
                {"umkreis", options.GeoSlRadiusSearch.ToString()},
                {"sortOrder", "0_1"}
            };

            var result = await _client.PostAsync("https://cs.immopool.de/CS/getListe", new FormUrlEncodedContent(content));
            return await result.Content.ReadAsStringAsync();
        }

        private IEnumerable<VolksbankProperty> ParseHtml(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var propertyNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'list-row-wrap')]");
            var properties = propertyNodes.Select(ConvertToProperty).ToList();

            return properties;
        }

        private VolksbankProperty ConvertToProperty(HtmlNode node)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(node.InnerHtml);

            return new VolksbankProperty(
                GetDescription(htmlDoc.DocumentNode),
                GetType(htmlDoc.DocumentNode),
                GetLocation(htmlDoc.DocumentNode),
                GetPrice(htmlDoc.DocumentNode),
                GetRoomCount(htmlDoc.DocumentNode),
                GetLivingArea(htmlDoc.DocumentNode),
                GetPropertyArea(htmlDoc.DocumentNode),
                GetImageUri(htmlDoc.DocumentNode));
        }

        private string GetDescription(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//h2[contains(@class, 'list3-cont-highl')]");
            return descriptionNode?.InnerText ?? string.Empty;
        }

        private string GetType(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'list3-cont-objart')]");
            return descriptionNode?.InnerText ?? string.Empty;
        }

        private string GetLocation(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'list3-cont-ort')]");
            return descriptionNode?.InnerText ?? string.Empty;
        }

        private int GetPrice(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'price')]/div[contains(@class, 'val')]/strong");
            var priceString = (descriptionNode?.InnerText ?? string.Empty).Replace(".", string.Empty);
            return parseAsIntSafe(priceString);
        }

        private int GetLivingArea(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'rooms')]/div[contains(@class, 'val')]");
            return parseAsIntSafe(descriptionNode?.InnerText ?? string.Empty);
        }

        private int GetRoomCount(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'rooms')]/div[contains(@class, 'val')]");
            return parseAsIntSafe(descriptionNode?.InnerText ?? string.Empty);
        }

        private int GetPropertyArea(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'alt')]/div[contains(@class, 'val')]");
            return parseAsIntSafe(descriptionNode?.InnerText ?? string.Empty);
        }

        private Uri GetImageUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//img[contains(@class, 'list3-image')]");
            var imageUriString = imageNode?.Attributes.First(attribute => attribute.Name == "src")?.Value ?? "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png"; 
            return new Uri(imageUriString);
        }

        private int parseAsIntSafe(string intAsString)
        {
            return int.TryParse(intAsString, out var parsedResult) ? parsedResult : 0;
        }
    }
}
