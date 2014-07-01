/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;

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
        /// <param name="sendUserDTO">发送人</param>
        /// <param name="receiveUserName">接受人</param>
        /// <returns></returns>
        bool SendMessage(string title, string content, UserDTO sendUserDTO, string receiveUserName);
        #endregion
    }
}
