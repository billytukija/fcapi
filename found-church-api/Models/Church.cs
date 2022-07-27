using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace found_church_api.Models
{
    public class Church
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ChurchName")]
        public string ChurchName { get; set; }

        [BsonElement("PastorName")]
        public string PastorName { get; set; }

        [BsonElement("Country")]
        public string Country { get; set; }

        [BsonElement("State")]
        public string State { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("Neighborhood")]
        public string Neighborhood { get; set; }

        [BsonElement("Street")]
        public string Street { get; set; }

        [BsonElement("Number")]
        public string Number { get; set; }

        [BsonElement("AdditionalInformations")]
        public string AdditionalInformations { get; set; }

        [BsonElement("NameProvider")]
        public string NameProvider { get; set; }

        [BsonElement("EmailProvider")]
        public string EmailProvider { get; set; }

        [BsonElement("Enabled")]
        public bool Enabled { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("EnabledAt")]
        public DateTime EnabledAt { get; set; }
    }
}
