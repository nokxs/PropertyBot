using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyBot.Interface
{
    public interface IMessageSender
    {
        Task SendMessages(IEnumerable<Property> properties);

        void Init();
    }
}
