/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// Message领域服务接口
    /// </summary>
    public interface IMessageDomainService
    {
        #region IMessageDomainService Members
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        bool DeleteMessage(Message message);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        bool SendMessage(Message message);
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Message ShowMessage(string id, User currentUser);
        /// <summary>
        /// 通过发送方获取消息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IEnumerable<Message> GetMessagesBySendUser(User user);
        /// <summary>
        /// 通过接收方获取消息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IEnumerable<Message> GetMessagesByReceiveUser(User user);
        /// <summary>
        /// 获取未读消息数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int GetNoReadCount(User user);
        #endregion
    }
}
