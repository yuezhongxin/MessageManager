/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// Message领域服务实现
    /// </summary>
    public class MessageDomainService : IMessageDomainService
    {
        #region Private Fields
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        #endregion

        #region Ctor
        public MessageDomainService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }
        #endregion

        #region IMessageDomainService Members
        public bool DeleteMessage(Message message)
        {
            messageRepository.Remove(message);
            return messageRepository.Context.Commit();
        }
        public bool SendMessage(Message message)
        {
            message.LoadUserName(userRepository.GetUser(new User { Name = message.FromUserName })
                , userRepository.GetUser(new User { Name = message.ToUserName }));
            messageRepository.Add(message);
            return messageRepository.Context.Commit();
        }
        public Message ShowMessage(string ID,User CurrentUser)
        {
            Message message = messageRepository.GetByKey(ID);
            message.ReadMessage(userRepository.GetUser(new User { Name = CurrentUser.Name }));
            messageRepository.Update(message);
            messageRepository.Context.Commit();
            return message;
        }
        public IEnumerable<Message> GetMessagesBySendUser(User user)
        {
            User userResult = userRepository.GetUser(user);
            return messageRepository.GetMessagesBySendUser(userResult);
        }
        public IEnumerable<Message> GetMessagesByReceiveUser(User user)
        {
            User userResult = userRepository.GetUser(user);
            return messageRepository.GetMessagesByReceiveUser(userResult);
        }
        #endregion
    }
}
