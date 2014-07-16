using MessageManager.Application;
using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
using System;
using System.Collections.Generic;

namespace MessageManager.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class MessageService : IMessageService
    {
        public OperationResponse SendMessage(string title, string content, string senderLoginName, string receiverDisplayName)
        {
            throw new NotImplementedException();
        }

        public OperationResponse ReplyMessage(string messageId, string title, string content, string replierLoginName)
        {
            throw new NotImplementedException();
        }

        public OperationResponse ForwardMessage(string messageId, string title, string content, string senderLoginName, string receiverDisplayName)
        {
            throw new NotImplementedException();
        }

        public OperationResponse<ICollection<MessageDTO>> GetUnreadMessageList(string readerLoginName)
        {
            throw new NotImplementedException();
        }

        public OperationResponse<int> GetUnreadMessageCount(string readerLoginName)
        {
            throw new NotImplementedException();
        }

        public OperationResponse<ICollection<MessageDTO>> ReadInbox(string readerLoginName)
        {
            throw new NotImplementedException();
        }

        public OperationResponse<ICollection<MessageDTO>> ReadOutbox(string readerLoginName)
        {
            throw new NotImplementedException();
        }

        public OperationResponse<MessageDTO> ReadMessageSender(string messageId, string readerLoginName)
        {
            throw new NotImplementedException();
        }

        public OperationResponse<MessageDTO> ReadMessageRecipient(string messageId, string readerLoginName)
        {
            throw new NotImplementedException();
        }
    }
}
