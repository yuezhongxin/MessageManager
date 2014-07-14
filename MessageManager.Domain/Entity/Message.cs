/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.ValueObject;
using System;

namespace MessageManager.Domain.Entity
{
    public class Message : IAggregateRoot
    {
        public Message(string title, string content, IContact sender, IContact recipient)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title can't be null");
            }
            if (title.Length > 20)
            {
                throw new ArgumentException("标题长度不能超过20");
            }
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("content can't be null");
            }
            if (content.Length > 400)
            {
                throw new ArgumentException("内容长度不能超过400");
            }
            if (sender == null)
            {
                throw new ArgumentException("sender can't be null");
            }
            if (recipient == null)
            {
                throw new ArgumentException("recipient can't be null");
            }
            //this.ID = Guid.NewGuid().ToString();
            this.ID = "1";
            this.Title = title;
            this.Content = content;
            //this.SendTime = DateTime.Now;
            this.SendTime = DateTime.Parse("2014-7-14");
            this.State = MessageState.NoRead;
            this.Sender = sender;
            this.Recipient = recipient;
        }
        public string ID { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime SendTime { get; private set; }
        public MessageState State { get; set; }
        public virtual IContact Sender { get; private set; }
        public virtual IContact Recipient { get; private set; }
    }
}
