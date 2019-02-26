using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GildedRoseProblem.Test
{
    [TestFixture]
    class TestInventory
    {
        [Test]
        public void AddItemWithItemObject()
        {
            Inventory inventory = new Inventory(new List<Item>());
            Item item = new Item("Normal Item", 2, 2);
            inventory.AddItem(item);

            Assert.AreEqual(1, inventory.GetItems().Count, "should have added one item");
        }

        [Test]
        public void AddItemWithNullItemThrowsException()
        {
            Inventory inventory = new Inventory(new List<Item>());
            Assert.That(() => inventory.AddItem(null),
                Throws.TypeOf<NullReferenceException>(), "Expected Null reference caused by null item");
        }

        [Test]
        public void AddItemWithIndividualValuesAddsItem()
        {
            Inventory inventory = new Inventory(new List<Item>());
            inventory.AddItem("Normal Item", 2, 2);

            Assert.AreEqual(1, inventory.GetItems().Count, "should have added a new item");
        }

        [Test]
        public void TestUpdateQualityOfItemsUpdatesEachItem()
        {
            Mock<Item> item1 = new Mock<Item>("Normal Item", 1, 1);
            Mock<Item> item2 = new Mock<Item>("Normal Item", 2, 2);
            Mock<Item> item3 = new Mock<Item>("Normal Item", 3, 3);

            List<Item> mockItems = new List<Item>
            {
                item1.Object, item2.Object, item3.Object
            };
            

            Inventory inventory = new Inventory(mockItems);

            inventory.UpdateQualityOfItems();

            item1.Verify(x => x.UpdateQuality(), Times.Once(), "item1 Update Quality should have been called once");
            item2.Verify(x => x.UpdateQuality(), Times.Once(), "item2 Update Quality should have been called once");
            item3.Verify(x => x.UpdateQuality(), Times.Once(), "item3 Update Quality should have been called once");
        }

        [Test]
        public void TestToStringMultipleItems()
        {
            string expected = "Normal Item 1 1\n" +
                                "Normal Item 2 2\n" +
                                "Normal Item 3 3\n";

            Mock<Item> item1 = new Mock<Item>("Normal Item", 1, 1);
            Mock<Item> item2 = new Mock<Item>("Normal Item", 2, 2);
            Mock<Item> item3 = new Mock<Item>("Normal Item", 3, 3);

            List<Item> mockItems = new List<Item>
            {
                item1.Object, item2.Object, item3.Object
            };

            item1.Setup(m => m.ToString()).Returns("Normal Item 1 1");
            item2.Setup(m => m.ToString()).Returns("Normal Item 2 2");
            item3.Setup(m => m.ToString()).Returns("Normal Item 3 3");

            Inventory inventory = new Inventory(mockItems);

            string output = inventory.ToString();
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestToStringSingleItem()
        {
            string expected = "Normal Item 1 1\n";

            Mock<Item> item = new Mock<Item>("Normal Item", 1, 1);
            item.Setup(m => m.ToString()).Returns("Normal Item 1 1");

            List<Item> mockItems = new List<Item>
            {
                item.Object
            };

            Inventory inventory = new Inventory(mockItems);
            
            string output = inventory.ToString();
            Assert.AreEqual(expected, output);
        }
    }
}
