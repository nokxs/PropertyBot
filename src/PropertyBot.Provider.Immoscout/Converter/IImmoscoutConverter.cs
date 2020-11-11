using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.Immoscout.Entity;

namespace PropertyBot.Provider.Immoscout.Converter
{
    internal interface IImmoscoutConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmoscoutProperty> immoscoutListProperties);
    }
}
