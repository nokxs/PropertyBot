namespace PropertyBot.Sender.Telegram
{
    public class TelegramUser
    {
        public TelegramUser(string name, long chatId)
        {
            Name = name;
            ChatId = chatId;
        }

        public string Name { get; }

        public long ChatId { get; }
    }
}
