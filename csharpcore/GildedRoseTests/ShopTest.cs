using GildedRoseKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestClass]
    public class ShopTest
    {
        public ShopInputBoundary ShopInputBoundary;
        public ItemsGateway ItemsRepository;

        [TestInitialize]
        public void Setup()
        {
            this.ItemsRepository = new InMemoryItemsRepository();
            this.ShopInputBoundary = new ShopInputBoundary(ItemsRepository);
        }
        
        [TestMethod]
        public void Should_UpdateItemProperties()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(9, this.ItemsRepository.GetInventory()[0].sellIn);
            Assert.AreEqual(8, this.ItemsRepository.GetInventory()[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(6, this.ItemsRepository.GetInventory()[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(0, this.ItemsRepository.GetInventory()[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(5, this.ItemsRepository.GetInventory()[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityPastFifty()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(50, this.ItemsRepository.GetInventory()[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(5, this.ItemsRepository.GetInventory()[5].sellIn);
            Assert.AreEqual(80, this.ItemsRepository.GetInventory()[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(11, this.ItemsRepository.GetInventory()[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(12, this.ItemsRepository.GetInventory()[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoFiveDaysBefore()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(13, this.ItemsRepository.GetInventory()[8].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityToZeroAfterEvent()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(0, this.ItemsRepository.GetInventory()[9].quality);
        }
        
        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastWhenItemIsConjured()
        {
            this.ShopInputBoundary.UpdateInventory();
            Assert.AreEqual(8, this.ItemsRepository.GetInventory()[10].quality);
        }

        [TestMethod]
        public void Should_SellItem()
        {
            this.ShopInputBoundary.SellItem(new SellItemRequest("Conjured Sword", 10));
            Assert.AreEqual(10, this.ItemsRepository.GetInventory().Count);
            Assert.AreEqual(169, this.ShopInputBoundary.Balance);
        }
    }
    
}