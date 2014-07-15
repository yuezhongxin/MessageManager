/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;
using MessageManager.Infrastructure;
using System.Collections.Generic;

namespace MessageManager.Application.Implementation
{
    /// <summary>
    /// Message管理应用层接口实现
    /// </summary>
    public class MessageServiceImpl : ApplicationService, IMessageService
    {
        #region Private Fields
        private readonly IMessageRepository messageRepository;
        private readonly IContactRepository contactRepository;
        private readonly ISendMessageService sendMessageService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>MessageServiceImpl</c>类型的实例。
        /// </summary>
        public MessageServiceImpl(IRepositoryContext context,
            IMessageRepository messageRepository,
            IContactRepository contactRepository,
            ISendMessageService sendMessageService)
            : base(context)
        {
            this.messageRepository = messageRepository;
            this.contactRepository = contactRepository;
            this.sendMessageService = sendMessageService;
        }
        #endregion

        #region IMessageService Members
        public OperationResponse SendMessage(string title, string content, string senderLoginName, string receiverDisplayName)
        {
            Contact sender = contactRepository.GetContactByLoginName(senderLoginName);
            if (sender == null)
            {
                return OperationResponse.Error("未获取到发件人信息");
            }
            Contact receiver = contactRepository.GetContactByDisplayName(receiverDisplayName);
            if (receiver == null)
            {
                return OperationResponse.Error("未获取到收件人信息");
            }
            Message message = new Message(title, content, sender, receiver);
            if (sendMessageService.SendMessage(message))
            {
                return OperationResponse.Success("发送成功");
                //messageRepository.Add(message);
                //return messageRepository.Context.Commit();
            }
            else
            {
                return OperationResponse.Error("发送失败");
            }
        }

        public OperationResponse ReplyMessage(string messageId, string title, string content, string replierLoginName)
        {
            throw new System.NotImplementedException();
        }

        public OperationResponse ForwardMessage(string messageId, string title, string content, string senderLoginName, string receiverDisplayName)
        {
            throw new System.NotImplementedException();
        }

        public OperationResponse<ICollection<MessageDTO>> GetUnreadMessageList(string messageId, string readerLoginName)
        {
            throw new System.NotImplementedException();
        }

        public OperationResponse<int> GetUnreadMessageCount(string messageId, string readerLoginName)
        {
            throw new System.NotImplementedException();
        }

        public OperationResponse<ICollection<MessageDTO>> ReadInbox(string readerLoginName)
        {
            throw new System.NotImplementedException();
        }

        public OperationResponse<ICollection<MessageDTO>> ReadOutbox(string readerLoginName)
        {
            throw new System.NotImplementedException();
        }

        public OperationResponse<MessageDTO> ReadMessageSender(string messageId, string readerLoginName)
        {
            throw new System.NotImplementedException();
        }

        public OperationResponse<MessageDTO> ReadMessageRecipient(string messageId, string readerLoginName)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}