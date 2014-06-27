using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.Demo.V1
{
    public class Message
    {
        public Message()
        {
            this.ID = Guid.NewGuid().ToString();
            this.SendTime = DateTime.Now;
            this.Type = MessageType.SendMessage;
            this.State = MessageState.NoRead;
        }
        public string ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public MessageType Type { get; set; }
        public MessageState State { get; set; }
        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }

        public void ReadMessage(User readUser)
        {
            if (readUser.Equals(this.ToUser) && this.Type == MessageType.ReceiveMessage && this.State == MessageState.NoRead)
            {
                this.State = MessageState.Read;
            }
        }
    }
}