/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using Xunit;

namespace MessageManager.Domain.Tests
{
    public class MessageDomainTest
    {
        [Fact]
        public void DomainTest_SendMessage()
        {
            //User sendUser = new User("xiaocai", "小菜");
            //Message message = new Message("test", "test", sendUser);
            //User receiveUser = new User("dashen", "大神");
            //Assert.True(message.Send(receiveUser).IsSuccess);
        }

        [Fact]
        public Message DomainTest_ReadMessage()
        {
            return null;
        }
    }
}
