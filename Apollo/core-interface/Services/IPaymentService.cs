using FHPay;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    public interface IPaymentService
    {
        Task<PaymentResult> ProcessPayment(string cardNumber, decimal amount);
    }
}
