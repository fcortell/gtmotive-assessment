using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Common;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Interface for a MongoDB repository.
    /// </summary>
    /// <typeparam name="TDocument">The type of the document.</typeparam>
    public interface IMongoRepository<TDocument>
        where TDocument : IDocument
    {
        /// <summary>
        /// Gets the documents as an IQueryable.
        /// </summary>
        /// <returns>An IQueryable of TDocument.</returns>
        IQueryable<TDocument> AsQueryable();

        /// <summary>
        /// Filters the documents by a specified expression.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the filtered documents.</returns>
        Task<IEnumerable<TDocument>> FilterByAsync(
            Expression<Func<TDocument, bool>> filterExpression,
            CancellationToken cancellationToken);

        /// <summary>
        /// Filters the documents by a specified expression and projects the result.
        /// </summary>
        /// <typeparam name="TProjected">The type of the projected result.</typeparam>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="projectionExpression">The projection expression.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the projected documents.</returns>
        Task<IEnumerable<TProjected>> FilterByAsync<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            FindOptions<TDocument, TProjected> projectionExpression,
            CancellationToken cancellationToken);

        /// <summary>
        /// Finds a single document by a specified expression.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the found document.</returns>
        Task<TDocument> FindOneAsync(
            Expression<Func<TDocument, bool>> filterExpression,
            CancellationToken cancellationToken);

        /// <summary>
        /// Finds a document by its ID.
        /// </summary>
        /// <param name="id">The document ID.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the found document.</returns>
        Task<TDocument> FindByIdAsync(
            string id,
            CancellationToken cancellationToken);

        /// <summary>
        /// Inserts a single document.
        /// </summary>
        /// <param name="document">The document to insert.</param>
        /// <param name="clientSessionHandle">The client session handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task InsertOneAsync(
            TDocument document,
            IClientSessionHandle clientSessionHandle,
            CancellationToken cancellationToken);

        /// <summary>
        /// Inserts multiple documents.
        /// </summary>
        /// <param name="documents">The documents to insert.</param>
        /// <param name="clientSessionHandle">The client session handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task InsertManyAsync(
            ICollection<TDocument> documents,
            IClientSessionHandle clientSessionHandle,
            CancellationToken cancellationToken);

        /// <summary>
        /// Replaces a single document.
        /// </summary>
        /// <param name="document">The document to replace.</param>
        /// <param name="clientSessionHandle">The client session handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        Task<bool> ReplaceOneAsync(
            TDocument document,
            IClientSessionHandle clientSessionHandle,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a single document by its ID.
        /// </summary>
        /// <param name="id">The document ID.</param>
        /// <param name="clientSessionHandle">The client session handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        Task<bool> DeleteOneAsync(
            string id,
            IClientSessionHandle clientSessionHandle,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes multiple documents by a specified expression.
        /// </summary>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="clientSessionHandle">The client session handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        Task<bool> DeleteManyAsync(
            Expression<Func<TDocument, bool>> filterExpression,
            IClientSessionHandle clientSessionHandle,
            CancellationToken cancellationToken);
    }
}
