/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using Xunit;

namespace MessageManager.Repositories.Tests
{
    public class AccountRepositoryTest
    {
        [Fact]
        public void RepositoryTest_AddAccountRepository()
        {
            //IAccountRepository accountRepository = new AccountRepository(new EntityFrameworkRepositoryContext());
            //Account account1 = new Account("xiaocai", "小菜");
            //Account account2 = new Account("dashen", "大神");
            //accountRepository.Add(account1);
            //accountRepository.Add(account2);
            //accountRepository.Context.Commit();
        }

        [Fact]
        public void RepositoryTest_GetAccountByLoginName()
        {
            //IAccountRepository accountRepository = new AccountRepository(new EntityFrameworkRepositoryContext());
            //Account account = accountRepository.GetAccountByLoginName("xiaocai");
        }
        [Fact]
        public void RepositoryTest_GetAccountByDisplayName()
        {
            //IAccountRepository accountRepository = new AccountRepository(new EntityFrameworkRepositoryContext());
            //Account account = accountRepository.GetAccountByDisplayName("大神");
        }
    }
}
