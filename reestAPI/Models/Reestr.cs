using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace reestAPI.Models
{
    public class reestr
    {
        //[BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int BIN { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int KRP_ID { get; set; }
        public string KRP { get; set; }
        public string Description { get; set; }
        public int People { get; set; }
        
    }

}

