using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.GutImmo.Entity;

namespace PropertyBot.Provider.GutImmo.Converter
{
    internal interface IGutImmoPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<GutImmoProperty> estates);
    }
}
