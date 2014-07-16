/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using AutoMapper;
using MessageManager.Application.DTO;
using MessageManager.Domain.DomainService;
using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;
using MessageManager.Infrastructure;
using System.Collections.Generic;
using System.Linq;

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
                messageRepository.AddMessage(message);
                return OperationResponse.Success("发送成功");
                //return Context.Commit();
            }
            else
            {
                return OperationResponse.Error("发送失败");
            }
        }

        public OperationResponse ReplyMessage(string messageId, string title, string content, string replierLoginName)
        {
            Message replyMessage = messageRepository.GetByKey(messageId);
            if (replyMessage == null)
            {
                return OperationResponse.Error("未获取到消息");
            }
            Contact sender = contactRepository.GetContactByLoginName(replierLoginName);
            if (sender == null)
            {
                return OperationResponse.Error("未获取到回复人信息");
            }
            Message message = new Message(title, content, sender, replyMessage.Recipient);
            if (sendMessageService.SendMessage(message))
            {
                return OperationResponse.Success("回复成功");
                //messageRepository.Add(message);
                //return Context.Commit();
            }
            else
            {
                return OperationResponse.Error("回复失败");
            }
        }

        public OperationResponse ForwardMessage(string messageId, string title, string content, string senderLoginName, string receiverDisplayName)
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
                return OperationResponse.Success("转发成功");
                //messageRepository.Add(message);
                //return Context.Commit();
            }
            else
            {
                return OperationResponse.Error("转发失败");
            }
        }

        public OperationResponse<ICollection<MessageDTO>> GetUnreadMessageList(string readerLoginName)
        {
            Contact reader = contactRepository.GetContactByLoginName(readerLoginName);
            if (reader == null)
            {
                return new OperationResponse<ICollection<MessageDTO>>(false, "未获取到阅读人信息");
            }
            var messages = messageRepository.GetUnreadMessageList(reader);
            return new OperationResponse<ICollection<MessageDTO>>(true, "", Mapper.Map<ICollection<Message>, ICollection<MessageDTO>>(messages.ToList()));
        }

        public OperationResponse<int> GetUnreadMessageCount(string readerLoginName)
        {
            Contact reader = contactRepository.GetContactByLoginName(readerLoginName);
            if (reader == null)
            {
                return new OperationResponse<int>(false, "未获取到阅读人信息");
            }
            int messageCount = messageRepository.GetUnreadMessageCount(reader);
            return new OperationResponse<int>(true, "", messageCount);
        }

        public OperationResponse<ICollection<MessageDTO>> ReadInbox(string readerLoginName)
        {
            Contact reader = contactRepository.GetContactByLoginName(readerLoginName);
            if (reader == null)
            {
                return new OperationResponse<ICollection<MessageDTO>>(false, "未获取到阅读人信息");
            }
            var messages = messageRepository.GetInbox(reader);
            return new OperationResponse<ICollection<MessageDTO>>(true, "", Mapper.Map<ICollection<Message>, ICollection<MessageDTO>>(messages.ToList()));
        }

        public OperationResponse<ICollection<MessageDTO>> ReadOutbox(string readerLoginName)
        {
            Contact reader = contactRepository.GetContactByLoginName(readerLoginName);
            if (reader == null)
            {
                return new OperationResponse<ICollection<MessageDTO>>(false, "未获取到阅读人信息");
            }
            var messages = messageRepository.GetOutbox(reader);
            return new OperationResponse<ICollection<MessageDTO>>(true, "", Mapper.Map<ICollection<Message>, ICollection<MessageDTO>>(messages.ToList()));
        }

        public OperationResponse<MessageDTO> ReadMessageSender(string messageId, string readerLoginName)
        {
            Message message = messageRepository.GetMessageById(messageId);
            if (message == null)
            {
                return new OperationResponse<MessageDTO>(false, "未获取到消息");
            }
            Contact reader = contactRepository.GetContactByLoginName(readerLoginName);
            if (reader == null)
            {
                return new OperationResponse<MessageDTO>(false, "未获取到阅读人信息");
            }
            return new OperationResponse<MessageDTO>(true, "", Mapper.Map<Message, MessageDTO>(message));
        }

        public OperationResponse<MessageDTO> ReadMessageRecipient(string messageId, string readerLoginName)
        {
            Message message = messageRepository.GetMessageById(messageId);
            if (message == null)
            {
                return new OperationResponse<MessageDTO>(false, "未获取到消息");
            }
            Contact reader = contactRepository.GetContactByLoginName(readerLoginName);
            if (reader == null)
            {
                return new OperationResponse<MessageDTO>(false, "未获取到阅读人信息");
            }
            message.SetState(reader);
            messageRepository.UpdateMessage(message);
            return new OperationResponse<MessageDTO>(true, "", Mapper.Map<Message, MessageDTO>(message));
        }
        #endregion
    }
}