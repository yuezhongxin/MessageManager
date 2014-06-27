using MessageManager.Domain.Demo.V1.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.Demo.V2
{
    public class User
    {
        public User(string name)
        {
            if (name.Equals(""))
            {
                throw new ArgumentNullException();
            }
            this.ID = Guid.NewGuid().ToString();
            this.Name = name;
            this.SendMessages = new List<Message>();
            this.ReceiveMessages = new List<Message>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> SendMessages { get; set; }
        public virtual ICollection<Message> ReceiveMessages { get; set; }
    }
}
