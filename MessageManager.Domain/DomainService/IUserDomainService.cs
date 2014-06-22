/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.DomainService
{
    /// <summary>
    /// User领域服务接口
    /// </summary>
    public interface IUserDomainService
    {
        #region IUserDomainService Members
        /// <summary>
        /// 判断用户是否存在（初始化用到）
        /// </summary>
        /// <returns></returns>
        bool ExistUser();
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="usersDTO">用户列表</param>
        /// <returns></returns>
        bool AddUser(IList<User> users);
        #endregion
    }
}
