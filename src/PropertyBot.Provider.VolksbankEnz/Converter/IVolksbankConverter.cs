using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankEnz.Entity;

namespace PropertyBot.Provider.VolksbankEnz.Converter
{
    internal interface IVolksbankConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<VolksbankProperty> volksbankProperties);
    }
}
