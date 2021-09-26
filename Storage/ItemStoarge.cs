using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ItemStoreForSimpleAdventureGame.Storage
{
    public class ItemStoarge
    {
        public readonly List<string> items = new List<string>();

        public ItemStoarge()
        {
        }

        public void AddItem(string itemName)
        {
            items.Add(itemName);
        }

        public List<string> GetItemNames()
        {
            return items;
        }
    }
}
