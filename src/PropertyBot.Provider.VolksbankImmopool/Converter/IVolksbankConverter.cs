using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankImmopool.Entity;

namespace PropertyBot.Provider.VolksbankImmopool.Converter
{
    internal interface IVolksbankConverter
    {
        public IEnumerable<Property> ToProperties(IEnumerable<VolksbankProperty> volksbankProperties);
    }
}
