/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
namespace MessageManager.Application
{
    /// <summary>
    /// Message管理应用层服务接口
    /// </summary>
    public interface IMessageService
    {
        #region Methods
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="senderLoginName">发件人-登陆名</param>
        /// <param name="receiverDisplayName">收件人-显示名</param>
        /// <returns></returns>
        OperationResponse SendMessage(string title, string content, string senderLoginName, string receiverDisplayName);

        /// <summary>
        /// 阅读消息
        /// </summary>
        /// <param name="messageId">消息唯一标示</param>
        /// <param name="readerLoginName">阅读人-登陆名</param>
        /// <returns></returns>
        OperationResponse<MessageDTO> ReadMessage(string messageId, string readerLoginName);

        /// <summary>
        /// 回复消息
        /// </summary>
        /// <param name="messageId">消息唯一标示</param>
        /// <param name="title">消息标题</param>
        /// <param name="content">消息内容</param>
        /// <param name="replierLoginName">回复人-登陆名</param>
        /// <returns></returns>
        OperationResponse ReplyMessage(string messageId, string title, string content, string replierLoginName);
        #endregion
    }
}
