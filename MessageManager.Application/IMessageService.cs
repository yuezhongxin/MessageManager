/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using MessageManager.Application.DTO;
using System.Collections.Generic;

namespace MessageManager.Application
{
    /// <summary>
    /// Message管理应用层服务接口
    /// </summary>
    public interface IMessageService
    {
        #region Methods
        /// <summary>
        /// 通过发送方获取消息列表
        /// </summary>
        /// <param name="sendUserDTO">发送方</param>
        /// <returns>消息列表</returns>
        IEnumerable<MessageDTO> GetMessagesBySendUser(UserDTO sendUserDTO);
        /// <summary>
        /// 通过接受方获取消息列表
        /// </summary>
        /// <param name="receiveUserDTO">接受方</param>
        /// <returns>消息列表</returns>
        IEnumerable<MessageDTO> GetMessagesByReceiveUser(UserDTO receiveUserDTO);
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="messageDTO"></param>
        /// <returns></returns>
        bool DeleteMessage(MessageDTO messageDTO);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageDTO"></param>
        /// <returns></returns>
        bool SendMessage(MessageDTO messageDTO);
        /// <summary>
        /// 查看消息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        MessageDTO ShowMessage(string id, UserDTO currentUserDTO);
        /// <summary>
        /// 获取未读消息数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int GetNoReadCount(UserDTO userDTO);
        #endregion
    }
}
