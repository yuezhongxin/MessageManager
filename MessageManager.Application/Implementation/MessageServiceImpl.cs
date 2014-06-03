/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using AutoMapper;
using MessageManager.Application.DTO;
using MessageManager.Domain;
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
            :base(context)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }
        #endregion

        #region IMessageService Members
        /// <summary>
        /// 通过发送方获取消息列表
        /// </summary>
        /// <param name="userDTO">发送方</param>
        /// <returns>消息列表</returns>
        public IEnumerable<MessageDTO> GetMessagesBySendUser(UserDTO sendUserDTO)
        {
            //User user = userRepository.GetUserByName(sendUserDTO.Name);
            var messages = messageRepository.GetMessagesBySendUser(Mapper.Map<UserDTO, User>(sendUserDTO));
            if (messages == null)
                return null;
            var ret = new List<MessageDTO>();
            foreach (var message in messages)
            {
                ret.Add(Mapper.Map<Message, MessageDTO>(message));
            }
            return ret;
        }
        /// <summary>
        /// 通过接受方获取消息列表
        /// </summary>
        /// <param name="userDTO">接受方</param>
        /// <returns>消息列表</returns>
        public IEnumerable<MessageDTO> GetMessagesByReceiveUser(UserDTO receiveUserDTO)
        {
            //User user = userRepository.GetUserByName(receiveUserDTO.Name);
            var messages = messageRepository.GetMessagesByReceiveUser(Mapper.Map<UserDTO, User>(receiveUserDTO));
            if (messages == null)
                return null;
            var ret = new List<MessageDTO>();
            foreach (var message in messages)
            {
                ret.Add(Mapper.Map<Message, MessageDTO>(message));
            }
            return ret;
        }
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="messageDTO"></param>
        /// <returns></returns>
        public bool DeleteMessage(MessageDTO messageDTO)
        {
            messageRepository.Remove(Mapper.Map<MessageDTO, Message>(messageDTO));
            return messageRepository.Context.Commit();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageDTO"></param>
        /// <returns></returns>
        public bool SendMessage(MessageDTO messageDTO)
        {
            Message message = Mapper.Map<MessageDTO, Message>(messageDTO);
            message.FromUserID = userRepository.GetUserByName(messageDTO.FromUserName).ID;
            message.ToUserID = userRepository.GetUserByName(messageDTO.ToUserName).ID;
            messageRepository.Add(message);
            return messageRepository.Context.Commit();
        }
        /// <summary>
        /// 查看消息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public MessageDTO ShowMessage(string ID, string isRead)
        {
            Message message = messageRepository.GetByKey(ID);
            if (isRead == "1")
            {
                message.IsRead = true;
                messageRepository.Update(message);
                messageRepository.Context.Commit();
            }
            return Mapper.Map<Message, MessageDTO>(message);
        }
        #endregion
    }
}
