/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using AutoMapper;
using MessageManager.Application.DTO;
using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;

namespace MessageManager.Application.Implementation
{
    /// <summary>
    /// Account管理应用层接口实现
    /// </summary>
    public class AccountServiceImpl : ApplicationService, IAccountService
    {
        #region Private Fields
        private readonly IAccountRepository accountRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>AccountServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>AccountServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="accountRepository">“用户”仓储实例。</param>
        public AccountServiceImpl(IRepositoryContext context,
            IAccountRepository accountRepository)
            : base(context)
        {
            this.accountRepository = accountRepository;
        }
        #endregion

        #region IAccountService Members
        /// <summary>
        /// 通过登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        public AccountDTO GetAccountByLoginName(string loginName)
        {
            return Mapper.Map<Account, AccountDTO>(accountRepository.GetAccountByLoginName(loginName));
        }
        /// <summary>
        /// 通过显示名获取用户
        /// </summary>
        /// <param name="displayName">显示名</param>
        /// <returns></returns>
        public AccountDTO GetAccountByDisplayName(string displayName)
        {
            return Mapper.Map<Account, AccountDTO>(accountRepository.GetAccountByDisplayName(displayName));
        }
        #endregion
    }
}