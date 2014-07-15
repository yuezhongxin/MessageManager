/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// SendShortMessag领域服务实现-短消息发送
    /// </summary>
    public class SendSiteMessageService : ISendMessageService
    {
        public bool SendMessage(Message message)
        {
            return true;
        }
    }
}
