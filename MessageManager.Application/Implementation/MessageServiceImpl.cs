/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Infrastructure;

namespace MessageManager.Application.Implementation
{
    /// <summary>
    /// Message管理应用层接口实现
    /// </summary>
    public class MessageServiceImpl : ApplicationService, IMessageService
    {
        #region Private Fields
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>MessageServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>MessageServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="messageRepository">“消息”仓储实例。</param>
        /// <param name="userRepository">“用户”仓储实例。</param>
        public MessageServiceImpl(IRepositoryContext context,
            IMessageRepository messageRepository,
            IUserRepository userRepository)
            : base(context)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }
        #endregion

        #region IMessageService Members
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="senderLoginName">发件人-登陆名</param>
        /// <param name="receiverDisplayName">收件人-显示名</param>
        /// <returns></returns>
        public OperationResponse SendMessage(string title, string content, string senderLoginName, string receiverDisplayName)
        {
            User sendUser = userRepository.GetUserByLoginName(senderLoginName);
            if (sendUser == null)
            {
                return OperationResponse.Error("未获取到发件人信息");
            }
            User receiveUser = userRepository.GetUserByDisplayName(receiverDisplayName);
            if (receiveUser == null)
            {
                return OperationResponse.Error("未获取到收件人信息");
            }
            Message message = new Message(title, content, sendUser, receiveUser);
            OperationResponse<Message> serviceResult = SendMessageService.SendMessage(message);
            if (serviceResult.IsSuccess)
            {
                return serviceResult.GetOperationResponse();
                //messageRepository.Add(message);
                //return messageRepository.Context.Commit();
            }
            else
            {
                return serviceResult.GetOperationResponse();
            }
        }
        #endregion
    }
}