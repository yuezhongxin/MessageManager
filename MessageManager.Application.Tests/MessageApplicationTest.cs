/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
using MessageManager.Application.Implementation;
using MessageManager.Repositories;
using MessageManager.Repositories.EntityFramework;
using Xunit;

namespace MessageManager.Application.Tests
{
    public class MessageApplicationTest
    {
        [Fact]
        public void SendMessageApplicationTest()
        {
            IMessageService messageService = new MessageServiceImpl(new EntityFrameworkRepositoryContext(),
                    new MessageRepository(new EntityFrameworkRepositoryContext()),
                    new UserRepository(new EntityFrameworkRepositoryContext()));
            UserDTO sendUserDTO = new UserDTO
            {
                ID = "dac488d3-d7f0-4bd8-9dcb-db7d195e94d1",
                Name = "小菜"
            };
            Assert.True(messageService.SendMessage("test", "test", sendUserDTO, "大神"));
        }
    }
}
