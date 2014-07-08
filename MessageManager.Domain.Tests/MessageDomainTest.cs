/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using System.Collections.Generic;
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
            User sendUser = new User("xiaocai", "小菜");
            User receiveUser = new User("dashen", "大神");
            Message message = new Message("test", "test", sendUser, receiveUser);
            Assert.True(SendMessageService.SendMessage(message).IsSuccess);
        }

        /// <summary>
        /// 阅读单条消息
        /// </summary>
        [Fact]
        public void DomainTest_ReadSingleMessage()
        {
            User readUser = new User("xiaocai", "小菜");
            Message message = new Message("test", "test", readUser, new User("dashen", "大神"));
            Assert.True(ReadMessageService.ReadSingleMessage(message, readUser).IsSuccess);
        }

        /// <summary>
        /// 回复消息
        /// </summary>
        [Fact]
        public void DomainTest_ReplyMessage()
        {
            User replyUser = new User("dashen", "大神");
            Message message = new Message("test", "test", new User("xiaocai", "小菜"), replyUser);
            Assert.True(ReplyMessageService.ReplyMessage(message).IsSuccess);
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        [Fact]
        public void DomainTest_DeleteMessage()
        {
            User operateUser = new User("xiaocai", "小菜");
            Message message = new Message("test", "test", operateUser, new User("dashen", "大神"));
            Assert.True(DeleteMessageService.DeleteMessage(message, operateUser).IsSuccess);
        }

        /// <summary>
        /// 阅读发件箱
        /// </summary>
        [Fact]
        public void DomainTest_ReadOutbox()
        {
            User readUser = new User("xiaocai", "小菜");
            ICollection<Message> messages = new List<Message> { 
                new Message("test1", "test", readUser, new User("dashen", "大神")) ,
                new Message("test2", "test", readUser, new User("dashen", "大神")) ,
                new Message("test3", "test", readUser, new User("dashen", "大神")) };
            Assert.True(ReadMessageService.ReadOutbox(messages, readUser).IsSuccess);
        }

        /// <summary>
        /// 阅读收件箱
        /// </summary>
        [Fact]
        public void DomainTest_ReadInbox()
        {
            User readUser = new User("xiaocai", "小菜");
            ICollection<Message> messages = new List<Message> { 
                new Message("test1", "test", readUser, new User("dashen", "大神")) ,
                new Message("test2", "test", readUser, new User("dashen", "大神")) ,
                new Message("test3", "test", readUser, new User("dashen", "大神")) };
            Assert.True(ReadMessageService.ReadInbox(messages, readUser).IsSuccess);
        }
    }
}
