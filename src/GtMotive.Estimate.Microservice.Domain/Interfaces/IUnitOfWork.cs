using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Unit Of Work interface. Should only be used by Use Cases.
    /// Provides methods to manage transactions and sessions with MongoDB.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Begins a new client session asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the client session handle.</returns>
        Task<IClientSessionHandle> BeginSessionAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Begins a new transaction using the provided client session handle.
        /// </summary>
        /// <param name="clientSessionHandle">The client session handle.</param>
        void BeginTransaction(IClientSessionHandle clientSessionHandle);

        /// <summary>
        /// Commits the transaction asynchronously using the provided client session handle.
        /// </summary>
        /// <param name="clientSessionHandle">The client session handle.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CommitTransactionAsync(IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken);

        /// <summary>
        /// Rolls back the transaction asynchronously using the provided client session handle.
        /// </summary>
        /// <param name="clientSessionHandle">The client session handle.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RollbackTransactionAsync(IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken);

        /// <summary>
        /// Disposes the client session handle.
        /// </summary>
        /// <param name="clientSessionHandle">The client session handle.</param>
        void DisposeSession(IClientSessionHandle clientSessionHandle);
    }
}
