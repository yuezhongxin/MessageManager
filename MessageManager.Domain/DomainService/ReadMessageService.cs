/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.ValueObject;
using MessageManager.Infrastructure;
using System.Collections.Generic;
using System.Linq;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// ReadMessage领域服务实现
    /// </summary>
    public class ReadMessageService
    {
        public static OperationResponse<Message> ReadSingleMessage(Message message, User readUser)
        {
            if (!(message.SendUser == readUser || message.ReceiveUser == readUser))
            {
                return new OperationResponse<Message>(false, "您并不是收发件人，没有权限阅读本条短消息");
            }
            if (message.ReceiveUser == readUser && message.State == MessageState.NoRead)
            {
                message.State = MessageState.Read;
            }
            return new OperationResponse<Message>(true, "", message);
        }

        public static OperationResponse<ICollection<Message>> ReadOutbox(ICollection<Message> messages, User readUser)
        {
            if (messages.Where(m => m.SendUser == readUser).Count() > 0)
            {
                return new OperationResponse<ICollection<Message>>(false, "您并不是发件人，没有权限阅读发件箱");
            }
            return new OperationResponse<ICollection<Message>>(true, "", messages);
        }

        public static OperationResponse<ICollection<Message>> ReadInbox(ICollection<Message> messages, User readUser)
        {
            if (messages.Where(m => m.ReceiveUser == readUser).Count() > 0)
            {
                return new OperationResponse<ICollection<Message>>(false, "您并不是收件人，没有权限阅读收件箱");
            }
            return new OperationResponse<ICollection<Message>>(true, "", messages);
        }
    }
}
