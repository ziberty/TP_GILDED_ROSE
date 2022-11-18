using System;

namespace GildedRoseKata
{
    public abstract class Item
    {
        public string name {get; protected set;}
        public int sellIn {get; protected set;}
        public int quality {get; protected set;}
        public int basePrice { get; protected set; }

        public Item(string name, int sellIn, int quality, int basePrice){
            this.name = name;
            this.sellIn = sellIn;
            this.quality = quality;
            this.basePrice = basePrice;
        }

        public abstract void Update();

        protected void FloorQualityToZero(){
            if (this.quality < 0)
            {
                this.quality = 0;
            }
        }
        protected void CeilQualityToFifty(){
            if (this.quality > 50)
            {
                this.quality = 50;
            }
        }

        public int GetValue()
        {
            return basePrice + quality * 10;
        }

        
    }
}