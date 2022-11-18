using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRoseTests
{
    [TestClass]
    public class ItemsRepositoryTest
    {
        public InMemoryItemsRepository InMemoryItemsRepository = new InMemoryItemsRepository();
        private List<Item> itemsInventory = new List<Item>()
        {
            new GenericItem("Wang", 10, 9, 15),
            new AgingItem("Aged Brie", 5, 4, 6),
            new AgingItem("Aged Brie", 5, 50, 23),
            new LegendaryItem("Sulfuras", 5, 80, 69),
        };

        [TestInitialize]
        public void Setup()
        {
            InMemoryItemsRepository.SaveInventory(itemsInventory);
        }

        [TestMethod]
        public void Should_ReturnListSizeOf4()
        {
            Assert.AreEqual(4, InMemoryItemsRepository.GetInventory().Count);
        }

        [TestMethod]
        public void Should_AddOneItemToItemsInventory()
        {
            int initialInventoryItemsCount = InMemoryItemsRepository.GetInventory().Count;
            itemsInventory.Add(new ConjuredItem("Conjured Sword", 10, 10, 25));
            InMemoryItemsRepository.SaveInventory(itemsInventory);
            int newInventoryItemsCount = InMemoryItemsRepository.GetInventory().Count;
            Assert.AreEqual(1, newInventoryItemsCount - initialInventoryItemsCount);
        }
    }
}