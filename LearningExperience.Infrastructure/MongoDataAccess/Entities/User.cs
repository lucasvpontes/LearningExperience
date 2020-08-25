using MongoDB.Bson.Serialization.Attributes;

namespace LearningExperience.Infrastructure.MongoDataAccess.Entities
{

    [BsonCollection("Users")]
    [BsonIgnoreExtraElements]
    public class User : Document 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
