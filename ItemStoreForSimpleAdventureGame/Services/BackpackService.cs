using System;
using System.Collections.Generic;
using ItemStoreForSimpleAdventureGame.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ItemStoreForSimpleAdventureGame.Services
{
    public class BackpackService
    {
        private readonly IMongoCollection<Backpack> _items;

        public BackpackService(IBackpackDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<Backpack>(settings.BackpackCollectionName);
        }

        public List<Backpack> Get() =>
            _items.Find(item => true).ToList();

        public List<Backpack> Get(string playerID)
        {
            var items =_items.Find(item => true).ToList();
            var backpacks = new List<Backpack>();
            foreach (var backpack in items)
            {
                if (backpack.OwnerID == playerID)
                {
                    backpacks.Add(backpack);
                }
            }
            return backpacks;
        }

        public Backpack Create(Backpack backpack)
        {
            backpack.Item.Id = ObjectId.GenerateNewId().ToString();
            _items.InsertOne(backpack);
            return backpack;
        }

        public void Update(Backpack backpackIn) =>
            _items.ReplaceOne(backpack => backpack.OwnerID == backpackIn.OwnerID, backpackIn);

        public void RemoveItem(Backpack backpackIn) =>
            _items.DeleteOne(backpack => backpack.Item.Id == backpackIn.Item.Id);

        public void Remove(string playerID) =>
            _items.DeleteMany(backpack => backpack.OwnerID == playerID);
    }
}
