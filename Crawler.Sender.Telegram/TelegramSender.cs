using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Interface;

namespace Crawler.Sender.Telegram
{
    public class TelegramSender : IMessageSender
    {
        public Task SendMessage(IEnumerable<Property> properties)
        {
            return Task.CompletedTask;
        }
    }
}
