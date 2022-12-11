using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class InMemoryItemsRepository : ItemsGateway
    {
        private IList<Item> items = new List<Item>(){
            new GenericItem("Wang", 10, 9, 20),
            new GenericItem("Sword", -1, 8, 12),
            new GenericItem("Shield", -1, 0, 5),
            new AgingItem("Aged Brie", 5, 4, 3),
            new AgingItem("Aged Brie", 5, 50, 6),
            new LegendaryItem("Sulfuras", 5, 80, 69),
            new EventItem("Backstage Pass", 15, 10, 42),
            new EventItem("Backstage Pass", 10, 10, 36),
            new EventItem("Backstage Pass", 5, 10, 16),
            new EventItem("Backstage Pass", -1, 10, 53),
            new ConjuredItem("Conjured Sword", 10, 10, 69),
        };

        public IList<Item> GetInventory()
        {
            return items;
        }

        public void SaveInventory(IList<Item> items)
        {
            this.items = items;
        }

        public Item FindItem(string type, int quality)
        {
            return GetInventory().FirstOrDefault(item => item.name == type && item.quality == quality);
        }
    }
}