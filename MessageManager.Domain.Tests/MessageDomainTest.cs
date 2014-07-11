/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Repositories;
using MessageManager.Repositories.EntityFramework;
using Xunit;

namespace MessageManager.Domain.Tests
{
    public class MessageDomainTest
    {
        #region Private Fields
        private readonly IMessageRepository messageRepository = new MessageRepository(new EntityFrameworkRepositoryContext());
        private readonly IUserRepository userRepository = new UserRepository(new EntityFrameworkRepositoryContext());
        #endregion

        /// <summary>
        /// 发送消息
        /// </summary>
        [Fact]
        public void DomainTest_SendMessage()
        {
            ISendMessageService servcie = new SendMessageService();
            User sendUser = new User("", "");
            User receiveUser = new User("", "");
            Message message = new Message("test", "test", sendUser, receiveUser);
            Assert.True(servcie.SendMessage(message, sendUser, receiveUser));
        }
    }
}
