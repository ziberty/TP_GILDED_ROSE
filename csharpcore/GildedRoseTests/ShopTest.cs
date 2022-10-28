using GildedRoseKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestClass]
    public class ShopTest
    {
        public Shop shop;
        public ItemsRepository ItemsRepository;

        [TestInitialize]
        public void Setup()
        {
            this.ItemsRepository = new InMemoryItemsRepository();
            this.shop = new Shop(ItemsRepository);
            this.shop.UpdateQuality();
        }
        
        [TestMethod]
        public void Should_UpdateItemProperties()
        {
            Assert.AreEqual(9, this.ItemsRepository.GetInventory()[0].sellIn);
            Assert.AreEqual(8, this.ItemsRepository.GetInventory()[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration()
        {
            Assert.AreEqual(6, this.ItemsRepository.GetInventory()[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality()
        {
            Assert.AreEqual(0, this.ItemsRepository.GetInventory()[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality()
        {
            Assert.AreEqual(5, this.ItemsRepository.GetInventory()[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityPastFifty()
        {
            Assert.AreEqual(50, this.ItemsRepository.GetInventory()[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties()
        {
            Assert.AreEqual(5, this.ItemsRepository.GetInventory()[5].sellIn);
            Assert.AreEqual(80, this.ItemsRepository.GetInventory()[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality()
        {
            Assert.AreEqual(11, this.ItemsRepository.GetInventory()[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore()
        {
            Assert.AreEqual(12, this.ItemsRepository.GetInventory()[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoFiveDaysBefore()
        {
            Assert.AreEqual(13, this.ItemsRepository.GetInventory()[8].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityToZeroAfterEvent()
        {
            Assert.AreEqual(0, this.ItemsRepository.GetInventory()[9].quality);
        }
        
        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastWhenItemIsConjured()
        {
            Assert.AreEqual(8, this.ItemsRepository.GetInventory()[10].quality);
        }
    }
    
}