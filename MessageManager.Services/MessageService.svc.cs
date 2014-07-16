using MessageManager.Application;
using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
using System.Collections.Generic;

namespace MessageManager.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class MessageService : IMessageService
    {
        #region 应用层服务接口
        private readonly IMessageService messageServiceImpl = ServiceLocator.Instance.GetService<IMessageService>();
        #endregion

        /// <returns></returns>
        public OperationResponse SendMessage(string title, string content, string senderLoginName, string receiverDisplayName)
        {
            //to do 异常处理，日志记录
            return messageServiceImpl.SendMessage(title, content, senderLoginName, receiverDisplayName);
        }

        public OperationResponse ReplyMessage(string messageId, string title, string content, string replierLoginName)
        {
            return messageServiceImpl.ReplyMessage(messageId, title, content, replierLoginName);
        }

        public OperationResponse ForwardMessage(string messageId, string title, string content, string senderLoginName, string receiverDisplayName)
        {
            return messageServiceImpl.ForwardMessage(messageId, title, content, senderLoginName, receiverDisplayName);
        }

        public OperationResponse<ICollection<MessageDTO>> GetUnreadMessageList(string readerLoginName)
        {
            return messageServiceImpl.GetUnreadMessageList(readerLoginName);
        }

        public OperationResponse<int> GetUnreadMessageCount(string readerLoginName)
        {
            return messageServiceImpl.GetUnreadMessageCount(readerLoginName);
        }

        public OperationResponse<ICollection<MessageDTO>> ReadInbox(string readerLoginName)
        {
            return messageServiceImpl.ReadInbox(readerLoginName);
        }

        public OperationResponse<ICollection<MessageDTO>> ReadOutbox(string readerLoginName)
        {
            return messageServiceImpl.ReadOutbox(readerLoginName);
        }

        public OperationResponse<MessageDTO> ReadMessageSender(string messageId, string readerLoginName)
        {
            return messageServiceImpl.ReadMessageSender(messageId, readerLoginName);
        }

        public OperationResponse<MessageDTO> ReadMessageRecipient(string messageId, string readerLoginName)
        {
            return messageServiceImpl.ReadMessageRecipient(messageId, readerLoginName);
        }
    }
}
