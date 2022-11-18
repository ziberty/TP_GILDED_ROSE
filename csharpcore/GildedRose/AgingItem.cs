using System;

namespace GildedRoseKata
{
    public class AgingItem : Item
    {
        public AgingItem(string name, int sellIn, int quality, int basePrice) : base(name, sellIn, quality, basePrice)
        {

        }

        public override void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        private void UpdateQuality()
        {
            this.quality++;
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