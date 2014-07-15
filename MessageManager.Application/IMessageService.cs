/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
using System.Collections.Generic;
namespace MessageManager.Application
{
    /// <summary>
    /// Message管理应用层服务接口
    /// </summary>
    public interface IMessageService
    {
        #region Methods
        OperationResponse SendMessage(string title, string content, string senderLoginName, string receiverDisplayName);

        OperationResponse ReplyMessage(string messageId, string title, string content, string replierLoginName);

        OperationResponse ForwardMessage(string messageId, string title, string content, string senderLoginName, string receiverDisplayName);

        OperationResponse<ICollection<MessageDTO>> GetUnreadMessageList(string messageId, string readerLoginName);

        OperationResponse<int> GetUnreadMessageCount(string messageId, string readerLoginName);

        OperationResponse<ICollection<MessageDTO>> ReadInbox(string readerLoginName);

        OperationResponse<ICollection<MessageDTO>> ReadOutbox(string readerLoginName);

        OperationResponse<MessageDTO> ReadMessageSender(string messageId, string readerLoginName);

        OperationResponse<MessageDTO> ReadMessageRecipient(string messageId, string readerLoginName);
        #endregion
    }
}
