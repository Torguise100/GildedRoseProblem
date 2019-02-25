using NUnit.Framework;

namespace GildedRoseProblem.Test
{
    [TestFixture]
    class TestItem
    {
        [Test]
        public void TestUpdateQualityReducesSellInValue()
        {
            Item item = new Item("Normal Item", 1, 2);
            item.UpdateQuality();
            Assert.AreEqual(0, item.SellIn, "SellIn value didnt reduce by 1");
        }

        [Test]
        public void TestUpdateQualityWithNegativeQuality()
        {
            Item item = new Item("Normal Item", 1, -1);
            item.UpdateQuality();
            Assert.AreEqual(Item.MIN_QUALITY, item.Quality, "Negative quality should reset to minimum value");
        }

        [Test]
        public void TestUpdateQualityWithQualityAboveMax()
        {
            Item item = new Item("Normal Item", 1, 55);
            item.UpdateQuality();
            Assert.AreEqual(Item.MAX_QUALITY, item.Quality, "Quality should be capped at Max value");
        }

        [Test]
        public void TestUpdateQualityWithQualityJustAboveMax()
        {
            Item item = new Item("Normal Item", 1, Item.MAX_QUALITY + 1);
            item.UpdateQuality();
            Assert.AreEqual(Item.MAX_QUALITY, item.Quality, "Quality should have reduced as normal");
        }

        [Test]
        public void TestUpdateQualityWithQualityAtMin()
        {
            Item item = new Item("Normal Item", 1, Item.MIN_QUALITY);
            item.UpdateQuality();
            Assert.AreEqual(Item.MIN_QUALITY, item.Quality, "Quality should not reduce lower than minimum");
        }

        [Test]
        public void UpdateQualityOfInvalidItemDoesNothing()
        {
            Item item = new Item("INVALID ITEM", 2, 2);
            item.UpdateQuality();
            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void UpdateQualityOfAgedBrieIncreasesQuality()
        {
            Item item = new Item("Aged Brie", 2, 2);
            item.UpdateQuality();
            Assert.AreEqual(3, item.Quality, "Quality of Aged brie is supposed to increase by 1");
        }

        [Test]
        public void UpdateQualityOfConjouredItemsHasDoubledEffect()
        {
            Item item = new Item("Conjured", 2, 10);
            item.UpdateQuality();
            Assert.AreEqual(8, item.Quality, "Quality of Conjured items should decreased double the normal");
        }

        [Test]
        public void UpdateQualityOfItemWithNegativeSellInDoublesEffect()
        {
            Item item = new Item("Normal item", -1, 10);
            item.UpdateQuality();
            Assert.AreEqual(8, item.Quality, "Negative SellIn date didnt double effect for Normal Item");

            Item brie = new Item("Aged Brie", -1, 10);
            brie.UpdateQuality();
            Assert.AreEqual(12, brie.Quality, "Negative SellIn date didnt double effect for Aged Brie");

            Item conjured = new Item("Conjured", -1, 10);
            conjured.UpdateQuality();
            Assert.AreEqual(6, conjured.Quality, "Negative SellIn date didnt double effect for Conjoured Item");
        }

        [Test]
        public void UpdateQualityOfBackstagePassesIncreasesQuality()
        {
            Item item = new Item("Aged Brie", 2, 2);
            item.UpdateQuality();
            Assert.AreEqual(3, item.Quality, "Quality of backstage passes are supposed to increase by 1");
        }

        [Test]
        public void UpdateQualityOfBackstagePassesSellIn10orLessDoublesQualityIncrease()
        {
            Item item = new Item("Backstage Passes", 11, 10);
            item.UpdateQuality();
            Assert.AreEqual(12, item.Quality, "Quality should change after age");
            item.UpdateQuality();
            Assert.AreEqual(14, item.Quality, "Quality should increase at double rate if SellIn is 10 or less");
        }

        [Test]
        public void UpdateQualityOfBackstagePassesSellIn5orLessTriplesQualityIncrease()
        {
            Item item = new Item("Backstage Passes", 6, 10);
            item.UpdateQuality();
            Assert.AreEqual(13, item.Quality, "Quality should change after age");
            item.UpdateQuality();
            Assert.AreEqual(16, item.Quality, "Quality should increase at double rate if age is 5 or less");
        }

        [Test]
        public void UpdateQualityOfSulfurasHasNoEffect()
        {
            Item item = new Item("Sulfuras", 2, 2);
            item.UpdateQuality();
            Assert.AreEqual(2, item.Quality, "Sulfuras Quality does not change");
            Assert.AreEqual(2, item.SellIn, "Sulfuras SellIn does not change");
        }
    }
}
