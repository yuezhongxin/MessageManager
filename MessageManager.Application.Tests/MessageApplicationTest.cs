/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.Implementation;
using MessageManager.Domain.DomainService;
using MessageManager.Repositories;
using MessageManager.Repositories.EntityFramework;
using Xunit;

namespace MessageManager.Application.Tests
{
    public class MessageApplicationTest
    {
        [Fact]
        public void ApplicationTest_SendMessage()
        {
            IMessageService messageService = new MessageServiceImpl(new EntityFrameworkRepositoryContext(),
                    new MessageRepository(new EntityFrameworkRepositoryContext()),
                    new ContactRepository(),
                    new SendShortMessageService());
            Assert.True(messageService.SendMessage("title", "content", "senderLoginName", "receiverDisplayName").IsSuccess);
        }
    }
}
