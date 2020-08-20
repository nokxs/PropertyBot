using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.LinkImmo.Entity;

namespace PropertyBot.Provider.LinkImmo.Converter
{
    internal interface ILinkPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<LinkProperty> estates);
    }
}
