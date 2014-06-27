using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.Demo
{
    public class Message
    {
        public Message(string title, string content, User sendUser)
        {
            if (title.Equals("") || content.Equals("") || sendUser == null)
            {
                throw new ArgumentNullException();
            }
            this.ID = Guid.NewGuid().ToString();
            this.Title=title;
            this.Content=content;
            this.SendTime = DateTime.Now;
            this.Type = MessageType.SendMessage;
            this.State = MessageState.NoRead;
            this.SendUser = sendUser;
        }
        public string ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public MessageType Type { get; set; }
        public MessageState State { get; set; }
        public virtual User SendUser { get; set; }
        public virtual User ReceiveUser { get; set; }

        public void Send(User receiveUser)
        {
            if (receiveUser == null)
            {
                throw new ArgumentNullException();
            }
            this.ReceiveUser = receiveUser;
            this.SendUser.SendMessages.Add(this);
            receiveUser.ReceiveMessages.Add(this);
            ///to do...
        }

        //public ICollection<Message> Read(User readUser,MessageType messageType)
        //{
        //    switch (messageType)
        //    {
        //        case MessageType.SendMessage:
        //            return readUser.SendMessages;
        //        case MessageType.ReceiveMessage:
        //            return readUser.ReceiveMessages;
        //        default:
        //            return readUser.SendMessages;
        //    }
        //}

        //public Message Read(User readUser, MessageType messageType, string ID)
        //{
        //    switch (messageType)
        //    {
        //        case MessageType.SendMessage:
        //            return readUser.SendMessages.First<Message>(p => p.ID == ID);
        //        case MessageType.ReceiveMessage:
        //            return readUser.ReceiveMessages.First<Message>(p => p.ID == ID).Read(readUser);
        //        default:
        //            return readUser.SendMessages.First<Message>(p => p.ID == ID);
        //    }
        //}

        public Message Read(User readUser)
        {
            if (readUser.Equals(this.ReceiveUser) && this.Type == MessageType.ReceiveMessage && this.State == MessageState.NoRead)
            {
                this.State = MessageState.Read;
            }
            return this;
        }
    }
}
