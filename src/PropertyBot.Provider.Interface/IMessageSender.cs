using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyBot.Interface
{
    public interface IMessageSender
    {
        Task SendMessage(string message);

        Task SendProperties(IEnumerable<Property> properties);

        void Init();
    }
}
