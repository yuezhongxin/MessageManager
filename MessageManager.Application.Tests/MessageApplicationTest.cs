/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
using MessageManager.Application.Implementation;
using MessageManager.Domain.DomainService;
using MessageManager.Repositories;
using MessageManager.Repositories.EntityFramework;
using System;
using Xunit;

namespace MessageManager.Application.Tests
{
    public class MessageApplicationTest
    {
        public MessageApplicationTest()
        {
            ApplicationService.Initialize();
        }

        [Fact]
        public void ApplicationTest_SendMessage()
        {
            IMessageService messageService = new MessageServiceImpl(new EntityFrameworkRepositoryContext(),
                    new MessageRepository(new EntityFrameworkRepositoryContext()),
                    new ContactRepository(),
                    new SendSiteMessageService());
            Assert.True(messageService.SendMessage("title", "content", "xiaocai", "大神").IsSuccess);
        }

        [Fact]
        public void ApplicationTest_GetUnreadMessageList()
        {
            IMessageService messageService = new MessageServiceImpl(new EntityFrameworkRepositoryContext(),
                    new MessageRepository(new EntityFrameworkRepositoryContext()),
                    new ContactRepository(),
                    new SendSiteMessageService());
            var messages = messageService.GetUnreadMessageList("dashen").Data;
            foreach (MessageDTO message in messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("Sender:" + message.Sender.DisplayName);
                Console.WriteLine("Recipient:" + message.Recipient.DisplayName);
                Console.WriteLine("MessageState:" + message.State);
            }
        }

        [Fact]
        public void ApplicationTest_ReadInbox()
        {
            IMessageService messageService = new MessageServiceImpl(new EntityFrameworkRepositoryContext(),
                    new MessageRepository(new EntityFrameworkRepositoryContext()),
                    new ContactRepository(),
                    new SendSiteMessageService());
            foreach (MessageDTO message in messageService.ReadInbox("dashen").Data)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("Sender:" + message.Sender.DisplayName);
                Console.WriteLine("Recipient:" + message.Recipient.DisplayName);
                Console.WriteLine("MessageState:" + message.State);
            }
        }
    }
}
