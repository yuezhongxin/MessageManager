/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
namespace MessageManager.Domain.DomainService
{
    public interface ISendMessageService
    {
        bool SendMessage(Message message);
    }
}
