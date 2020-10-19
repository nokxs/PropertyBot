using System.Collections.Generic;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankFlowfact.Entity;

namespace PropertyBot.Provider.VolksbankFlowfact.Converter
{
    internal interface IVolksbankConverter
    {
        public IEnumerable<Property> ToProperties(long clientId, IEnumerable<VolksbankProperty> volksbankProperties);
    }
}
