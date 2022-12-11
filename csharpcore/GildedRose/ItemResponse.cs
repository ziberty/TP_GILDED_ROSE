namespace GildedRoseKata
{
    public class ItemResponse
    {
        private string name;
        private int sellIn;
        private int quality;
        private int value;

        public ItemResponse(string name, int sellIn, int quality, int value)
        {
            this.name = name;
            this.sellIn = sellIn;
            this.quality = quality;
            this.value = value;
        }

        public string GetName()
        {
            return this.name;
        }
        
        public int GetSellIn()
        {
            return this.sellIn;
        }

        public int GetQuality()
        {
            return this.quality;
        }

        public int GetValue()
        {
            return this.value;
        }
    }
}