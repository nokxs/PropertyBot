using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Interface
{
    public interface IMessageSender
    {
        Task SendMessage(IAsyncEnumerable<Property> properties);
    }
}
