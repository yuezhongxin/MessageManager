/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;

namespace MessageManager.Repositories
{
    public class ContactRepository : IContactRepository
    {
        #region ContactRepository Members
        public Contact GetContactByLoginName(string loginName)
        {
            return new Contact("1", "xiaocai", "小菜");
        }

        public Contact GetContactByDisplayName(string displayName)
        {
            return new Contact("2", "dashen", "大神");
        }
        #endregion
    }
}
