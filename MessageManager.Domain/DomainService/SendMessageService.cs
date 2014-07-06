/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Infrastructure;
using System;
using System.Linq;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// SendMessage领域服务实现
    /// </summary>
    public class SendMessageService
    {
        public static OperationResponse<Message> SendMessage(Message message)
        {
            if (message.SendUser == message.ReceiveUser)
            {
                return new OperationResponse<Message>(false, "发件人和收件人不能为同一人");
            }
            if (message.SendUser.SendMessages.Where(m => m.SendTime == DateTime.Now).Count() > 100)
            {
                return new OperationResponse<Message>(false, "发件人一天之内只能发送一百个短消息");
            }
            return new OperationResponse<Message>(true, "发送消息成功", message);
        }
    }
}
