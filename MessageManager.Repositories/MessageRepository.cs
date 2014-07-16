/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;
using MessageManager.Repositories.EntityFramework;
using System.Collections.Generic;

namespace MessageManager.Repositories
{
    public class MessageRepository : EntityFrameworkRepository<Message>, IMessageRepository
    {
        public MessageRepository(IRepositoryContext context)
            : base(context)
        { }

        #region IMessageRepository Members
        public ICollection<Message> GetUnreadMessageList(Contact reader)
        {
            return new List<Message>() { new Message("title", "content", new Sender("1", "xiaocai", "小菜"), new Recipient("2", "dashen", "大神")) };
        }

        public int GetUnreadMessageCount(Contact reader)
        {
            return 1;
        }

        public ICollection<Message> GetInbox(Contact reader)
        {
            return new List<Message>() { new Message("title", "content", new Sender("1", "xiaocai", "小菜"), new Recipient("2", "dashen", "大神")) };
        }

        public ICollection<Message> GetOutbox(Contact reader)
        {
            return new List<Message>() { new Message("title", "content", new Sender("1", "xiaocai", "小菜"), new Recipient("2", "dashen", "大神")) };
        }

        public Message GetMessageById(string id)
        {
            //return new Message("title", "content", new Sender("1", "xiaocai", "小菜"), new Recipient("2", "dashen", "大神"));
            return new Message("title", "content", new Sender("2", "dashen", "大神"), new Recipient("1", "xiaocai", "小菜"));
        }
        #endregion
    }
}
