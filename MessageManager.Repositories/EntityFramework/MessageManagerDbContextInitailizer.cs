using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MessageManager.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// 表示由MessageManager专用的数据访问上下文初始化器。
    /// </summary>
    public sealed class MessageManagerDbContextInitailizer : DropCreateDatabaseIfModelChanges<MessageManagerDbContext>
    {
        // 请在使用MessageManagerDbContextInitializer作为数据库初始化器（Database Initializer）时，去除以下代码行
        // 的注释，以便在数据库重建时，相应的SQL脚本会被执行。对于已有数据库的情况，请直接注释掉以下代码行。
        protected override void Seed(MessageManagerDbContext context)
        {
            base.Seed(context);
        }

        /// <summary>
        /// 执行对数据库的初始化操作。
        /// </summary>
        public static void Initialize()
        {
            Database.SetInitializer<MessageManagerDbContext>(null);
        }
    }
}
