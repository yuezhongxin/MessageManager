/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;
using MessageManager.Repositories;
using MessageManager.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
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
            SendMessageService service = new SendMessageService(
                new MessageRepository(new EntityFrameworkRepositoryContext()),
                new UserRepository(new EntityFrameworkRepositoryContext()));
            //Assert.NotNull(service.SendMessage("test", "test", "xiaocai", "小菜"));
            Message message = service.SendMessage("test", "test", "xiaocai", "小菜");
            Assert.NotNull(messageRepository.GetByKey(message.ID));
        }

        /// <summary>
        /// 阅读单条消息
        /// </summary>
        [Fact]
        public void DomainTest_ReadSingleMessage()
        {
            ReadMessageService service = new ReadMessageService(
                new MessageRepository(new EntityFrameworkRepositoryContext()),
                new UserRepository(new EntityFrameworkRepositoryContext()));
            Message message = service.ReadSingleMessage("1", "xiaocai");
            Console.WriteLine("ID:" + message.ID);
            Console.WriteLine("Title:" + message.Title);
            Console.WriteLine("Content:" + message.Content);
            Console.WriteLine("SendTime:" + message.SendTime);
            Console.WriteLine("State:" + (message.State == MessageState.Read ? "Read" : "NoRead"));
            Console.WriteLine("SenderDisplayName:" + message.SendUser.DisplayName);
            Console.WriteLine("ReceiverDisplayName:" + message.ReceiveUser.DisplayName);
        }

        /// <summary>
        /// 回复消息
        /// </summary>
        [Fact]
        public void DomainTest_ReplyMessage()
        {
            ReplyMessageService service = new ReplyMessageService(
                 new MessageRepository(new EntityFrameworkRepositoryContext()),
                 new UserRepository(new EntityFrameworkRepositoryContext()));
            //Assert.NotNull(service.ReplyMessage("test", "test", "xiaocai", "小菜"));
            Message message = service.ReplyMessage("test", "test", "xiaocai", "小菜");
            Assert.NotNull(messageRepository.GetByKey(message.ID));
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        [Fact]
        public void DomainTest_DeleteMessage()
        {
            DeleteMessageService service = new DeleteMessageService(
                new MessageRepository(new EntityFrameworkRepositoryContext()),
                new UserRepository(new EntityFrameworkRepositoryContext()));
            //Assert.True(service.DeleteMessage("1", "xiaocai"));
            service.DeleteMessage("1", "xiaocai");
            Assert.Null(messageRepository.GetByKey("1"));
        }

        /// <summary>
        /// 阅读发件箱
        /// </summary>
        [Fact]
        public void DomainTest_ReadOutbox()
        {
            ReadMessageService service = new ReadMessageService(
                 new MessageRepository(new EntityFrameworkRepositoryContext()),
                 new UserRepository(new EntityFrameworkRepositoryContext()));
            ICollection<Message> messages = service.ReadOutbox("xiaocai");
            foreach (Message message in messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("SendTime:" + message.SendTime);
                Console.WriteLine("State:" + (message.State == MessageState.Read ? "Read" : "NoRead"));
                Console.WriteLine("SenderDisplayName:" + message.SendUser.DisplayName);
                Console.WriteLine("ReceiverDisplayName:" + message.ReceiveUser.DisplayName);
                Console.WriteLine("=====================================");
            }
        }

        /// <summary>
        /// 阅读收件箱
        /// </summary>
        [Fact]
        public void DomainTest_ReadInbox()
        {
            ReadMessageService service = new ReadMessageService(
                new MessageRepository(new EntityFrameworkRepositoryContext()),
                new UserRepository(new EntityFrameworkRepositoryContext()));
            ICollection<Message> messages = service.ReadInbox("xiaocai");
            foreach (Message message in messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("SendTime:" + message.SendTime);
                Console.WriteLine("State:" + (message.State == MessageState.Read ? "Read" : "NoRead"));
                Console.WriteLine("SenderDisplayName:" + message.SendUser.DisplayName);
                Console.WriteLine("ReceiverDisplayName:" + message.ReceiveUser.DisplayName);
                Console.WriteLine("=====================================");
            }
        }
    }
}
