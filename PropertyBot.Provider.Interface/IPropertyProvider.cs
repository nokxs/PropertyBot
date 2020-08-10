using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Interface
{
    public interface IPropertyProvider
    {
        Task<IEnumerable<Property>> GetProperties();
    }
}