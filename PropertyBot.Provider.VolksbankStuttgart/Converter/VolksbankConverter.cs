using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankStuttgart.Entity;

namespace PropertyBot.Provider.VolksbankStuttgart.Converter
{
    internal class VolksbankConverter : IVolksbankConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<VolksbankProperty> estates)
        {
            return null;
        }
    }
}
