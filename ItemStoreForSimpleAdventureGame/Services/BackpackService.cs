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

        public Backpack Get(string id) =>
            _items.Find<Backpack>(item => item.Id == id).FirstOrDefault();

        public Backpack Create(Backpack backpack)
        {
            _items.InsertOne(backpack);
            return backpack;
        }

        public void Update(string id, Backpack backpackIn) =>
            _items.ReplaceOne(backpack => backpack.Id == id, backpackIn);

        public void Remove(Backpack backpackIn) =>
            _items.DeleteOne(backpack => backpack.Id == backpackIn.Id);

        public void Remove(string id) =>
            _items.DeleteOne(backpack => backpack.Id == id);
    }
}
