using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ItemStoreForSimpleAdventureGame
{
    [BsonIgnoreExtraElements]
    public class Item
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Amount")]
        public int Amount { get; set; }

        [JsonProperty("Damage")]
        public int Damage { get; set; }

        [JsonProperty("Tag")]
        public string Tag { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
