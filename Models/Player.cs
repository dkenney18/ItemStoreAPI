using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ItemStoreForSimpleAdventureGame.Models
{
    [BsonIgnoreExtraElements]
    public class Player
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Money")]
        public int Money { get; set; }

        [JsonProperty("Health")]
        public int Health { get; set; }

        [JsonProperty("Damage")]
        public int Damage { get; set; }

        [JsonProperty("Level")]
        public int Level { get; set; }

        [JsonProperty("LeftHand")]
        public Item LeftHand { get; set; }

        [JsonProperty("RightHand")]
        public Item RightHand { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
