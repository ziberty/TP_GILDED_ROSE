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
        }
        
        [TestMethod]
        public void Should_UpdateItemProperties()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(9, this.ItemsRepository.GetInventory()[0].sellIn);
            Assert.AreEqual(8, this.ItemsRepository.GetInventory()[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(6, this.ItemsRepository.GetInventory()[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(0, this.ItemsRepository.GetInventory()[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(5, this.ItemsRepository.GetInventory()[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityPastFifty()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(50, this.ItemsRepository.GetInventory()[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(5, this.ItemsRepository.GetInventory()[5].sellIn);
            Assert.AreEqual(80, this.ItemsRepository.GetInventory()[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(11, this.ItemsRepository.GetInventory()[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(12, this.ItemsRepository.GetInventory()[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoFiveDaysBefore()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(13, this.ItemsRepository.GetInventory()[8].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityToZeroAfterEvent()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(0, this.ItemsRepository.GetInventory()[9].quality);
        }
        
        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastWhenItemIsConjured()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(8, this.ItemsRepository.GetInventory()[10].quality);
        }

        [TestMethod]
        public void Should_SellItem()
        {
            this.shop.SellItem("Conjured Sword", 10);
            Assert.AreEqual(10, this.ItemsRepository.GetInventory().Count);
            Assert.AreEqual(169, this.shop.Balance);
        }
    }
    
}