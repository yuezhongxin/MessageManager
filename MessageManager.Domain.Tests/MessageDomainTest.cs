/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Domain.ValueObject;
using System;
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
            IContact sender = new Sender("sender");
            IContact recipient = new Recipient("recipient");
            Message message = new Message("title", "content ", sender, recipient);
            Assert.True(sendMessageService.SendMessage(message));
        }

        /// <summary>
        /// 回复短消息
        /// </summary>
        [Fact]
        public void DomainTest_ReplyMessage()
        {
            ISendMessageService sendMessageService = new SendShortMessageService();
            Message readMessage = new Message("title", "content ", new Sender("sender"), new Recipient("recipient"));
            IContact reply = readMessage.Recipient;
            Message replyMessage = new Message("title", readMessage.Title + "content ", reply, readMessage.Sender);
            Assert.True(sendMessageService.SendMessage(replyMessage));
        }

        /// <summary>
        /// 转发短消息
        /// </summary>
        [Fact]
        public void DomainTest_RelayMessage()
        {
            ISendMessageService sendMessageService = new SendShortMessageService();
            Message readMessage = new Message("title", "content ", new Sender("sender"), new Recipient("recipient"));
            IContact recipient = new Sender("recipient");
            Message relayMessage = new Message("title", "content ", readMessage.Recipient, recipient);
            Assert.True(sendMessageService.SendMessage(relayMessage));
        }

        /// <summary>
        /// 阅读未读消息
        /// </summary>
        [Fact]
        public void DomainTest_NoReadMessage()
        {
            IContact recipient = new Recipient("recipient");
            var messages = new Inbox(recipient).GetNoReadMessage();
            foreach (Message message in messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("Sender:" + message.Sender.Name);
                Console.WriteLine("Recipient:" + message.Recipient.Name);
                Console.WriteLine("MessageState:" + (message.State == MessageState.NoRead ? "未读" : "已读"));
            }
        }

        /// <summary>
        /// 阅读未读消息个数
        /// </summary>
        [Fact]
        public void DomainTest_NoReadMessageCount()
        {
            IContact recipient = new Recipient("recipient");
            Console.WriteLine("未读消息个数：" + new Inbox(recipient).GetNoReadMessageCount());
        }

        /// <summary>
        /// 阅读收件箱
        /// </summary>
        [Fact]
        public void DomainTest_ReadInbox()
        {
            IContact recipient = new Recipient("recipient");
            MessageBox inbox = new Inbox(recipient);
            foreach (Message message in inbox.Messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("Sender:" + message.Sender.Name);
                Console.WriteLine("Recipient:" + message.Recipient.Name);
                Console.WriteLine("MessageState:" + (message.State == MessageState.NoRead ? "未读" : "已读"));
            }
        }

        /// <summary>
        /// 阅读发件箱
        /// </summary>
        [Fact]
        public void DomainTest_ReadOutbox()
        {
            IContact sender = new Sender("sender");
            MessageBox outbox = new Outbox(sender);
            foreach (Message message in outbox.Messages)
            {
                Console.WriteLine("ID:" + message.ID);
                Console.WriteLine("Title:" + message.Title);
                Console.WriteLine("Content:" + message.Content);
                Console.WriteLine("Sender:" + message.Sender.Name);
                Console.WriteLine("Recipient:" + message.Recipient.Name);
                Console.WriteLine("MessageState:" + (message.State == MessageState.NoRead ? "未读" : "已读"));
            }
        }

        /// <summary>
        /// 发送人阅读单条消息
        /// </summary>
        [Fact]
        public void DomainTest_SenderReadMessage()
        {
            IContact sender = new Sender("sender");
            Message message = new Outbox(sender).GetMessage("1");
            Console.WriteLine("ID:" + message.ID);
            Console.WriteLine("Title:" + message.Title);
            Console.WriteLine("Content:" + message.Content);
            Console.WriteLine("Sender:" + message.Sender.Name);
            Console.WriteLine("Recipient:" + message.Recipient.Name);
            Console.WriteLine("MessageState:" + (message.State == MessageState.NoRead ? "未读" : "已读"));
        }

        /// <summary>
        /// 接收人阅读单条消息
        /// </summary>
        [Fact]
        public void DomainTest_RecipientReadMessage()
        {
            IContact recipient = new Recipient("recipient");
            Message message = new Inbox(recipient).GetMessage("1");
            Console.WriteLine("Title:" + message.Title);
            Console.WriteLine("Content:" + message.Content);
            Console.WriteLine("Sender:" + message.Sender.Name);
            Console.WriteLine("Recipient:" + message.Recipient.Name);
            Console.WriteLine("MessageState:" + (message.State == MessageState.NoRead ? "未读" : "已读"));
        }

        /// <summary>
        /// 发送人删除消息
        /// </summary>
        [Fact]
        public void DomainTest_SenderDeleteMessage()
        {
            IContact sender = new Sender("sender");
            Message message = new Message("title", "content", new Sender("sender"), new Recipient("recipient"));
            Assert.True(new Outbox(sender).DeleteMessage(message));
        }

        /// <summary>
        /// 接收人删除消息
        /// </summary>
        [Fact]
        public void DomainTest_RecipientDeleteMessage()
        {
            IContact recipient = new Recipient("recipient");
            Message message = new Message("title", "content", new Sender("sender"), new Recipient("recipient"));
            Assert.True(new Inbox(recipient).DeleteMessage(message));
        }
    }
}
