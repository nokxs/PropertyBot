using System.Collections.Generic;

namespace PropertyBot.Provider.VolksbankEnz.WebClient
{
    internal class VolksbankWebClientOptions
    {
        public VolksbankWebClientOptions(string inputMask)
        {
            InputMask = inputMask;
        }

        public string InputMask { get; }
    }
}
