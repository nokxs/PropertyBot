using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PropertyBot.Provider.LinkImmo.Entity;

namespace PropertyBot.Provider.LinkImmo.WebClient
{
    internal class LinkImmoWebClient : ILinkImmoWebClient
    {
        private const string BaseUrl = "https://www.link-immobilien.info";

        private readonly HttpClient _client;

        public LinkImmoWebClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<LinkProperty>> GetObjects(LinkImmoWebClientOptions options)
        {
            var page = await GetRawPage(options, 0);
            ParseRawPage(page);

            return null;
        }

        private async Task<string> GetRawPage(LinkImmoWebClientOptions options, int page)
        {
            var cursor = page * 6;
            return await _client.GetStringAsync(
                    $"{BaseUrl}/index.php4?cmd=searchResults&goto=1&alias=suchmaske&kaufartids={options.BuyIds}&kategorieids={options.CategoryIds}&objq[order_zusammen]=&objqorder_zusammen=#sprung_modul_suchmakse_0&objq[cursor]={cursor}");
        }

        private void ParseRawPage(string content)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);
            var objects = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'objekt')]");
            var properties = objects.Select(ParseObject).ToList();
        }

        private LinkProperty ParseObject(HtmlNode objectNode)
        {
            var objectDoc = new HtmlDocument();
            objectDoc.LoadHtml(objectNode.InnerHtml);

            var id = GetId(objectDoc.DocumentNode);
            var roomCount = GetRoomCount(objectDoc.DocumentNode);
            var livingArea = GetLivingArea(objectDoc.DocumentNode);
            var propertyType = GetPropertyType(objectDoc.DocumentNode);
            var description = GetDescription(objectDoc.DocumentNode);
            var location = GetLocation(objectDoc.DocumentNode);
            var price = GetPrice(objectDoc.DocumentNode);
            var imageUrl = GetImageUrl(objectDoc.DocumentNode);

            return null;
        }

        private string GetId(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//div[contains(@class, 'objnr')]/b");
            return idNode?.InnerText ?? "ID_NOT_FOUND";
        }

        private string GetRoomCount(HtmlNode node)
        {
            var objectInfos = GetObjectInfos(node);
            var roomNode = objectInfos.FirstOrDefault(info => info.InnerHtml.Contains("ZIMMER"));
            return GetInfoNodeValue(roomNode, "0");
        }

        private string GetLivingArea(HtmlNode node)
        {
            var objectInfos = GetObjectInfos(node);
            var roomNode = objectInfos.FirstOrDefault(info => info.InnerHtml.Contains("WOHNFLÄCHE"));
            return GetInfoNodeValue(roomNode, "0 m²");
        }

        private string GetPropertyType(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//div[contains(@class, 'objektart')]");
            return idNode?.InnerText ?? "?";
        }

        private string GetLocation(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//div[contains(@class, 'ort')]");
            return idNode?.InnerText ?? "No Location available";
        }

        private string GetDescription(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//div[contains(@class, 'hauptinfos')]/h3/a");
            return idNode?.InnerText ?? "No Description available";
        }

        private string GetPrice(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//div[contains(@class, 'preis')]/span");
            return idNode?.InnerText ?? "0";
        }

        private string GetImageUrl(HtmlNode node)
        {
            var idNode = node.SelectSingleNode("//div[contains(@class, 'bg_image')]");
            var style = idNode.Attributes.FirstOrDefault(attribute => attribute.Name == "style")?.Value;
            var urlMatch = Regex.Match(style, @"url\((.*)\)");

            if (urlMatch.Success)
            {
                if (urlMatch.Groups.Count > 1)
                {
                    var url = urlMatch.Groups[1];
                    return $"{BaseUrl}/{url}";
                }
            }

            return "https://upload.wikimedia.org/wikipedia/commons/2/26/512pxIcon-sunset_photo_not_found.png";
        }

        private string GetInfoNodeValue(HtmlNode node, string defaultValue)
        {
            return node?.ChildNodes.FirstOrDefault(child => child.Name == "b")?.InnerText ?? defaultValue;
        }

        private HtmlNodeCollection GetObjectInfos(HtmlNode node)
        {
            return node.SelectNodes("//div[contains(@class, 'objektinfos')]/div[contains(@class, 'info')]");
        }
    }
}
