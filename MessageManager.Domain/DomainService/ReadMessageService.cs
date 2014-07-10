/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// ReadMessage领域服务实现
    /// </summary>
    public class ReadMessageService
    {
        #region Private Fields
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        #endregion

        #region Ctor
        public ReadMessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }
        #endregion

        public Message ReadSingleMessage(string messageId, string readerLoginName)
        {
            User readUser = userRepository.GetUserByLoginName(readerLoginName);
            if (readUser == null)
            {
                throw new Exception("读取失败，未获取到读取人信息");
            }
            Message message = messageRepository.GetByKey(messageId);
            if (!(message.SendUser == readUser || message.ReceiveUser == readUser))
            {
                throw new Exception("您并不是收发件人，没有权限阅读本条短消息");
            }
            if (message.ReceiveUser == readUser && message.State == MessageState.NoRead)
            {
                message.State = MessageState.Read;
            }
            messageRepository.Update(message);
            return message;
        }

        public ICollection<Message> ReadOutbox(string readerLoginName)
        {
            User readUser = userRepository.GetUserByLoginName(readerLoginName);
            if (readUser == null)
            {
                throw new Exception("读取失败，未获取到读取人信息");
            }
            var messages = messageRepository.GetOutbox(readUser);
            if (messages.Where(m => m.SendUser == readUser).Count() == 0)
            {
                throw new Exception("您并不是发件人，没有权限阅读发件箱");
            }
            return messages;
        }

        public ICollection<Message> ReadInbox(string readerLoginName)
        {
            User readUser = userRepository.GetUserByLoginName(readerLoginName);
            if (readUser == null)
            {
                throw new Exception("读取失败，未获取到读取人信息");
            }
            var messages = messageRepository.GetInbox(readUser);
            if (messages.Where(m => m.ReceiveUser == readUser).Count() == 0)
            {
                throw new Exception("您并不是收件人，没有权限阅读收件箱");
            }
            return messages;
        }
    }
}
