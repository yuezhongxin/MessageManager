using MessageManager.Domain.ValueObject;

namespace MessageManager.Domain.Repositories
{
    public interface IContactRepository
    {
        Contact GetContactByLoginName(string loginName);

        Contact GetContactByDisplayName(string displayName);
    }
}
