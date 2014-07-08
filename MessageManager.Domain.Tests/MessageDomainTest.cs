/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Infrastructure;
using Xunit;

namespace MessageManager.Domain.Tests
{
    public class MessageDomainTest
    {
        [Fact]
        public void DomainTest_SendMessage()
        {
            User sendUser = new User("xiaocai", "小菜");
            User receiveUser = new User("dashen", "大神");
            Message message = new Message("test", "test", sendUser, receiveUser);
            OperationResponse<Message> serviceResult = VerifyMessageService.VerifyMessage(message);
            Assert.True(VerifyMessageService.VerifyMessage(message).IsSuccess);
        }

        [Fact]
        public void DomainTest_ReadMessage()
        {
            User readUser = new User("xiaocai", "小菜");
            Message message = new Message("test", "test", new User("xiaocai", "小菜"), new User("dashen", "大神"));
            OperationResponse<Message> serviceResult = ReadMessageService.ReadMessage(message, readUser);
            Assert.True(ReadMessageService.ReadMessage(message, readUser).IsSuccess);
        }

        [Fact]
        public void DomainTest_ReplyMessage()
        {
            User replyUser = new User("dashen", "大神");
            Message message = new Message("test", "test", new User("xiaocai", "小菜"), new User("dashen", "大神"));
            OperationResponse<Message> serviceResult = VerifyMessageService.VerifyMessage(message);
            Assert.True(VerifyMessageService.VerifyMessage(message).IsSuccess);
        }
    }
}
