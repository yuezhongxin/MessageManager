using System.Data.Entity;
using MessageManager.Domain.Entity;
using MessageManager.Repositories.EntityFramework.ModelConfigurations;

namespace MessageManager.Repositories.EntityFramework
{
    /// <summary>
    /// 表示专用于MessageManager案例的数据访问上下文。
    /// </summary>
    public sealed class MessageManagerDbContext : DbContext
    {
        #region Ctor
        /// <summary>
        /// 构造函数，初始化一个新的<c>MessageManagerDbContext</c>实例。
        /// </summary>
        public MessageManagerDbContext()
            : base("MessageManagerDB")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance; 
            this.Configuration.LazyLoadingEnabled = true;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets a set of <c>Account</c>s.
        /// </summary>
        public DbSet<Account> Accounts { get; set; }
        /// <summary>
        /// Gets a set of <c>Message</c>s.
        /// </summary>
        public DbSet<Message> Messages { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Configurations
                .Add(new AccountConfiguration())
                .Add(new MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
