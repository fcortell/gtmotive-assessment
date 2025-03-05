using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Common
{
    /// <summary>
    /// Represents a document stored in MongoDB.
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Gets or sets the unique identifier for the document.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }

        /// <summary>
        /// Gets the date and time when the document was created.
        /// </summary>
        [BsonElement]
        DateTime CreatedAt { get; }

        /// <summary>
        /// Gets or sets the date and time when the document was last modified.
        /// </summary>
        [BsonElement]
        DateTime ModifiedAt { get; set; }
    }
}
