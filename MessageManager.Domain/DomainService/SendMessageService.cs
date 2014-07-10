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
    /// SendMessage领域服务实现
    /// </summary>
    public class SendMessageService
    {
        #region Private Fields
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        #endregion

        #region Ctor
        public SendMessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }
        #endregion

        public Message SendMessage(string title, string content, string senderLoginName, string receiverDisplayName)
        {
            User sendUser = userRepository.GetUserByLoginName(senderLoginName);
            if (sendUser == null)
            {
                throw new Exception("发送失败，未获取到发件人信息");
            }
            User receiveUser = userRepository.GetUserByDisplayName(receiverDisplayName);
            if (receiveUser == null)
            {
                throw new Exception("发送失败，未获取到收件人信息");
            }
            Message message = new Message(title, content, sendUser, receiveUser);
            if (messageRepository.GetMessageCount(sendUser, DateTime.Now) > 200)
            {
                throw new Exception("发件人一天之内只能发送200个短消息");
            }
            messageRepository.Add(message);
            return message;
        }
    }
}
