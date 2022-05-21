using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public sealed class NewMessage:Message
    {
        //строковое поле отправитель
        public string Sender { get; set; }

        private NewMessage() { }

        //sender имя отправителя и сообщение message
        public static NewMessage Create(string sender, Message message)
        {
            return new NewMessage
            {
                Sender = string.IsNullOrWhiteSpace(sender) ? "Anonymous" : sender,
                Text = message.Text
                //т.к. потомок Message то содержит поле Text -содержимое сообщения
            };
        }
    }
}
