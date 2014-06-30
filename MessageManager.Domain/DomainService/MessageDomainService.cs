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
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public bool SendMessage(Message message)
        {
            messageRepository.Add(message);
            return messageRepository.Context.Commit();
        }
        #endregion
    }
}
