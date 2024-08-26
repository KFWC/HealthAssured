using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public List<Item> scannedItems {  get; set; }
        public List<Product> products {  get; set; }
        public List<SpecialOffer> specialOffers { get; set; }

        public Checkout(List<Product> listProducts, List<SpecialOffer> listOffers)
        {
            scannedItems = new List<Item>();

            products = listProducts;
            specialOffers = listOffers;
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (Item item in scannedItems)
            {
                var specialOffer = specialOffers.FirstOrDefault(s => s.Sku == item.Sku);
                var product = products.FirstOrDefault(s => s.Sku == item.Sku);

                if (specialOffer != null)
                {
                    totalPrice += (item.Amount / specialOffer.Amount) * specialOffer.Price;
                    totalPrice += (item.Amount % specialOffer.Amount) * product.Price;
                }
                else
                {
                    totalPrice += (item.Amount * product.Price);
                }
            }

            return totalPrice;
        }

        public void Scan(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                var product = products.FirstOrDefault(s => s.Sku == item);
                if (product != null)
                {
                    var scannedItem = scannedItems.FirstOrDefault(s => s.Sku == item);
                    if (scannedItem != null)
                    {
                        scannedItem.Amount++;
                    }
                    else
                    {
                        scannedItems.Add(new Item { Sku = item, Amount = 1 });
                    }
                }
            }
        }
    }
}
