using System.Collections.Generic;

namespace GildedRoseKata
{
    public interface ShopOutputBoundary
    {
        public void DisplayInventory(List<ItemResponse> inventory);

        public void DisplayBalance(int balance);
    }
}