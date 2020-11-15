using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyBot.Common
{
    public class HtmlPaginationHelper : IHtmlPaginationHelper
    {
        public async Task<IEnumerable<TProperty>> GetPaginatedObjects<TOptions, TProperty>(
            Func<TOptions, int, Task<string>> getRawPageFunc,
            Func<string, IEnumerable<TProperty>> parseHtmlFunc,
            Func<string, int> getPageCountFunc,
            TOptions options)
            where TOptions : class
        {
            var properties = new List<TProperty>();

            var rawPage = await getRawPageFunc(options, 1);
            var pageCount = getPageCountFunc(rawPage);
            properties.AddRange(parseHtmlFunc(rawPage));

            for (int pageNr = 2; pageNr <= pageCount; pageNr++)
            {
                rawPage = await getRawPageFunc(options, pageNr);
                properties.AddRange(parseHtmlFunc(rawPage));
            }

            return properties;
        }
    }
}
