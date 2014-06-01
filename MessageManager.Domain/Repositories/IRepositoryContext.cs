using MessageManager.Infrastructure;
using System;

namespace MessageManager.Domain.Repositories
{
    /// <summary>
    /// Represents that the implemented classes are repository contexts.
    /// </summary>
    public interface IRepositoryContext : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Gets the unique-identifier of the repository context.
        /// </summary>
        string ID { get; }
        /// <summary>
        /// Registers a new object to the repository context.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <param name="obj">The object to be registered.</param>
        void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : class, IAggregateRoot;
        /// <summary>
        /// Registers a modified object to the repository context.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <param name="obj">The object to be registered.</param>
        void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : class, IAggregateRoot;
        /// <summary>
        /// Registers a deleted object to the repository context.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <param name="obj">The object to be registered.</param>
        void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : class, IAggregateRoot;
    }
}
