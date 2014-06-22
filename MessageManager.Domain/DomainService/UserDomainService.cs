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
        public bool ExistUser()
        {
            int users = userRepository.GetCount();
            return users == 0 ? false : true;
        }
        public bool AddUser(IList<User> users)
        {
            foreach (User user in users)
            {
                userRepository.Add(user);
            }
            return userRepository.Context.Commit();
        }
        #endregion
    }
}
