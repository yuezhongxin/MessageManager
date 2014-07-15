/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Specifications;
using MessageManager.Domain.ValueObject;

namespace MessageManager.Domain.Repositories.Specifications
{
    internal abstract class ContactStringEqualsSpecification : Specification<IContact>
    {
        protected readonly string value;

        public ContactStringEqualsSpecification(string value)
        {
            this.value = value;
        }
    }
}
