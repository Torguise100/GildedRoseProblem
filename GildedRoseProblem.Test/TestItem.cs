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
        public void UpdateQualityOfBackstagePassesSellInNegativeReducesQualityToZero()
        {
            Item item = new Item("Backstage Passes", 0, 10);
            item.UpdateQuality();
            Assert.AreEqual(0, item.Quality, "Quality should change after age");
            item.UpdateQuality();
            Assert.AreEqual(0, item.Quality, "Quality should be 0 if sellIn is negative");
        }

        [Test]
        public void UpdateQualityOfSulfurasHasNoEffect()
        {
            Item item = new Item("Sulfuras", 2, 2);
            item.UpdateQuality();
            Assert.AreEqual(2, item.Quality, "Sulfuras Quality does not change");
            Assert.AreEqual(2, item.SellIn, "Sulfuras SellIn does not change");
        }

        [Test]
        public void TestIsValidForValidItems()
        {
            Item item = new Item("Normal Item", 2, 2);
            Assert.True(item.IsValid(), "Normal Item Should be valid");

            Item brie = new Item("Aged Brie", -1, 0);
            Assert.True(brie.IsValid(), "Aged Brie Should be valid");

            Item conjured = new Item("Conjured", 3, 50);
            Assert.True(conjured.IsValid(), "Conjured Should be valid");

            Item sulfuras = new Item("Sulfuras", 2, 2);
            Assert.True(sulfuras.IsValid(), "Sulfuras Should be valid");

            Item passes = new Item("Backstage Passes", 6, 10);
            Assert.True(passes.IsValid(), "Backstage Passes Should be valid");
        }

        [Test]
        public void TestIsValidForInvalidItems()
        {
            Item item = new Item("INVALID ITEM", 2, 2);
            Assert.False(item.IsValid(), "Invalid Item Should be valid");

            Item chocolate = new Item("Chocolate", -1, 0);
            Assert.False(chocolate.IsValid(), "Chocolate Should be valid");

            Item catPoster = new Item("Cat Poster", 3, 50);
            Assert.False(catPoster.IsValid(), "Cat Poster Should be valid");
        }

        [Test]
        public void TestToStringReturnsNoSuchItemForInvalidItems()
        {
            Item item = new Item("Invalid Item", 2, 2);
            string output = item.ToString();

            Assert.AreEqual("NO SUCH ITEM", output, "Invalid Item should return NO SUCH ITEM");
            
            Item chocolate = new Item("Chocolate", -1, 0);
            output = item.ToString();

            Assert.AreEqual("NO SUCH ITEM", output, "Chocolate should return NO SUCH ITEM");

            Item catPoster = new Item("Cat Poster", 3, 50);
            output = item.ToString();

            Assert.AreEqual("NO SUCH ITEM", output, "Cat Poster should return NO SUCH ITEM");
        }

        [Test]
        public void TestToStringReturnsNameSellInAndQualityInOrder()
        {
            Item item = new Item("Normal Item", 2, 2);
            string output = item.ToString();

            Assert.AreEqual("Normal Item 2 2", output, "Output should be item name followed by SellIn and Quality");

            Item brie = new Item("Aged Brie", -1, 0);
            output = brie.ToString();

            Assert.AreEqual("Aged Brie -1 0", output, "Output should be item name followed by SellIn and Quality");

            Item conjured = new Item("Conjured", 3, 50);
            output = conjured.ToString();

            Assert.AreEqual("Conjured 3 50", output, "Output should be item name followed by SellIn and Quality");

            Item sulfuras = new Item("Sulfuras", 2, 2);
            output = sulfuras.ToString();

            Assert.AreEqual("Sulfuras 2 2", output, "Output should be item name followed by SellIn and Quality");

            Item passes = new Item("Backstage Passes", 6, 10);
            output = passes.ToString();

            Assert.AreEqual("Backstage Passes 6 10", output, "Output should be item name followed by SellIn and Quality");
        }
    }
}
