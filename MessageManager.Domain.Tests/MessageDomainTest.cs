/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Domain.ValueObject;
using Xunit;

namespace MessageManager.Domain.Tests
{
    public class MessageDomainTest
    {
        /// <summary>
        /// 消息发送-短消息
        /// </summary>
        [Fact]
        public void DomainTest_SendShortMessage()
        {
            ISendMessageService sendMessageService = new SendShortMessageService();
            IContact sender = new Sender("1");
            IContact recipient = new Recipient("123");
            Message message = new Message("title", "content ", sender, recipient);
            Assert.True(sendMessageService.SendMessage(message));
        }
    }
}
