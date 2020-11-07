using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using PropertyBot.Provider.Immoscout.Entity;

namespace PropertyBot.Provider.Immoscout.WebClient
{
    internal class ImmoscoutWebClient : IImmoscoutWebClient
    {
        private readonly HttpClient _client;

        public ImmoscoutWebClient()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<ImmoscoutProperty>> GetObjects(ImmoscoutWebClientOptions options)
        {
            var rawPage = await GetRawPage(options.ListId);
            return ParseHtml(rawPage);
        }

        private async Task<string> GetRawPage(string listId)
        {
            return await _client.GetStringAsync($"https://portal.immobilienscout24.de/ergebnisliste/{listId}");
        }

        private IEnumerable<ImmoscoutProperty> ParseHtml(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var propertyNodes = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'result__list--element')]");

            return propertyNodes?.Select(ConvertToProperty).ToList() ?? Enumerable.Empty<ImmoscoutProperty>();
        }

        private ImmoscoutProperty ConvertToProperty(HtmlNode node)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(node.OuterHtml);

            return new ImmoscoutProperty(
                GetId(htmlDoc.DocumentNode),
                GetDescription(htmlDoc.DocumentNode),
                GetLocation(htmlDoc.DocumentNode),
                GetPrice(htmlDoc.DocumentNode),
                GetRoomCount(htmlDoc.DocumentNode),
                GetLivingArea(htmlDoc.DocumentNode),
                GetImageUri(htmlDoc.DocumentNode),
                GetDetailsUri(htmlDoc.DocumentNode));
        }

        private string GetId(HtmlNode node)
        {
            var linkNode = node.SelectSingleNode("//figure[contains(@class, 'result__list__element--image')]/a");
            var link = linkNode?.Attributes.First(attribute => attribute.Name == "href").Value;
            var splitted = link.Split("/");
            return $"immoscout_{splitted[3]}";
        }

        private string GetDescription(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//h3[contains(@class, 'result__list__element__infos--figcaption')]/a");
            return HttpUtility.HtmlDecode(descriptionNode?.InnerText.Replace("\n", string.Empty).Replace("\t", string.Empty) ?? string.Empty);
        }

        private string GetLocation(HtmlNode node)
        {
            var locationNode = node.SelectSingleNode("//div[contains(@class, 'result__list__element__infos--location')]/p");
            return locationNode?.InnerText ?? string.Empty;
        }

        private int GetPrice(HtmlNode node)
        {
            var infoNodes = node.SelectNodes("//ul[contains(@class, 'result__list__element__infos--list')]/li");
            var priceListElementNode = infoNodes.SingleOrDefault(n => n.InnerText.Contains("preis"));
            var priceNode = priceListElementNode?.ChildNodes.Single(n => n.Name == "span");
            return (priceNode?.InnerText.Replace("&euro;", string.Empty) ?? string.Empty).ToIntSafe();
        }

        private double GetLivingArea(HtmlNode node)
        {
            var infoNodes = node.SelectNodes("//ul[contains(@class, 'result__list__element__infos--list')]/li");
            var priceListElementNode = infoNodes.SingleOrDefault(n => n.InnerText.Contains("Wohn"));
            var livingAreaNode = priceListElementNode?.ChildNodes.Single(n => n.Name == "span");
            return (livingAreaNode?.InnerText.Replace("m&sup2;", string.Empty) ?? string.Empty).ToIntSafe();
        }

        private double GetRoomCount(HtmlNode node)
        {
            var infoNodes = node.SelectNodes("//ul[contains(@class, 'result__list__element__infos--list')]/li");
            var priceListElementNode = infoNodes.SingleOrDefault(n => n.InnerText.Contains("Zimmer"));
            var roomCountNode = priceListElementNode?.ChildNodes.Single(n => n.Name == "span");
            return (roomCountNode?.InnerText ?? string.Empty).ToDoubleSafe();
        }

        private Uri GetImageUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//figure[contains(@class, 'result__list__element--image')]/a/img");
            var imageUriString = imageNode?.Attributes.First(attribute => attribute.Name == "src")?.Value ?? "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png";
            return new Uri($"https:{imageUriString}");
        }

        private Uri GetDetailsUri(HtmlNode node)
        {
            var linkNode = node.SelectSingleNode("//figure[contains(@class, 'result__list__element--image')]/a");
            var uri = linkNode?.Attributes.First(attribute => attribute.Name == "href").Value ?? string.Empty;
            return new Uri($"https://portal.immobilienscout24.de{uri}");
        }
    }
}
