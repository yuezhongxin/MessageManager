using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MessageManager.Domain.Demo.Tests
{
    public class MessageDomainTest
    {
        [Fact]
        public void SendMessageTest()
        {
            User sendUser = new User("小菜");
            User receiveUser = new User("大神");
            Message message = new Message("test", "test", sendUser);
            message.Send(receiveUser);
            Message messageResult = receiveUser.ReceiveMessages.First<Message>(p => p.SendUser == sendUser);
            Assert.Equal(messageResult, message);
        }

        [Fact]
        public Message ReadMessageTest()
        {
            return null;
        }
    }
}
