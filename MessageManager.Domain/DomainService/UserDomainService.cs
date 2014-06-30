/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// User领域服务实现
    /// </summary>
    public class UserDomainService : IUserDomainService
    {
        #region Private Fields
        private readonly IUserRepository userRepository;
        #endregion

        #region Ctor
        public UserDomainService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region IUserDomainService Members
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUserByName(string name)
        {
            return userRepository.GetUserByName(name);
            /// to do...
        }
        #endregion
    }
}
