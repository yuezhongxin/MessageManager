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
    /// ReplyMessage领域服务实现
    /// </summary>
    public class ReplyMessageService
    {
        #region Private Fields
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        #endregion

        #region Ctor
        public ReplyMessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }
        #endregion

        public Message ReplyMessage(string title, string content, string replyLoginName, string receiverDisplayName)
        {
            User replyUser = userRepository.GetUserByLoginName(replyLoginName);
            if (replyUser == null)
            {
                throw new Exception("发送失败，未获取到回复人信息");
            }
            User receiveUser = userRepository.GetUserByDisplayName(receiverDisplayName);
            if (receiveUser == null)
            {
                throw new Exception("发送失败，未获取到收件人信息");
            }
            Message message = new Message(title, content, replyUser, receiveUser);
            if (messageRepository.GetMessageCount(replyUser, DateTime.Now) > 100)
            {
                throw new Exception("回复人一天之内只能回复100个短消息");
            }
            messageRepository.Add(message);
            return message;
        }
    }
}
