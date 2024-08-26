using CheckoutKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CheckoutTests
{
    [TestClass]
    public class GetTotalPriceTests
    {
        Checkout checkout;

        [TestInitialize]
        public void Setup()
        {
            checkout = new Checkout(
                new List<Product> {
                    new Product { Sku = "A", Price = 50 },
                    new Product { Sku = "B", Price = 30 },
                    new Product { Sku = "C", Price = 20 },
                    new Product { Sku = "D", Price = 15 }
                },
                new List<SpecialOffer>
                {
                    new SpecialOffer { Sku = "A", Amount = 3, Price = 130 },
                    new SpecialOffer { Sku = "B", Amount = 2, Price = 45 }
                }
            );
        }

        [TestMethod]
        public void ScanFiveSkuAItems_ShouldReturnTwoHundredAndThirty()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 230);
        }

        [TestMethod]
        public void ScanFiveSkuBItems_ShouldReturnOneHundredAndTwenty()
        {
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 120);
        }

        [TestMethod]
        public void ScanTenSkuCItems_ShouldReturnTwoHundred()
        {
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 200);
        }

        [TestMethod]
        public void ScanTwentySkuDItems_ShouldReturnThreeHundred()
        {
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 300);
        }

        [TestMethod]
        public void ScanMixtureSkus_ShouldReturnThreeHundredAndThirtyFive()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");
            checkout.Scan("D");
            checkout.Scan("D");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 335);
        }

        [TestMethod]
        public void NoScannedItems_ShouldReturnZero()
        {
            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 0);
        }
    }
}
