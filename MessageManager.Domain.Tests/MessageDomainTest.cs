/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MessageManager.Domain.Tests
{
    public class MessageDomainTest
    {
        [Fact]
        public void SendMessageTest()
        {
            User sendUser = new User("小菜");
            User receiveUser = new User("大神");
            Message message = new Message("test", "test", sendUser);
            Assert.Equal(message.Send(receiveUser),true);
        }

        [Fact]
        public Message ReadMessageTest()
        {
            return null;
        }
    }
}
