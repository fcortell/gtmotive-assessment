using System;

namespace GtMotive.Estimate.Microservice.Domain.Attributes
{
    /// <summary>
    /// Specifies the MongoDB collection name for a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class BsonCollectionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BsonCollectionAttribute"/> class.
        /// </summary>
        /// <param name="collectionName">The name of the MongoDB collection.</param>
        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }

        /// <summary>
        /// Gets the name of the MongoDB collection.
        /// </summary>
        public string CollectionName { get; }
    }
}
