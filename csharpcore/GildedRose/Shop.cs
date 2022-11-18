using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Shop
    {
        private ItemsRepository itemsRepository;
        private int balance;
        
        public Shop(ItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public int Balance => this.balance;

        public void UpdateInventory()
        {
            IList<Item> items = this.itemsRepository.GetInventory();
            foreach(Item item in items)
            {
                item.Update();
            }
            this.itemsRepository.SaveInventory(items);
        }

        public void SellItem(String type, int quality)
        {
            Item item = itemsRepository.FindItem(type, quality);
            if (this.itemsRepository.GetInventory().Contains(item))
            {
                this.itemsRepository.GetInventory().Remove(item);
                this.balance += item.GetValue();
            }
            else
            {
                Console.WriteLine("Cet article n'est pas trouvé.");
            }
        }
    }
}