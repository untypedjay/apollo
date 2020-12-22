using Apollo.Core.Interface.Services;
using FHPay;
using System;
using System.Threading.Tasks;

namespace Apollo.Core.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<PaymentResult> ProcessPayment(string cardNumber, decimal amount)
        {
            PaymentApi api = new PaymentApi(Environment.GetEnvironmentVariable("fhpay"));
            CardValidationCode cardValidationCode = new CardValidationCode();
            ExpirationDate expirationDate = new ExpirationDate();
            CreditCardNumber creditCardNumber = new CreditCardNumber(cardNumber);
            CreditCard creditCard = new CreditCard("Jeff Bezos", creditCardNumber, expirationDate, cardValidationCode);
            return await api.CreateTransactionAsync(amount, creditCard, "This is a description");
        }
    }
}
