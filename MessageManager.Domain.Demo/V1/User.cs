using MessageManager.Domain.Demo.V1.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.Demo.V1
{
    public class User
    {
        public User()
        {
            this.ID = Guid.NewGuid().ToString();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> SendMessages { get; set; }
        public virtual ICollection<Message> ReceiveMessages { get; set; }

        public void SendMessage(Message message)
        {
            User toUser = GetUser(message.ToUser);
            if (toUser == null)
            {
                throw new NotImplementedException();
            }
            message.FromUser = this;
            message.ToUser = toUser;
            this.SendMessages.Add(message);
            toUser.ReceiveMessages.Add(message);
            DomainEvents.Raise(new MessageEvent() { DoMessage = message });
            ///
        }

        public Message ShowMessage(User readUser, string messageID)
        {
            Message message = GetMessage(messageID);
            if (message == null)
            {
                throw new NotImplementedException();
            }
            message.ReadMessage(readUser);
            return message;
        }

        public User GetUser(User user)
        {
            throw new NotImplementedException();
        }

        public Message GetMessage(string messageID)
        {
            throw new NotImplementedException();
        }
    }
}