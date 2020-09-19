using PropertyBot.Provider.ZVG.WebClient;

namespace PropertyBot.Provider.ZVG.Options
{
    internal interface IZvgOptionsReader
    {
        ZvgWebClientOptions GetWebClientOptions();
    }
}