using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyBot.Interface
{
    public interface IPropertyProvider
    {
        Task<IEnumerable<Property>> GetProperties();
    }
}