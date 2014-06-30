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
        /// 发送消息
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        bool SendMessage(Message message);
        #endregion
    }
}
