/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Repositories;

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
        #endregion
    }
}
