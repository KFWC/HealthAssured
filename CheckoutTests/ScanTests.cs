
using CheckoutKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutTests
{
    [TestClass]
    public class ScanTests
    {
        Checkout checkout;

        [TestMethod]
        public void ScanOneItem_ShouldReturnLengthOfScannedItemsAsOne()
        {
            checkout = new Checkout();

            checkout.Scan("A");

            Assert.IsTrue(checkout.scannedItems.Length == 1);
        }

        [TestMethod]
        public void ScanTwoItems_ShouldReturnLengthOfScannedItemsAsTwo()
        {
            checkout = new Checkout();

            checkout.Scan("A");
            checkout.Scan("B");

            Assert.IsTrue(checkout.scannedItems.Length == 2);
        }

        [TestMethod]
        public void ScanThreeItems_ShouldReturnLengthOfScannedItemsAsThree()
        {
            checkout = new Checkout();

            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");

            Assert.IsTrue(checkout.scannedItems.Length == 3);
        }
    }
}
