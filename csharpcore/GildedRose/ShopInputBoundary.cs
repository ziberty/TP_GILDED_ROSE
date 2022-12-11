namespace GildedRoseKata
{
    public interface ShopInputBoundary
    {
        public void UpdateInventory();

        public void SellItem(SellItemRequest request);
    }
}