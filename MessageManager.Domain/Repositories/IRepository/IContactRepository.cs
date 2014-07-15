using MessageManager.Domain.ValueObject;

namespace MessageManager.Domain.Repositories
{
    public interface IContactRepository
    {
        /// <summary>
        /// 通过登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        IContact GetContactByLoginName(string loginName);
        /// <summary>
        /// 通过显示名获取用户
        /// </summary>
        /// <param name="displayName">显示名</param>
        /// <returns></returns>
        IContact GetContactByDisplayName(string displayName);
    }
}
