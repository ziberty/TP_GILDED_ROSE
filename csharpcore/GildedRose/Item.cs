namespace GildedRoseKata
{
    public class Item
    {
        private string name;
        private int sellIn;
        private int quality;

        public Item(string name, int sellIn, int quality)
        {
            this.name = name;
            this.sellIn = sellIn;
            this.quality = sellIn;
        }

        public void updateQuality()
        {
            switch (name)
            {
                case "Aged Brie":
                    quality++;
                    break;
                case "Backstage passes":
                    switch (sellIn)
                    {
                        case <= 0:
                            quality = 0;
                            break;
                        case <= 5:
                            quality += 3;
                            break;
                        case <= 10:
                            quality += 2;
                            break;
                        default:
                            quality++;
                            break;
                    }
                    break;
                default:
                    if (sellIn > 0)
                    {
                        sellIn--;
                        quality--;
                    }
                    else
                    {
                        quality -= 2;
                    }
                    break;
            }
            itemQualityCheck();
        }
        
        private void itemQualityCheck()
        {
            if (quality < 0)
            {
                quality = 0;
            }
            if (quality > 50)
            {
                quality = 50;
            }
            if (name == "Sulfuras")
            {
                quality = 80;
            }
        }
    }
}