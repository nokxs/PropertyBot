using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL.Entity;

namespace PropertyBot.Provider.Base.ImmoXXL.Converter
{
    internal interface IImmoXXLPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmoXXLImmoProperty> estates);
    }
}
