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
            //示例业务规则，对象导航关联访问需要探讨
            if (message.SendUser.SendMessages.Where(m => m.SendTime.Date == DateTime.Now.Date).Count() > 200)
            {
                return new OperationResponse<Message>(false, "发件人一天之内只能发送200个短消息");
            }
            if (message.SendUser.SendMessages.Where(m => m.SendTime.Date == DateTime.Now.Date && m.ReceiveUser == message.ReceiveUser).Count() > 50)
            {
                return new OperationResponse<Message>(false, "发件人一天之内只能和同一人发送50个短消息");
            }
            //to do...
            return new OperationResponse<Message>(true, "发送消息成功", message);
        }
    }
}
