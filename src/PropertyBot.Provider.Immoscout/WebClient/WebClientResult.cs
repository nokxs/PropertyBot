using System.Collections.Generic;
using PropertyBot.Provider.Immoscout.Entity;

namespace PropertyBot.Provider.Immoscout.WebClient
{
    internal class WebClientResult
    {
        public WebClientResult(int nextPageNumber, IEnumerable<ImmoscoutProperty> immoscoutProperties)
        {
            NextPageNumber = nextPageNumber;
            ImmoscoutProperties = immoscoutProperties;
        }
        public int NextPageNumber { get; }

        public IEnumerable<ImmoscoutProperty> ImmoscoutProperties { get; }
    }
}