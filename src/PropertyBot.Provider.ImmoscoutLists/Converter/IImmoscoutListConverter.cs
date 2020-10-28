using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoscoutLists.Entity;

namespace PropertyBot.Provider.ImmoscoutLists.Converter
{
    internal interface IImmoscoutListConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmoscoutListProperty> immoscoutListProperties);
    }
}
