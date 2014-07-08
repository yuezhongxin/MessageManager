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
        public Message(string title, string content, User sendUser, User receiveUser)
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
            if (content.Length > 200)
            {
                throw new ArgumentException("内容长度不能超过200");
            }
            if (sendUser == null)
            {
                throw new ArgumentException("sendUser can't be null");
            }
            if (receiveUser == null)
            {
                throw new ArgumentException("receiveUser can't be null");
            }
            if (sendUser == receiveUser)
            {
                throw new ArgumentException("发件人和收件人不能为同一人");
            }
            this.ID = Guid.NewGuid().ToString();
            this.Title = title;
            this.Content = content;
            this.SendTime = DateTime.Now;
            this.State = MessageState.NoRead;
            this.SendUser = sendUser;
            this.ReceiveUser = receiveUser;
        }
        public string ID { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime SendTime { get; private set; }
        public MessageState State { get; set; }
        public virtual User SendUser { get; private set; }
        public virtual User ReceiveUser { get; private set; }
    }
}
