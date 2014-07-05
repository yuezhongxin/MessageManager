/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Repositories.EntityFramework;
using Xunit;

namespace MessageManager.Repositories.Tests
{
    public class UserRepositoryTest
    {
        [Fact]
        public void RepositoryTest_AddUserRepository()
        {
            IUserRepository userRepository = new UserRepository(new EntityFrameworkRepositoryContext());
            User user1 = new User("xiaocai", "小菜");
            User user2 = new User("dashen", "大神");
            userRepository.Add(user1);
            userRepository.Add(user2);
            userRepository.Context.Commit();
        }

        [Fact]
        public void RepositoryTest_GetUserByLoginName()
        {
            IUserRepository userRepository = new UserRepository(new EntityFrameworkRepositoryContext());
            User user = userRepository.GetUserByLoginName("xiaocai");
        }
        [Fact]
        public void RepositoryTest_GetUserByDisplayName()
        {
            IUserRepository userRepository = new UserRepository(new EntityFrameworkRepositoryContext());
            User user = userRepository.GetUserByDisplayName("大神");
        }
    }
}
