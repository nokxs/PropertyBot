using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Interface;

namespace PropertyBot.Provider.KSK
{
    public class KskClient : IPropertyProvider
    {
        public Task<IEnumerable<Property>> GetProperties()
        {
            throw new NotImplementedException();
        }
    }
}
