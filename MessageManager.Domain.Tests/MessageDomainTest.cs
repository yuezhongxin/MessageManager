/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using Xunit;

namespace MessageManager.Domain.Tests
{
    public class MessageDomainTest
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        [Fact]
        public void DomainTest_SendMessage()
        {
            ISendMessageService sendMessageService = new SendMessageService();
            User sendUser = new User("xiaocai", "小菜");
            User receiveUser = new User("dashen", "大神");
            Message message = new Message("test", "test", sendUser, receiveUser);
            Assert.True(sendMessageService.SendMessage(message, sendUser, receiveUser));
        }
    }
}
