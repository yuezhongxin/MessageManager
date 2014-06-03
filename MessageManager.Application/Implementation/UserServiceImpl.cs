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

namespace MessageManager.Application.Implementation
{
    /// <summary>
    /// Message管理应用层接口实现
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
            :base(context)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region IUserService Members
        /// <summary>
        /// 判断用户是否存在（初始化用到）
        /// </summary>
        /// <returns></returns>
        public bool ExistUser()
        {
            int users = userRepository.GetCount();
            return users == 0 ? false : true;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="usersDTO">用户列表</param>
        /// <returns></returns>
        public bool AddUser(IList<UserDTO> usersDTO)
        {
            foreach (UserDTO userDTO in usersDTO)
            {
                userRepository.Add(Mapper.Map<UserDTO, User>(userDTO));
            }
            return userRepository.Context.Commit();
        }
        #endregion
    }
}
