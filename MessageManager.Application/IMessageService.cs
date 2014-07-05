/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

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
        #endregion
    }
}
