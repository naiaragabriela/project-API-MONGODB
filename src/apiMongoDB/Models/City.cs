using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiMongoDB.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NameCity { get; set; }
    }
}
