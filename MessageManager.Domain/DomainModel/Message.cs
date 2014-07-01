/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;

namespace MessageManager.Domain.DomainModel
{
    public class Message : IAggregateRoot
    {
        public Message(string title, string content, User sendUser)
        {
            if (title.Equals("") || content.Equals("") || sendUser == null)
            {
                throw new ArgumentNullException();
            }
            this.ID = Guid.NewGuid().ToString();
            this.Title = title;
            this.Content = content;
            this.SendTime = DateTime.Now;
            this.State = MessageState.NoRead;
            this.SendUser = sendUser;
        }
        public string ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public MessageState State { get; set; }
        public virtual User SendUser { get; set; }
        public virtual User ReceiveUser { get; set; }

        public bool Send(User receiveUser)
        {
            if (receiveUser == null)
            {
                throw new ArgumentNullException();
            }
            this.ReceiveUser = receiveUser;
            return true;
            ///to do...
        }

        public Message Read(User readUser)
        {
            if (readUser.Equals(this.ReceiveUser) && this.State == MessageState.NoRead)
            {
                this.State = MessageState.Read;
            }
            return this;
        }
    }
}
