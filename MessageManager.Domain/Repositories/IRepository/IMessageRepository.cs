
using MessageManager.Domain.Entity;
using MessageManager.Domain.ValueObject;
using System.Collections.Generic;
namespace MessageManager.Domain.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        ICollection<Message> GetUnreadMessageList(Contact reader);

        int GetUnreadMessageCount(Contact reader);

        ICollection<Message> GetInbox(Contact reader);

        ICollection<Message> GetOutbox(Contact reader);

        Message GetMessageById(string id);

        void AddMessage(Message message);

        void UpdateMessage(Message message);

        void DeleteMessage(Message message);
    }
}
