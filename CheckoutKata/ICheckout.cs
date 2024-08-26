namespace CheckoutKata
{
    internal interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
