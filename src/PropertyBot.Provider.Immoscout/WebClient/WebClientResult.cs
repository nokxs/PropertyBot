using System.Collections.Generic;
using PropertyBot.Provider.Immoscout.Entity;

namespace PropertyBot.Provider.Immoscout.WebClient
{
    internal class WebClientResult
    {
        public WebClientResult(int firstBlockedPage, IEnumerable<ImmoscoutProperty> immoscoutProperties)
        {
            FirstBlockedPage = firstBlockedPage;
            ImmoscoutProperties = immoscoutProperties;
        }
        public int FirstBlockedPage { get; }

        public IEnumerable<ImmoscoutProperty> ImmoscoutProperties { get; }
    }
}