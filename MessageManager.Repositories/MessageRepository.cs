/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;
using MessageManager.Repositories.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace MessageManager.Repositories
{
	public class MessageRepository : EntityFrameworkRepository<Message>, IMessageRepository
	{
		private static List<Message> messages = new List<Message>() {
			new Message("title", "content ",
				new Sender("2", "dashen", "大神"),
				new Recipient("1", "xiaocai", "小菜"))
		};
		public MessageRepository(IRepositoryContext context)
			: base(context)
		{ }

		#region IMessageRepository Members
		public ICollection<Message> GetUnreadMessageList(Contact reader)
		{
			return messages.Where(m => m.Recipient.Name == reader.Name).ToList();
		}

		public int GetUnreadMessageCount(Contact reader)
		{
			return messages.Where(m => m.Recipient.Name == reader.Name).Count();
		}

		public ICollection<Message> GetInbox(Contact reader)
		{
			return messages.Where(m => m.Recipient.Name == reader.Name).ToList();
		}

		public ICollection<Message> GetOutbox(Contact reader)
		{
			return messages.Where(m => m.Sender.Name == reader.Name).ToList();
		}

		public Message GetMessageById(string id)
		{
			return messages.Find(m => m.ID == id);
		}

		public void AddMessage(Message message)
		{
			messages.Add(message);
		}

		public void UpdateMessage(Message message)
		{
			messages.Remove(messages.Find(m => m.ID == message.ID));
			messages.Add(message);
		}

		public void DeleteMessage(Message message)
		{
			messages.Remove(messages.Find(m => m.ID == message.ID));
		}
		#endregion

	}
}
