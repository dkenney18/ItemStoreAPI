using System;
using System.Collections.Generic;
using ItemStoreForSimpleAdventureGame.Models;
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
            _items.InsertOne(backpack);
            return backpack;
        }

        public void Update(string playerID, Backpack backpackIn) =>
            _items.ReplaceOne(backpack => backpack.OwnerID == playerID, backpackIn);

        public void Remove(Backpack backpackIn) =>
            _items.DeleteMany(backpack => backpack.OwnerID == backpackIn.OwnerID);

        public void Remove(string playerID) =>
            _items.DeleteMany(backpack => backpack.OwnerID == playerID);
    }
}
