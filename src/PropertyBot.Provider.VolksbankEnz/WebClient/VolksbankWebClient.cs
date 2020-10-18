using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PropertyBot.Provider.VolksbankEnz.Entity;

namespace PropertyBot.Provider.VolksbankEnz.WebClient
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
            var properties = new List<VolksbankProperty>();

            for (int i = 0; i < options.CustomerIds.Count(); i++)
            {
                var customerId = options.CustomerIds.Skip(i).First();
                var searchRadius = options.GeoSlRadiusSearch.Skip(i).First();
                var geoSl= options.GeoSls.Skip(i).First();

                var resultString = await GetRawPage(options, customerId, searchRadius, geoSl);
                properties.AddRange(ParseHtml(resultString));
            }

            return properties;
        }

        private async Task<string> GetRawPage(VolksbankWebClientOptions options, int customerId, int searchRadius, string geoSL)
        {
            var content = new Dictionary<string, string>
            {
                {"kdnr", customerId.ToString()},
                {"version", "3"},
                {"pageSize", options.Limit.ToString()},
                {"pageIndex", "0"},
                {"objkat", options.ObjectCategory.ToString()}, // house
                {"geosl", geoSL},
                {"umkreis", searchRadius.ToString()},
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

            return propertyNodes?.Select(ConvertToProperty).ToList() ?? Enumerable.Empty<VolksbankProperty>();
        }

        private VolksbankProperty ConvertToProperty(HtmlNode node)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(node.InnerHtml);

            return new VolksbankProperty(
                GetId(htmlDoc.DocumentNode),
                GetDescription(htmlDoc.DocumentNode),
                GetType(htmlDoc.DocumentNode),
                GetLocation(htmlDoc.DocumentNode),
                GetPrice(htmlDoc.DocumentNode),
                GetRoomCount(htmlDoc.DocumentNode),
                GetLivingArea(htmlDoc.DocumentNode),
                GetPropertyArea(htmlDoc.DocumentNode),
                GetImageUri(htmlDoc.DocumentNode));
        }

        private int GetId(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//a[contains(@class, 'list-expose-link')]");
            return descriptionNode?.Attributes.First(attribute => attribute.Name == "data-id").Value.ToIntSafe() ?? 0;
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
            return priceString.ToIntSafe();
        }

        private double GetLivingArea(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'rooms')]/div[contains(@class, 'val')]");
            return (descriptionNode?.InnerText ?? string.Empty).ToDoubleSafe();
        }

        private double GetRoomCount(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'rooms')]/div[contains(@class, 'val')]");
            return (descriptionNode?.InnerText ?? string.Empty).ToDoubleSafe();
        }

        private double GetPropertyArea(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//div[contains(@class, 'alt')]/div[contains(@class, 'val')]");
            return (descriptionNode?.InnerText ?? string.Empty).ToDoubleSafe();
        }

        private Uri GetImageUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//img[contains(@class, 'list3-image')]");
            var imageUriString = imageNode?.Attributes.First(attribute => attribute.Name == "src")?.Value ?? "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png"; 
            return new Uri(imageUriString);
        }
    }
}
