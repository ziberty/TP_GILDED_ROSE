using System;

namespace GildedRoseKata
{
    public abstract class Item
    {
        public string name {get; protected set;}
        public int sellIn {get; protected set;}
        public int quality {get; protected set;}

        public Item(string name, int sellIn, int quality){
            this.name = name;
            this.sellIn = sellIn;
            this.quality = quality;
        }

        public abstract void Update();
        // {
        //     if(this.name == "Sulfuras")
        //         return;

        //     UpdateSellIn();
        //     UpdateQuality();
        // }

        // public void UpdateSellIn(){
            
        //     this.sellIn--;
        // }

        // public void UpdateQuality(){
        //     switch(this.name)
        //     {
        //         case "Aged Brie": UpdateAgingItemQuality(); break;
        //         case "Backstage Pass": UpdateBackstagePassQuality(); break;
        //         default: UpdateGenericItemQuality(); break;
        //     }

        //     FloorQualityToZero();
        //     CeilQualityToFifty();
        // }

        // private void UpdateBackstagePassQuality()
        // {
        //     this.quality++;

        //     if(this.sellIn <= 10)
        //         this.quality++;

        //     if(this.sellIn <= 5)
        //         this.quality++;

        //     if(this.sellIn < 0)
        //         this.quality = 0;
        // }

        // private void UpdateGenericItemQuality()
        // {
        //     if (this.sellIn < 0)
        //         this.quality--;

        //     this.quality--;
        // }

        // private void UpdateAgingItemQuality()
        // {
        //     this.quality++;
        // }

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

        
    }
}