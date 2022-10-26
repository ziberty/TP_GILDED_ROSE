using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Shop
    {
        public IList<Item> Items { get; }

        public Shop(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            foreach(Item item in this.Items)
            {
                item.Update();
            }
        }
    }
}