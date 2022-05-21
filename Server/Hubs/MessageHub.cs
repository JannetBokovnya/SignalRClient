using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class MessageHub:Hub<IMessageClient>
    {
        //получает сообщение с клиента и пересылает всем остальным
        public Task SendToOthers(Message message)
        {
            //создается обьект NewMessage при помощи статического метода Create
            var messageForClient = NewMessage.Create(Context.Items["Name"] as string, message);
            return Clients.Others.Send(messageForClient);
        }

        //подключенному клиенту задавать себе имя которое будет пересылаться с сообщением
        public Task SetMyName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Task.CompletedTask;
            if (Context.Items.ContainsKey("Name"))
                Context.Items["Name"] = name;
            else
                Context.Items.Add("Name", name);

            return Task.CompletedTask;
        }

        //возвращает результат, возвращает имя клиента если оно задано
        public Task<string> GetMyName()
        {
            if (Context.Items.ContainsKey("Name"))
                return Task.FromResult(Context.Items["Name"] as string);
            return Task.FromResult("Anonymous");
        }
    }
}
