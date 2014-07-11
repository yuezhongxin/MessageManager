/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using System;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// SendMessage领域服务实现
    /// </summary>
    public class SendMessageService : ISendMessageService
    {
        public bool SendMessage(Message message, User sendUser, User receiveUser)
        {
            throw new NotImplementedException();
        }
    }
}
