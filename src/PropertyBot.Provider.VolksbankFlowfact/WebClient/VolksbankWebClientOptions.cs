using System.Collections.Generic;

namespace PropertyBot.Provider.VolksbankFlowfact.WebClient
{
    internal class VolksbankWebClientOptions
    {
        public VolksbankWebClientOptions(IEnumerable<string> inputMasks, long clientId)
        {
            InputMasks = inputMasks;
            ClientId = clientId;
        }

        public IEnumerable<string> InputMasks { get; }

        public long ClientId { get; }
    }
}
