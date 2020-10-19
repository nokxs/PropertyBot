namespace PropertyBot.Provider.VolksbankFlowfact.WebClient
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
