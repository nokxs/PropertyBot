using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Interface
{
    public interface IMessageSender
    {
        Task SendMessages(IEnumerable<Property> properties);

        void Init();
    }
}
