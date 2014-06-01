/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories.Specifications;
using MessageManager.Domain.Specifications;
using MessageManager.Domain.Repositories.EntityFramework;

namespace MessageManager.Domain.Repositories
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        { }

        #region IUserRepository Members
        public User GetUserByName(string name)
        {
            return Get(new UserNameEqualsSpecification(name));
        }
        #endregion
    }
}
