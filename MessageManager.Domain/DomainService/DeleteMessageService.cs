/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using System;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// DeleteMessage领域服务实现
    /// </summary>
    public class DeleteMessageService
    {
        #region Private Fields
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        #endregion

        #region Ctor
        public DeleteMessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }
        #endregion

        public bool DeleteMessage(string messageId, string operateLoginName)
        {
            User operateUser = userRepository.GetUserByLoginName(operateLoginName);
            if (operateUser == null)
            {
                throw new Exception("删除失败，未获取到操作人信息");
            }
            Message message = messageRepository.GetByKey(messageId);
            if (!(message.SendUser == operateUser || message.ReceiveUser == operateUser))
            {
                throw new Exception("您并不是收发件人，没有权限删除本条短消息");
            }
            messageRepository.Remove(message);
            return true;
        }
    }
}
