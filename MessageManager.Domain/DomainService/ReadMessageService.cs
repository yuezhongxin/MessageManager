/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.ValueObject;
using MessageManager.Infrastructure;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// ReadMessage领域服务实现
    /// </summary>
    public class ReadMessageService
    {
        public static OperationResponse<Message> ReadMessage(Message message, User readUser)
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
    }
}
