using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankStuttgart.Entity;

namespace PropertyBot.Provider.VolksbankStuttgart.Converter
{
    internal interface IVolksbankConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<VolksbankProperty> volksbankProperties);
    }
}
