/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories;
using MessageManager.Repositories.EntityFramework;

namespace MessageManager.Repositories
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        { }

        #region IUserRepository Members
        public User GetUserByName(string name)
        {
            User user = new User(name);
            user.ID = "ba448332-8c87-4c70-9aa8-7deaff175e86";
            return user;
            //return Get(new UserNameEqualsSpecification(name));
        }
        #endregion
    }
}
