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
using MessageManager.Domain.DomainService;

namespace MessageManager.Application.Implementation
{
    /// <summary>
    /// Message管理应用层接口实现
    /// </summary>
    public class MessageServiceImpl : ApplicationService, IMessageService
    {
        #region Private Fields
        private readonly IMessageDomainService messageService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>MessageServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="messageRepository">“消息”服务实例。</param>
        public MessageServiceImpl(IMessageDomainService messageService)
        {
            this.messageService = messageService;
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
            var messages = messageService.GetMessagesBySendUser(Mapper.Map<UserDTO, User>(sendUserDTO));
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
            var messages = messageService.GetMessagesByReceiveUser(Mapper.Map<UserDTO, User>(receiveUserDTO));
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
            return messageService.DeleteMessage(Mapper.Map<MessageDTO, Message>(messageDTO));
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageDTO"></param>
        /// <returns></returns>
        public bool SendMessage(MessageDTO messageDTO)
        {
            return messageService.SendMessage(Mapper.Map<MessageDTO, Message>(messageDTO));
        }
        /// <summary>
        /// 查看消息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public MessageDTO ShowMessage(string ID, UserDTO CurrentUserDTO)
        {
            Message message = messageService.ShowMessage(ID, Mapper.Map<UserDTO, User>(CurrentUserDTO));
            return Mapper.Map<Message, MessageDTO>(message);
        }
        #endregion
    }
}
