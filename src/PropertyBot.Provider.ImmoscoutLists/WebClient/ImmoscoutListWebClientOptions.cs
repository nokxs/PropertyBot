using System.Collections.Generic;

namespace PropertyBot.Provider.ImmoscoutLists.WebClient
{
    internal class ImmoscoutListWebClientOptions
    {
        public ImmoscoutListWebClientOptions(string listId)
        {
            ListId = listId;
        }

        public string ListId { get; }
    }
}
