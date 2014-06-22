/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using AutoMapper;
using MessageManager.Application.DTO;
using MessageManager.Domain;
using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.DomainService;

namespace MessageManager.Application.Implementation
{
    /// <summary>
    /// Message管理应用层接口实现
    /// </summary>
    public class UserServiceImpl : ApplicationService, IUserService
    {
        #region Private Fields
        private readonly UserDomainService userDomainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>UserServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="userRepository">“用户”服务实例。</param>
        public UserServiceImpl(UserDomainService userDomainService)
        {
            this.userDomainService = userDomainService;
        }
        #endregion

        #region IUserService Members
        /// <summary>
        /// 判断用户是否存在（初始化用到）
        /// </summary>
        /// <returns></returns>
        public bool ExistUser()
        {
            return userDomainService.ExistUser();
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="usersDTO">用户列表</param>
        /// <returns></returns>
        public bool AddUser(IList<UserDTO> usersDTO)
        {
            return userDomainService.AddUser(Mapper.Map<IList<User>>(usersDTO));
        }
        #endregion
    }
}
