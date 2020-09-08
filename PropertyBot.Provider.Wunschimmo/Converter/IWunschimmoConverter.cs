using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.Wunschimmo.Entity;

namespace PropertyBot.Provider.Wunschimmo.Converter
{
    internal interface IWunschimmoConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<WunschimmoProperty> volksbankProperties);
    }
}
