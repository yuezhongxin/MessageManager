﻿/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
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
        private readonly IAccountRepository accountRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>MessageServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>MessageServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="messageRepository">“消息”仓储实例。</param>
        /// <param name="accountRepository">“用户”仓储实例。</param>
        public MessageServiceImpl(IRepositoryContext context,
            IMessageRepository messageRepository,
            IAccountRepository accountRepository)
            : base(context)
        {
            this.messageRepository = messageRepository;
            this.accountRepository = accountRepository;
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
            //Account sendAccount = accountRepository.GetAccountByLoginName(senderLoginName);
            //if (sendAccount == null)
            //{
            //    return OperationResponse.Error("未获取到发件人信息");
            //}
            //Account receiveAccount = accountRepository.GetAccountByDisplayName(receiverDisplayName);
            //if (receiveAccount == null)
            //{
            //    return OperationResponse.Error("未获取到收件人信息");
            //}
            //Message message = new Message(title, content, sendAccount, receiveAccount);
            //OperationResponse<Message> serviceResult = VerifyMessageService.VerifyMessage(message);
            //if (serviceResult.IsSuccess)
            //{
            //    return serviceResult.GetOperationResponse();
            //    //messageRepository.Add(message);
            //    //return messageRepository.Context.Commit();
            //}
            //else
            //{
            //    return serviceResult.GetOperationResponse();
            //}
            return null;
        }

        /// <summary>
        /// 阅读消息
        /// </summary>
        /// <param name="messageId">消息唯一标示</param>
        /// <param name="readerLoginName">阅读人-登陆名</param>
        /// <returns></returns>
        public OperationResponse<MessageDTO> ReadMessage(string messageId, string readerLoginName)
        {
            //Account readAccount = accountRepository.GetAccountByLoginName(readerLoginName);
            //if (readAccount == null)
            //{
            //    return new OperationResponse<MessageDTO>(false, "未获取到阅读人信息");
            //}
            //Message message = messageRepository.GetByKey(messageId);
            //if (message == null)
            //{
            //    return new OperationResponse<MessageDTO>(false, "未获取到消息");
            //}
            //OperationResponse<Message> serviceResult = ReadMessageService.ReadMessage(message, readAccount);
            //if (serviceResult.IsSuccess)
            //{
            //    //messageRepository.Update(message);
            //    //messageRepository.Context.Commit();
            //    return new OperationResponse<MessageDTO>(serviceResult.IsSuccess, serviceResult.Message, Mapper.Map<Message, MessageDTO>(message));
            //}
            //else
            //{
            //    return new OperationResponse<MessageDTO>(serviceResult.IsSuccess, serviceResult.Message);
            //}
            return null;
        }

        /// <summary>
        /// 回复消息
        /// </summary>
        /// <param name="messageId">消息唯一标示</param>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="replierLoginName">回复人-登陆名</param>
        /// <returns></returns>
        public OperationResponse ReplyMessage(string messageId, string title, string content, string replierLoginName)
        {
            //Message message = messageRepository.GetByKey(messageId);
            //if (message == null)
            //{
            //    return new OperationResponse(false, "未获取到消息");
            //}
            //Account replyAccount = accountRepository.GetAccountByLoginName(replierLoginName);
            //if (replyAccount == null)
            //{
            //    return OperationResponse.Error("未获取到回复人信息");
            //}
            //Message replyMessage = new Message(title, content, replyAccount, message.SendAccount);
            //OperationResponse<Message> serviceResult = VerifyMessageService.VerifyMessage(message);
            //if (serviceResult.IsSuccess)
            //{
            //    return serviceResult.GetOperationResponse();
            //    //messageRepository.Add(message);
            //    //return messageRepository.Context.Commit();
            //}
            //else
            //{
            //    return serviceResult.GetOperationResponse();
            //}
            return null;
        }
        #endregion
    }
}