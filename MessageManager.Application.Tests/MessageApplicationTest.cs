/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.Implementation;
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
                    new UserRepository(new EntityFrameworkRepositoryContext()));
            Assert.True(messageService.SendMessage("test", "test", "xiaocai", "大神"));
        }
    }
}
