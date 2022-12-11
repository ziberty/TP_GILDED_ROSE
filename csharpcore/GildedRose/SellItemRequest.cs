namespace GildedRoseKata
{
    public class SellItemRequest
    {
        private string type;
        private int quality;

        public SellItemRequest(string type, int quality)
        {
            this.type = type;
            this.quality = quality;
        }

        public string GetType()
        {
            return this.type;
        }

        public int GetQuality()
        {
            return this.quality;
        }
    }
}