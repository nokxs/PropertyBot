using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Entity;

namespace PropertyBot.Provider.OhneMakler.Converter
{
    internal interface IImmosuchmaschineConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmosuchmaschineProperty> volksbankProperties);
    }
}
