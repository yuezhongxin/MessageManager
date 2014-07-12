/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Repositories.EntityFramework;

namespace MessageManager.Repositories
{
    public class AccountRepository : EntityFrameworkRepository<Account>, IAccountRepository
    {
        public AccountRepository(IRepositoryContext context)
            : base(context)
        { }

        #region IAccountRepository Members
        /// <summary>
        /// 通过登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        public Account GetAccountByLoginName(string loginName)
        {
            return null;
            //Account account = new Account(loginName, "小菜");
            //account.ID = "1";
            //return account;
            //return Get(new AccountNameEqualsSpecification(name));
        }
        /// <summary>
        /// 通过显示名获取用户
        /// </summary>
        /// <param name="displayName">显示名</param>
        /// <returns></returns>
        public Account GetAccountByDisplayName(string displayName)
        {
            return null;
            //Account account = new Account("dashen", displayName);
            //account.ID = "2";
            //return account;
            //return Get(new AccountNameEqualsSpecification(name));
        }
        #endregion
    }
}
