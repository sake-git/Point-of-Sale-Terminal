

namespace Point_of_Sale.Payment_Gateway
{
    internal interface IPayment
    {
        public string Payment(double amount);
    }
}
