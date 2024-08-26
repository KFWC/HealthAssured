using CheckoutKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CheckoutTests
{
    [TestClass]
    public class SpecialOfferTests
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
        public void ScanThreeSkuAItems_ShouldReturnOneHundredAndThirty()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 130);
        }

        [TestMethod]
        public void ScanSixSkuAItems_ShouldReturnTwoHundredAndSixty()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 260);
        }

        [TestMethod]
        public void ScanTwoSkuBItems_ShouldReturnFourtyFive()
        {
            checkout.Scan("B");
            checkout.Scan("B");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 45);
        }

        [TestMethod]
        public void ScanFourSkuBItems_ShouldReturnNinety()
        {
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");

            var price = checkout.GetTotalPrice();

            Assert.IsTrue(price == 90);
        }
    }
}
