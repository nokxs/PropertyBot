using System.Collections.Generic;

namespace PropertyBot.Provider.VolksbankEnz.WebClient
{
    internal class VolksbankWebClientOptions
    {
        public VolksbankWebClientOptions(string[] inputMasks)
        {
            InputMasks = inputMasks;
        }

        public string[] InputMasks { get; }
    }
}
