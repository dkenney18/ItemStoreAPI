using System;
namespace ItemStoreForSimpleAdventureGame.Models
{
        public class BackpackDatabaseSettings : IBackpackDatabaseSettings
        {
            public string BackpackCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

    public interface IBackpackDatabaseSettings
    {
        string BackpackCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
