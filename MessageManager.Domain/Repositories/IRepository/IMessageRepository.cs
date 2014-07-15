using MessageManager.Domain.Entity;
using MessageManager.Domain.ValueObject;
using System;
using System.Collections.Generic;

namespace MessageManager.Domain.Repositories
{
    public interface IMessageRepository
    {
        int GetMessageCount(IContact sender, DateTime sendTime);

        ICollection<Message> GetOutbox(IContact reader);

        ICollection<Message> GetInbox(IContact reader);
    }
}
