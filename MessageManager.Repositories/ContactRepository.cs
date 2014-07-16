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
            return new Contact("name1", "loginName1", "displayName1");
        }

        public Contact GetContactByDisplayName(string displayName)
        {
            return new Contact("name2", "loginName2", "displayName2");
        }
        #endregion
    }
}
