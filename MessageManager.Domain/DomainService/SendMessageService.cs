/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using System;
using System.Linq;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// SendMessage领域服务实现
    /// </summary>
    public class SendMessageService : ISendMessageService
    {
        public bool SendMessage(Message message, User sendUser, User receiveUser)
        {
            if (sendUser.SendMessages.Where(m => m.SendTime.Date == DateTime.Now.Date).Count() > 100)
            {
                throw new Exception("发件人一天只能发送一百个消息");
            }
            sendUser.SendMessages.Add(message);
            receiveUser.ReceiveMessages.Add(message);
            return true;
        }
    }
}
