using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PropertyBot.Common.Extensions;
using PropertyBot.Provider.OhneMakler.Entity;

namespace PropertyBot.Provider.OhneMakler.WebClient
{
    internal class OhneMaklerWebClient : IOhneMaklerWebClient
    {
        private readonly HttpClient _client;

        public OhneMaklerWebClient()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<OhneMaklerProperty>> GetObjects(OhneMaklerClientOptions options)
        {
            var properties = new List<OhneMaklerProperty>();

            var rawPage = await GetRawPage(options, 1);
            var pageCount = GetPageCount(rawPage);
            properties.AddRange(ParseHtml(rawPage));

            for (int pageNr = 2; pageNr <= pageCount; pageNr++)
            {
                rawPage = await GetRawPage(options, pageNr);
                properties.AddRange(ParseHtml(rawPage));
            }

            return properties;
        }

        private async Task<string> GetRawPage(OhneMaklerClientOptions options, int pageNr)
        {
            return await _client.GetStringAsync($"https://www.ohne-makler.net/immobilie/list/?page={pageNr}&class={options.ObjectType}&marketing={options.MarketingType}&q={options.Location}&radius={options.Radius}&state={options.StateId}");
        }

        private IEnumerable<OhneMaklerProperty> ParseHtml(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var propertyNodes = htmlDoc.DocumentNode.SelectNodes("//table[contains(@class, 'table')]/tr");

            return propertyNodes?.Where(node => node.ChildNodes.Count == 7).Select(ConvertToProperty).ToList() ?? Enumerable.Empty<OhneMaklerProperty>();
        }

        private OhneMaklerProperty ConvertToProperty(HtmlNode node)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(node.OuterHtml);

            return new OhneMaklerProperty(
                GetId(htmlDoc.DocumentNode),
                GetDescription(htmlDoc.DocumentNode),
                GetType(htmlDoc.DocumentNode),
                GetLocation(htmlDoc.DocumentNode),
                GetPrice(htmlDoc.DocumentNode),
                GetRoomCount(htmlDoc.DocumentNode),
                GetLivingArea(htmlDoc.DocumentNode),
                GetPlotArea(htmlDoc.DocumentNode),
                GetImageUri(htmlDoc.DocumentNode),
                GetDetailsUri(htmlDoc.DocumentNode));
        }

        private string GetId(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//strong[contains(text(), 'Objekt-Nr')]");
            return idNode?.NextSibling.InnerText.RemoveRNT();
        }

        private string GetDescription(HtmlNode node)
        {
            var descriptionNode = node.SelectSingleNode("//a[contains(@class, 'red')]");
            return descriptionNode?.InnerText.RemoveRNT() ?? string.Empty;
        }

        private string GetType(HtmlNode node)
        {
            var typeNode = node.SelectSingleNode("//td[1]");
            return typeNode?.ChildNodes[3].InnerText.RemoveRNT() ?? string.Empty;
        }

        private string GetLocation(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//strong[contains(text(), 'Adresse')]");
            return idNode?.NextSibling.InnerText.RemoveRNT();
        }

        private int GetPrice(HtmlNode node)
        {
            var priceNode = node.SelectSingleNode("//td/span[contains(@class, 'red')]");

            var priceText = priceNode?.InnerText ?? string.Empty;
            var priceMatch = Regex.Match(priceText, @"[^\d]*(\d*\.?\d*\.?\d*\.\d*) €.*");

            if (priceMatch.Success)
            {
                if (priceMatch.Groups.Count > 1)
                {
                    var price = priceMatch.Groups[1].Value;
                    return price.ToIntSafe();
                }
            }

            return 0;
        }

        private double GetLivingArea(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//strong[contains(text(), 'Wohnfläche')]");
            return idNode?.NextSibling.InnerText.RemoveRNT().Replace("m²", string.Empty).ToDoubleSafe() ?? 0;
        }

        private double GetRoomCount(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//strong[contains(text(), 'Zimmer')]");
            return idNode?.NextSibling.InnerText.RemoveRNT().Replace("m²", string.Empty).ToDoubleSafe() ?? 0;
        }

        private double GetPlotArea(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//strong[contains(text(), 'Grundstücksfläche')]");
            return idNode?.NextSibling.InnerText.RemoveRNT().Replace("m²", string.Empty).ToDoubleSafe() ?? 0;
        }

        private Uri GetImageUri(HtmlNode node)
        {
            var imageNode = node.SelectSingleNode("//td[1]/a/img");
            var uriString = imageNode?.Attributes.First(attribute => attribute.Name == "src")?.Value.Replace("/thumb/", "/full/") ?? "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png";
            return new Uri($"https://www.ohne-makler.net{uriString}");
        }

        private Uri GetDetailsUri(HtmlNode node)
        {
            var detailsNode = node.SelectSingleNode("//td[1]/a");
            var uriString = detailsNode?.Attributes.First(attribute => attribute.Name == "href")?.Value ?? string.Empty;
            return new Uri($"https://www.ohne-makler.net{uriString}");
        }

        private int GetPageCount(string htmlString)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var pageNode = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'pagination')]/ul/li");
            return pageNode?.Count - 2 ?? 1; // subtract next and previous buttons
        }
    }
}
