namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public char[] scannedItems {  get; set; }

        public int GetTotalPrice()
        {
            throw new System.NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new System.NotImplementedException();
        }
    }
}
