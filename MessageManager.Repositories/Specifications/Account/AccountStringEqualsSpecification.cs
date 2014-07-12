/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageManager.Domain.Entity;
using MessageManager.Domain.Specifications;

namespace MessageManager.Domain.Repositories.Specifications
{
    internal abstract class AccountStringEqualsSpecification : Specification<Account>
    {
        protected readonly string value;

        public AccountStringEqualsSpecification(string value)
        {
            this.value = value;
        }
    }
}
