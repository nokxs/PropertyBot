using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PropertyBot.Common.Extensions;
using PropertyBot.Interface;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace PropertyBot.Sender.Telegram
{
    public class TelegramSender : IMessageSender
    {
        private readonly ISenderDataProvider _senderDataProvider;
        private TelegramBotClient _botClient;

        public TelegramSender(ISenderDataProvider senderDataProvider)
        {
            _senderDataProvider = senderDataProvider;
        }

        public void Init()
        {
            var token = EnvironmentConstants.TELEGRAM_API_TOKEN.GetAsMandatoryEnvironmentVariable();

            _botClient = new TelegramBotClient(token);
            ListenForNewUsers();
        }

        private void ListenForNewUsers()
        {
            _botClient.OnMessage += (sender, args) =>
            {
                var chat = args.Message.Chat;
                var name = chat.FirstName;
                var id = chat.Id;

                if (_senderDataProvider.Contains<TelegramUser>(user => user.ChatId == id))
                {
                    _botClient.SendTextMessageAsync(id,
                        $"{name} du bist schon registriert...");
                }
                else
                {
                    _senderDataProvider.Add(new TelegramUser(name, id));
                    _botClient.SendTextMessageAsync(id,
                        $"Hallo {name}!. Du bist jetzt registriert und bekommst neue Angebote");
                }
            };

            _botClient.StartReceiving();
        }

        public async Task SendMessage(string message)
        {
            var users = _senderDataProvider.GetAll<TelegramUser>();
            foreach (var user in users)
            {
                await _botClient.SendTextMessageAsync(user.ChatId, message);
            }
        }

        public async Task SendProperties(IEnumerable<Property> properties)
        {
            var users = _senderDataProvider.GetAll<TelegramUser>();
            var propertyList = properties.ToList();

            foreach (var user in users)
            {
                foreach (var property in propertyList)
                {
                    var message = GetMessage(property);

                    try
                    {
                        await _botClient.SendPhotoAsync(user.ChatId, new InputOnlineFile(property.ImageUrl), message,
                            GetParseMode(property.MessageFormat));
                    }
                    catch (HttpRequestException)
                    {
                        await Task.Delay(30000);
                    }
                    catch (Exception e)
                    {
                        await _botClient.SendTextMessageAsync(user.ChatId, $"ERROR: Could not send the following message as {property.MessageFormat}: \n {message} \n\n Exception: {e.Message}\n\n{e.StackTrace}");
                    }

                    await Task.Delay(50);
                }
            }
        }

        private string GetMessage(Property property)
        {
            switch (property.MessageFormat)
            {
                case MessageFormat.Html:
                    return GetHtmlMessage(property);
                case MessageFormat.Markdown:
                    throw new NotImplementedException("Markdown format for telegram is not implemented");
                default:
                    throw new ArgumentOutOfRangeException(nameof(property.MessageFormat), property.MessageFormat, null);
            }
        }

        private string GetHtmlMessage(Property property)
        {
            var normalizedDescription = Normalize(property.Description);
            var separatedPrice = string.Format(new CultureInfo("de-DE"), "{0:n0}", property.Price);

            return $"{normalizedDescription} \n\n<i>Preis: {separatedPrice} €</i> \n\n{GetDetails(property)} \n\n<i>Provider: {property.ProviderName}</i>\n\n<a href=\"{property.DetailsUrl}\">Mehr...</a>";
        }

        private string GetDetails(Property property)
        {
            var ret = string.Empty;

            foreach (var detail in property.AdditionalDetails)
            {
                ret += $"• {detail.Key}: {Normalize(detail.Value)}\n";
            }

            return ret;
        }

        private ParseMode GetParseMode(MessageFormat messageFormat)
        {
            switch (messageFormat)
            {
                case MessageFormat.Html:
                    return ParseMode.Html;
                case MessageFormat.Markdown:
                    return ParseMode.MarkdownV2;
                default:
                    return ParseMode.Default;
            }
        }

        private string Normalize(string s)
        {
            if (s == null)
            {
                return string.Empty;
            }

            var s2 = s
                .Replace("<br>", " \n ")
                .Replace("<span>", string.Empty)
                .Replace("</span>", string.Empty);

            return Regex.Replace(s2, "(<span.*>)", string.Empty);
        }
    }
}
