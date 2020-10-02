using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyBot.Interface
{
    public interface IPropertyProvider
    {
        public string Name { get; }

        Task<IEnumerable<Property>> GetProperties();
    }
}