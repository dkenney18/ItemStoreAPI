
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
namespace ItemStoreForSimpleAdventureGame.Models
{
    [BsonIgnoreExtraElements]
    public class Backpack
    {
        [JsonProperty("Item")]
        public Item Item { get; set; }

        [JsonProperty("Owner")]
        public string OwnerID { get; set; }

    }
}
