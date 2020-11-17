using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.OhneMakler.Entity;

namespace PropertyBot.Provider.OhneMakler.WebClient
{
    internal interface IImmosuchmaschineWebClient
    {
        public Task<IEnumerable<ImmosuchmaschineProperty>> GetObjects(ImmosuchmaschineClientOptions options);
    }
}