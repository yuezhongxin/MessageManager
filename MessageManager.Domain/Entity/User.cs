/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;

namespace MessageManager.Domain.Entity
{
    public class User : IAggregateRoot
    {
        public User(string loginName, string displayName)
        {
            if (string.IsNullOrEmpty(loginName))
            {
                throw new ArgumentException("loginName can't be null");
            }
            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentException("displayName can't be null");
            }
            this.ID = Guid.NewGuid().ToString();
            this.LoginName = loginName;
            this.DisplayName = displayName;
            this.SendMessages = new List<Message>();
            this.ReceiveMessages = new List<Message>();
        }

        public string ID { get; private set; }
        public string LoginName { get; private set; }
        public string DisplayName { get; private set; }
        public virtual ICollection<Message> SendMessages { get; set; }
        public virtual ICollection<Message> ReceiveMessages { get; set; }
    }
}
