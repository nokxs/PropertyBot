using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoXXL.Entity;

namespace PropertyBot.Provider.ImmoXXL.Converter
{
    public interface IImmoXXLPropertyConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<ImmoXXLImmoProperty> estates);
    }
}
