using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public interface ItemsRepository
    {
        public IList<Item> GetInventory();
        public void SaveInventory(IList<Item> items);

        public Item FindItem(String type, int quality);
    }
}