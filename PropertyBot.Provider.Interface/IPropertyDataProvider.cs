using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Interface
{
    public interface IPropertyDataProvider
    {
        public void Init();

        public bool Contains(Property property);

        public Task Add(Property property);

        public Task AddMany(IEnumerable<Property> properties);
    }
}
