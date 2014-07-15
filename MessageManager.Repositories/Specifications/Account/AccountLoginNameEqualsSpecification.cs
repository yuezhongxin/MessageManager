/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.ValueObject;
using System;

namespace MessageManager.Domain.Repositories.Specifications
{
    internal class ContactLoginNameEqualsSpecification : ContactStringEqualsSpecification
    {
        public ContactLoginNameEqualsSpecification(string name)
            : base(name)
        {
        }

        public override System.Linq.Expressions.Expression<Func<IContact, bool>> GetExpression()
        {
            return c => c.Name == value;
        }
    }
}
