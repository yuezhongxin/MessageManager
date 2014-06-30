using MessageManager.Domain.Repositories;
using System.Data.Entity;
using System.Threading;

namespace MessageManager.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext, IEntityFrameworkRepositoryContext
    {
        private readonly ThreadLocal<MessageManagerDbContext> localCtx = new ThreadLocal<MessageManagerDbContext>(() => new MessageManagerDbContext());

        public override void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Entry<TAggregateRoot>(obj).State = System.Data.Entity.EntityState.Deleted; 
            Committed = false;
        }

        public override void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Entry<TAggregateRoot>(obj).State = System.Data.Entity.EntityState.Modified;
            Committed = false;
        }

        public override void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
        {
            localCtx.Value.Entry<TAggregateRoot>(obj).State = System.Data.Entity.EntityState.Added;
            Committed = false;
        }

        public override bool Commit()
        {
            if (!Committed)
            {
                if (localCtx.Value.SaveChanges() > 0)
                {
                    Committed = true;
                    return true;
                }
                else
                {
                    Committed = false;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override void Rollback()
        {
            Committed = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!Committed)
                    Commit();
                localCtx.Value.Dispose();
                localCtx.Dispose();
                base.Dispose(disposing);
            }
        }

        #region IEntityFrameworkRepositoryContext Members

        public DbContext Context
        {
            get { return localCtx.Value; }
        }

        #endregion
    }
}
