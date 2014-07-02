/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories;

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
        /// <param name="sendLoginUserName">发送人-登陆名</param>
        /// <param name="receiveDisplayUserName">接受人-接收人</param>
        /// <returns></returns>
        public bool SendMessage(string title, string content, string sendLoginUserName, string receiveDisplayUserName)
        {
            User sendUser = userRepository.GetUserByLoginName(sendLoginUserName);
            if (sendUser == null)
            {
                return false;
            }
            Message message = new Message(title, content, sendUser);
            User receiveUser = userRepository.GetUserByDisplayName(receiveDisplayUserName);
            if (receiveUser == null)
            {
                return false;
            }
            if (message.Send(receiveUser))
            {
                return true;
                //messageRepository.Add(message);
                //return messageRepository.Context.Commit();
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}