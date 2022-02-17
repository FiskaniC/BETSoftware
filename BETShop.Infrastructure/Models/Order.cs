using System;
using BETShop.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BETShop.Infrastructure.Repositories.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public Cart Cart { get; set; }
    }
}
