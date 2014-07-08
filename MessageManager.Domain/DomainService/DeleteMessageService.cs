/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Infrastructure;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// DeleteMessage领域服务实现
    /// </summary>
    public class DeleteMessageService
    {
        public static OperationResponse DeleteMessage(Message message, User operateUser)
        {
            if (!(message.SendUser == operateUser || message.ReceiveUser == operateUser))
            {
                return OperationResponse.Error("您并不是收发件人，没有权限删除本条短消息");
            }
            //if (message.SendUser == operateUser)
            //{
            //    operateUser.SendMessages.Remove(message);
            //}
            //else
            //{
            //    operateUser.ReceiveMessages.Remove(message);
            //}
            return OperationResponse.Success("删除短消息成功");
        }
    }
}
