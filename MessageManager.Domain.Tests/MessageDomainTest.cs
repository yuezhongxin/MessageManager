/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ISendMessageService sendMessageService = new SendSiteMessageService();
            Contact sender = new Sender("sender");
            Contact recipient = new Recipient("recipient");
            Message message = new Message("title", "content ", sender, recipient);
            Assert.True(sendMessageService.SendMessage(message));
        }

        /// <summary>
        /// 回复短消息
        /// </summary>
        [Fact]
        public void DomainTest_ReplyMessage()
        {
            ISendMessageService sendMessageService = new SendSiteMessageService();
            Message readMessage = new Message("title", "content ", new Sender("sender"), new Recipient("recipient"));
            Contact reply = readMessage.Recipient;
            Message replyMessage = new Message("title", readMessage.Title + "content ", reply, readMessage.Sender);
            Assert.True(sendMessageService.SendMessage(replyMessage));
        }

        /// <summary>
        /// 转发短消息
        /// </summary>
        [Fact]
        public void DomainTest_ForwardMessage()
        {
            ISendMessageService sendMessageService = new SendSiteMessageService();
            Message readMessage = new Message("title", "content ", new Sender("sender"), new Recipient("recipient"));
            Contact recipient = new Sender("recipient");
            Message relayMessage = new Message("title", "content ", readMessage.Recipient, recipient);
            Assert.True(sendMessageService.SendMessage(relayMessage));
        }

        /// <summary>
        /// 获取未读消息列表
        /// </summary>
        [Fact]
        public void DomainTest_GetUnreadMessageList()
        {
            Contact recipient = new Recipient("recipient");
            var messages = new List<Message>() { new Message("title", "content", new Sender("sender"), recipient) }.Where(m => m.Recipient == recipient);
            foreach (Message message in messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("Sender:" + message.Sender.Name);
                Console.WriteLine("Recipient:" + message.Recipient.Name);
                Console.WriteLine("MessageState:" + (message.State == MessageState.Unread ? "未读" : "已读"));
            }
        }

        /// <summary>
        /// 获取未读消息个数
        /// </summary>
        [Fact]
        public void DomainTest_GetUnreadMessageCount()
        {
            Contact recipient = new Recipient("recipient");
            int messageCount = new List<Message>() { new Message("title", "content", new Sender("sender"), recipient) }.Where(m => m.Recipient == recipient).Count();
            Console.WriteLine("未读消息个数：" + messageCount);
        }

        /// <summary>
        /// 阅读收件箱
        /// </summary>
        [Fact]
        public void DomainTest_ReadInbox()
        {
            Contact recipient = new Recipient("recipient");
            var messages = new List<Message>() { new Message("title", "content", new Sender("sender"), recipient) }.Where(m => m.Recipient == recipient);
            foreach (Message message in messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("Sender:" + message.Sender.Name);
                Console.WriteLine("Recipient:" + message.Recipient.Name);
                Console.WriteLine("MessageState:" + (message.State == MessageState.Unread ? "未读" : "已读"));
            }
        }

        /// <summary>
        /// 阅读发件箱
        /// </summary>
        [Fact]
        public void DomainTest_ReadOutbox()
        {
            Contact sender = new Sender("sender");
            var messages = new List<Message>() { new Message("title", "content", sender, new Recipient("recipient")) }.Where(m => m.Sender == sender);
            foreach (Message message in messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("Sender:" + message.Sender.Name);
                Console.WriteLine("Recipient:" + message.Recipient.Name);
                Console.WriteLine("MessageState:" + (message.State == MessageState.Unread ? "未读" : "已读"));
            }
        }

        /// <summary>
        /// 发送人阅读单条消息
        /// </summary>
        [Fact]
        public void DomainTest_ReadMessageSender()
        {
            Contact sender = new Sender("sender");
            Message message = new Message("title", "content", sender, new Recipient("recipient"));
            Console.WriteLine("ID:" + message.ID);
            Console.WriteLine("Title:" + message.Title);
            Console.WriteLine("Content:" + message.Content);
            Console.WriteLine("Sender:" + message.Sender.Name);
            Console.WriteLine("Recipient:" + message.Recipient.Name);
            Console.WriteLine("MessageState:" + (message.State == MessageState.Unread ? "未读" : "已读"));
        }

        /// <summary>
        /// 接收人阅读单条消息
        /// </summary>
        [Fact]
        public void DomainTest_ReadMessageRecipient()
        {
            Contact recipient = new Recipient("recipient");
            Message message = new Message("title", "content", new Sender("sender"), recipient);
            message.SetState(recipient);
            Console.WriteLine("Title:" + message.Title);
            Console.WriteLine("Content:" + message.Content);
            Console.WriteLine("Sender:" + message.Sender.Name);
            Console.WriteLine("Recipient:" + message.Recipient.Name);
            Console.WriteLine("MessageState:" + (message.State == MessageState.Unread ? "未读" : "已读"));
        }
    }
}
