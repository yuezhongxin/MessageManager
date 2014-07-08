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
    /// ReplyMessage领域服务实现
    /// </summary>
    public class ReplyMessageService
    {
        public static OperationResponse<Message> ReplyMessage(Message message)
        {
            //示例业务规则，对象导航关联访问需要探讨
            if (message.SendUser.SendMessages.Where(m => m.SendTime.Date == DateTime.Now.Date).Count() > 200)
            {
                return new OperationResponse<Message>(false, "发件人一天之内只能回复200个短消息");
            }
            if (message.SendUser.SendMessages.Where(m => m.SendTime.Date == DateTime.Now.Date && m.ReceiveUser == message.ReceiveUser).Count() > 50)
            {
                return new OperationResponse<Message>(false, "发件人一天之内只能和同一人回复50个短消息");
            }
            //to do...
            return new OperationResponse<Message>(true, "回复消息成功", message);
        }
    }
}
