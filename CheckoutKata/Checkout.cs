using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public List<Item> scannedItems {  get; set; }

        public Checkout()
        {
            scannedItems = new List<Item>();
        }

        public int GetTotalPrice()
        {
            throw new System.NotImplementedException();
        }

        public void Scan(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                var scannedItem = scannedItems.FirstOrDefault(s => s.Sku == item);

                if (scannedItem != null)
                {
                    scannedItem.Amount++;
                }
                else
                {
                    scannedItems.Add(new Item { Sku = item, Amount = 1});
                }
            }
        }
    }
}
