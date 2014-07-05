/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
namespace MessageManager.Domain.Repositories
{
    /// <summary>
    /// 表示继承于该接口的类型是作用在“用户”聚合根上的仓储类型。
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 通过登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        User GetUserByLoginName(string loginName);
        /// <summary>
        /// 通过显示名获取用户
        /// </summary>
        /// <param name="displayName">显示名</param>
        /// <returns></returns>
        User GetUserByDisplayName(string displayName);
    }
}
