using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.LinkImmo.Entity;

namespace PropertyBot.Provider.LinkImmo.Converter
{
    internal class LinkPropertyConverter : ILinkPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<LinkProperty> properties)
        {
            return null;
        }
    }
}
