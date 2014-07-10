/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using System;
using System.Collections.Generic;

namespace MessageManager.Domain.Repositories
{
    /// <summary>
    /// 表示继承于该接口的类型是作用在“消息”聚合根上的仓储类型。
    /// </summary>
    public interface IMessageRepository : IRepository<Message>
    {
        int GetMessageCount(User sendUser, DateTime sendTime);
        ICollection<Message> GetOutbox(User readUser);
        ICollection<Message> GetInbox(User readUser);
    }
}
