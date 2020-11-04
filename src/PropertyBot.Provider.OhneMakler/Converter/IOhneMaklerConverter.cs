using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Entity;

namespace PropertyBot.Provider.OhneMakler.Converter
{
    internal interface IOhneMaklerConverter
    {
        public IEnumerable<Property> ToProperties(long clientId, IEnumerable<OhneMaklerProperty> volksbankProperties);
    }
}
