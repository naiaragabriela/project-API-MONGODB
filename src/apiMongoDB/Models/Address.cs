using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiMongoDB.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }
        public City City { get; set; }

    }
}
