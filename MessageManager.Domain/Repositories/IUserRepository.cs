/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.Repositories
{
    /// <summary>
    /// 表示继承于该接口的类型是作用在“用户”聚合根上的仓储类型。
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        User GetUsersByName(string name);
    }
}
