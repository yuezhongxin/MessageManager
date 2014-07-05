/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Repositories.EntityFramework;

namespace MessageManager.Repositories
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        { }

        #region IUserRepository Members
        /// <summary>
        /// 通过登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        public User GetUserByLoginName(string loginName)
        {
            User user = new User(loginName, "小菜");
            user.ID = "07d62c85-a813-4ec7-b80f-c81d94408efa";
            return user;
            //return Get(new UserNameEqualsSpecification(name));
        }
        /// <summary>
        /// 通过显示名获取用户
        /// </summary>
        /// <param name="displayName">显示名</param>
        /// <returns></returns>
        public User GetUserByDisplayName(string displayName)
        {
            User user = new User("dashen", displayName);
            user.ID = "dba2b028-6dfe-47b6-ad30-435c53f06ca6";
            return user;
            //return Get(new UserNameEqualsSpecification(name));
        }
        #endregion
    }
}
