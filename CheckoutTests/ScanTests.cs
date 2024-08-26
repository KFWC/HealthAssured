
using CheckoutKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CheckoutTests
{
    [TestClass]
    public class ScanTests
    {
        Checkout checkout;

        [TestInitialize]
        public void Setup()
        {
            checkout = new Checkout();
        }

        [TestMethod]
        public void ScanOneItem_ShouldReturnLengthOfScannedItemsAsOne()
        {
            checkout.Scan("A");

            Assert.IsTrue(checkout.scannedItems.Count == 1);
        }

        [TestMethod]
        public void ScanTwoItems_ShouldReturnLengthOfScannedItemsAsTwo()
        {
            checkout.Scan("A");
            checkout.Scan("B");

            Assert.IsTrue(checkout.scannedItems.Count == 2);
        }

        [TestMethod]
        public void ScanThreeItems_ShouldReturnLengthOfScannedItemsAsThree()
        {
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");

            Assert.IsTrue(checkout.scannedItems.Count == 3);
        }

        [TestMethod]
        public void AllScannedItemsContainSameSku_ShouldReturnLengthOfScannedItemsAsOne()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var skuA = checkout.scannedItems.FirstOrDefault(s => s.Sku == "A");

            Assert.IsTrue(checkout.scannedItems.Count == 1);
            Assert.IsTrue(skuA != null);
            Assert.IsTrue(skuA.Amount == 3);
        }

        [TestMethod]
        public void ScanMixtureContainingDuplicateSkus_ShouldReturnTheNumberItemsScannedForEachSku()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");

            var skuA = checkout.scannedItems.FirstOrDefault(s => s.Sku == "A");
            var skuB = checkout.scannedItems.FirstOrDefault(s => s.Sku == "B");

            Assert.IsTrue(checkout.scannedItems.Count == 2);
            Assert.IsTrue(skuA != null);
            Assert.IsTrue(skuA.Amount == 2);
            Assert.IsTrue(skuB != null);
            Assert.IsTrue(skuB.Amount == 1);
        }
    }
}
