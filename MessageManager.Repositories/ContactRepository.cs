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
            if (loginName.Equals("xiaocai"))
            {
                return new Contact("1", "xiaocai", "小菜");
            }
            else
            {
                return new Contact("2", "dashen", "大神");
            }
        }

        public Contact GetContactByDisplayName(string displayName)
        {
            if (displayName.Equals("大神"))
            {
                return new Contact("2", "dashen", "大神");
            }
            else
            {
                return new Contact("1", "xiaocai", "小菜");
            }
        }
        #endregion
    }
}
