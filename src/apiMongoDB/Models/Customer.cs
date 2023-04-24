﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiMongoDB.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
