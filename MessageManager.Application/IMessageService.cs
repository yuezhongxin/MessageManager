/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/


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
        /// <param name="sendLoginUserName">发送人-登陆名</param>
        /// <param name="receiveDisplayUserName">接受人-接收人</param>
        /// <returns></returns>
        bool SendMessage(string title, string content, string sendLoginUserName, string receiveDisplayUserName);
        #endregion
    }
}
