/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.DomainModel
{
    public class User : IAggregateRoot
    {
        public User(string name)
        {
            if (name.Equals(""))
            {
                throw new ArgumentNullException();
            }
            this.ID = Guid.NewGuid().ToString();
            this.Name = name;
        }

        public string ID { get; set; }
        public string Name { get; set; }
    }
}
