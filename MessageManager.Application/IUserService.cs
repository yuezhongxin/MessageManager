/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using MessageManager.Application.DTO;
using System.Collections.Generic;

namespace MessageManager.Application
{
    /// <summary>
    /// User管理应用层服务接口
    /// </summary>
    public interface IUserService
    {
        #region Methods
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
        bool AddUser(IList<UserDTO> usersDTO);
        #endregion
    }
}
