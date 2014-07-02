/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Repositories;

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
        #endregion
    }
}
