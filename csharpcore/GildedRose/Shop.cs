using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Shop
    {
        private ItemsRepository itemsRepository;
        
        public Shop(ItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public void UpdateQuality()
        {
            IList<Item> items = this.itemsRepository.GetInventory();
            foreach(Item item in items)
            {
                item.Update();
            }
            this.itemsRepository.SaveInventory(items);
        }
    }
}