using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyBot.Common
{
    public interface IHtmlPaginationHelper
    {
        Task<IEnumerable<TProperty>> GetPaginatedObjects<TOptions, TProperty>(
            Func<TOptions, int, Task<string>> getRawPageFunc,
            Func<string, IEnumerable<TProperty>> parseHtmlFunc,
            Func<string, int> getPageCountFunc,
            TOptions options)
            where TOptions : class;
    }
}