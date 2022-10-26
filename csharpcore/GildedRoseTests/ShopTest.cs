using GildedRoseKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestClass]
    public class ShopTest
    {
        public Shop shop;       
        public List<Item> items = new List<Item>(){
            new GenericItem("Wang", 10, 9),
            new GenericItem("Sword", -1, 8),
            new GenericItem("Shield", -1, 0),
            new AgingItem("Aged Brie", 5, 4),
            new AgingItem("Aged Brie", 5, 50),
            new LegendaryItem("Sulfuras", 5, 80),
            new EventItem("Backstage Pass", 15, 10),
            new EventItem("Backstage Pass", 10, 10),
            new EventItem("Backstage Pass", 5, 10),
            new EventItem("Backstage Pass", -1, 10),
        };

        [TestInitialize]
        public void Setup()
        {
            this.shop = new Shop(this.items);
            this.shop.UpdateQuality();
        }
        
        [TestMethod]
        public void Should_UpdateItemProperties()
        {
            Assert.AreEqual(9, this.shop.Items[0].sellIn);
            Assert.AreEqual(8, this.shop.Items[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration()
        {
            Assert.AreEqual(6, this.shop.Items[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality()
        {
            Assert.AreEqual(0, this.shop.Items[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality()
        {
            Assert.AreEqual(5, this.shop.Items[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityPastFifty()
        {
            Assert.AreEqual(50, this.shop.Items[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties()
        {
            Assert.AreEqual(5, this.shop.Items[5].sellIn);
            Assert.AreEqual(80, this.shop.Items[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality()
        {
            Assert.AreEqual(11, this.shop.Items[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore()
        {
            Assert.AreEqual(12, this.shop.Items[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoFiveDaysBefore()
        {
            Assert.AreEqual(13, this.shop.Items[8].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityToZeroAfterEvent()
        {
            Assert.AreEqual(0, this.shop.Items[9].quality);
        }
    }
    
}