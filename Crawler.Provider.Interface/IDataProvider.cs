using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Interface
{
    public interface IDataProvider
    {
        public void Init();

        public Task<bool> Contains(Property property);

        public Task Add(Property property);

        public Task AddMany(IEnumerable<Property> properties);
    }
}
