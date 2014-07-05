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
    /// User管理应用层接口实现
    /// </summary>
    public class UserServiceImpl : ApplicationService, IUserService
    {
        #region Private Fields
        private readonly IUserRepository userRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>UserServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>UserServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="userRepository">“用户”仓储实例。</param>
        public UserServiceImpl(IRepositoryContext context,
            IUserRepository userRepository)
            : base(context)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region IUserService Members
        /// <summary>
        /// 通过登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        public UserDTO GetUserByLoginName(string loginName)
        {
            return Mapper.Map<User, UserDTO>(userRepository.GetUserByLoginName(loginName));
        }
        /// <summary>
        /// 通过显示名获取用户
        /// </summary>
        /// <param name="displayName">显示名</param>
        /// <returns></returns>
        public UserDTO GetUserByDisplayName(string displayName)
        {
            return Mapper.Map<User, UserDTO>(userRepository.GetUserByDisplayName(displayName));
        }
        #endregion
    }
}