using System.Threading.Tasks;
using Crawler.Interface;

namespace Crawler.Persistence
{
    public interface IDataProvider
    {
        public bool Contains(Property property)
        {
            return true;
        }

        public Task Add(Property property)
        {
            return Task.CompletedTask;
        }

        public Task Remove(Property property)
        {
            return Task.CompletedTask;
        }
    }
}
