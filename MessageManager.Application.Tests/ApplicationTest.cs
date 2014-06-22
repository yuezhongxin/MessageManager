/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
using MessageManager.Application.Implementation;
using MessageManager.Domain.DomainService;
using MessageManager.Domain.Repositories;
using MessageManager.Repositories;
using MessageManager.Repositories.EntityFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Application.Tests
{
    [TestFixture]
    public class ApplicationTest
    {
        [Test]
        public void MessageApplication()
        {
            IMessageService messageService = new MessageServiceImpl(new MessageDomainService(
                    new MessageRepository(new EntityFrameworkRepositoryContext()),
                    new UserRepository(new EntityFrameworkRepositoryContext())));
            UserDTO userDTO = new UserDTO
            {
                Name = "小菜"
            };
            var messages = messageService.GetMessagesBySendUser(userDTO);
            foreach (MessageDTO item in messages)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
