using System;
namespace ItemStoreForSimpleAdventureGame.Models
{
        public class ItemStoreDatabaseSettings : IItemStoreDatabaseSettings
        {
            public string ItemStoreCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

    public interface IItemStoreDatabaseSettings
    {
        string ItemStoreCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
