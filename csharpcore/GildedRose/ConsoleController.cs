using System;
using System.Collections.Generic;
using GildedRoseKata;
namespace ConsoleUIKata
{
    public class ConsoleController : ShopInputBoundary
    { 
        private ItemsGateway _itemsGateway;
        private int balance;
        
        public ConsoleController(ItemsGateway itemsGateway)
        {
            this._itemsGateway = itemsGateway;
        }

        public int Balance => this.balance;

        public void UpdateInventory()
        {
            IList<Item> items = this._itemsGateway.GetInventory();
            foreach(Item item in items)
            {
                item.Update();
            }
            this._itemsGateway.SaveInventory(items);
        }

        public void SellItem(SellItemRequest request)
        {
            Item item = _itemsGateway.FindItem(request.GetType(), request.GetQuality());
            if (this._itemsGateway.GetInventory().Contains(item))
            {
                this._itemsGateway.GetInventory().Remove(item);
                this.balance += item.GetValue();
                this._itemsGateway.SaveInventory(this._itemsGateway.GetInventory());
            }
            else
            {
                Console.WriteLine("Cet article n'est pas trouvé.");
            }
        }
    }
}

