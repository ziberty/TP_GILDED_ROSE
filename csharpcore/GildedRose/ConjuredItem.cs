namespace GildedRoseKata
{
    public class ConjuredItem : Item
    {
        public ConjuredItem(string name, int sellIn, int quality, int basePrice) : base(name, sellIn, quality, basePrice)
        {

        }

        public override void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        private void UpdateQuality()
        {
            this.quality-=2;
            FloorQualityToZero();
            CeilQualityToFifty();
        }

        private void UpdateSellIn()
        {
            this.sellIn--;
            if (this.sellIn < 0)
            {
                this.quality--;
            }
        }
    }
}