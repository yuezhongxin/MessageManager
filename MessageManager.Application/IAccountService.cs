/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application.DTO;
namespace MessageManager.Application
{
    /// <summary>
    /// Account管理应用层服务接口
    /// </summary>
    public interface IAccountService
    {
        #region Methods
        /// <summary>
        /// 通过登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        AccountDTO GetAccountByLoginName(string loginName);
        /// <summary>
        /// 通过显示名获取用户
        /// </summary>
        /// <param name="displayName">显示名</param>
        /// <returns></returns>
        AccountDTO GetAccountByDisplayName(string displayName);
        #endregion
    }
}
