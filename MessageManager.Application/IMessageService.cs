/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
using System.Collections.Generic;
using System.ServiceModel;
namespace MessageManager.Application
{
    /// <summary>
    /// Message管理应用层服务契约
    /// </summary>
    [ServiceContract(Name = "MessageService")]
    public interface IMessageService
    {
        #region Methods
        [OperationContract]
        OperationResponse SendMessage(string title, string content, string senderLoginName, string receiverDisplayName);

        [OperationContract]
        OperationResponse ReplyMessage(string messageId, string title, string content, string replierLoginName);

        [OperationContract]
        OperationResponse ForwardMessage(string messageId, string title, string content, string senderLoginName, string receiverDisplayName);

        [OperationContract]
        OperationResponse<ICollection<MessageDTO>> GetUnreadMessageList(string readerLoginName);

        [OperationContract]
        OperationResponse<int> GetUnreadMessageCount(string readerLoginName);

        [OperationContract]
        OperationResponse<ICollection<MessageDTO>> ReadInbox(string readerLoginName);

        [OperationContract]
        OperationResponse<ICollection<MessageDTO>> ReadOutbox(string readerLoginName);

        [OperationContract]
        OperationResponse<MessageDTO> ReadMessageSender(string messageId, string readerLoginName);

        [OperationContract]
        OperationResponse<MessageDTO> ReadMessageRecipient(string messageId, string readerLoginName);
        #endregion
    }
}
