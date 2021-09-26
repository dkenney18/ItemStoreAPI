using System;
using System.Collections.Generic;
using ItemStoreForSimpleAdventureGame.Models;
using MongoDB.Driver;

namespace ItemStoreForSimpleAdventureGame.Services
{
    public class PlayerService
    {
        private readonly IMongoCollection<Player> _players;

        public PlayerService(IPlayerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _players = database.GetCollection<Player>(settings.PlayerCollectionName);
        }

        public List<Player> Get() =>
            _players.Find(player => true).ToList();

        public Player Get(string id) =>
            _players.Find<Player>(player => player.Id == id).FirstOrDefault();

        public Player Create(Player player)
        {
            _players.InsertOne(player);
            return player;
        }

        public void Update(string id, Player playerIn) =>
            _players.ReplaceOne(player => player.Id == id, playerIn);

        public void Remove(Player playerIn) =>
            _players.DeleteOne(player => player.Id == playerIn.Id);

        public void Remove(string id) =>
            _players.DeleteOne(player => player.Id == id);
    }
}
