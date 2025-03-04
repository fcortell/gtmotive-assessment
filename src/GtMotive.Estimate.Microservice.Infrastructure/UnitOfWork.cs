using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoService _mongoClient;

        public UnitOfWork(IMongoService mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public virtual async Task<IClientSessionHandle> BeginSessionAsync(CancellationToken cancellationToken)
        {
            var option = new ClientSessionOptions
            {
                DefaultTransactionOptions = new TransactionOptions()
            };
            return await _mongoClient.MongoClient.GetDatabase("GTMotive").Client.StartSessionAsync(option, cancellationToken);
        }

        public virtual void BeginTransaction(IClientSessionHandle clientSessionHandle)
        {
            if (clientSessionHandle == null)
            {
                throw new ArgumentNullException(nameof(clientSessionHandle));
            }

            clientSessionHandle.StartTransaction();
        }

        public virtual Task CommitTransactionAsync(IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken)
        {
            return clientSessionHandle == null
                ? throw new ArgumentNullException(nameof(clientSessionHandle))
                : clientSessionHandle.CommitTransactionAsync(cancellationToken);
        }

        public virtual Task RollbackTransactionAsync(IClientSessionHandle clientSessionHandle, CancellationToken cancellationToken)
        {
            return clientSessionHandle == null
                ? throw new ArgumentNullException(nameof(clientSessionHandle))
                : clientSessionHandle.AbortTransactionAsync(cancellationToken);
        }

        public virtual void DisposeSession(IClientSessionHandle clientSessionHandle)
        {
            if (clientSessionHandle == null)
            {
                throw new ArgumentNullException(nameof(clientSessionHandle));
            }

            clientSessionHandle.Dispose();
        }
    }
}
