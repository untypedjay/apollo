using Apollo.Core.Interface.Services;
using Apollo.Domain;
using FHPay;
using System;
using System.Threading.Tasks;

namespace Apollo.Terminal.ViewModels
{
    public class PaymentDialogViewModel
    {
        private readonly IPaymentService paymentService;
        private readonly IPrintService printService;
        public PaymentDialogViewModel(Seat seat, IPaymentService paymentService, IPrintService printService)
        {
            Seat = seat ?? throw new ArgumentNullException(nameof(seat));
            this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            this.printService = printService ?? throw new ArgumentNullException(nameof(printService));
        }

        public Seat Seat { get; }

        public async Task<string> HandlePayment(string cardNumber, decimal amount)
        {
            var result = await paymentService.ProcessPayment(cardNumber, amount);
            switch (result)
            {
                case PaymentResult.CardReportedLost:
                    return "Payment failed: Credit card was reported or lost!";
                case PaymentResult.InvalidName:
                    return "Payment failed: Name is invalid!";
                case PaymentResult.InvalidCardValidationCode:
                    return "Payment failed: Validation code is invalid!";
                case PaymentResult.InvalidExpirationDate:
                    return "Payment failed: Expiration date is invalid!";
                case PaymentResult.InsufficientFunds:
                    return "Payment failed: Credit card balance too low to process payment!";
                default:
                    return "";
            }
        }

        public void PrintTicket(string reservationId, string movieTitle, string date, string seats, string price)
        {
            string[] paragraphs = new string[6];
            paragraphs[0] = "Ticket " + reservationId;
            paragraphs[1] = movieTitle;
            paragraphs[2] = "Begin: " + date;
            paragraphs[3] = "Seats: " + seats;
            paragraphs[4] = price + " (payed by card)";
            paragraphs[5] = "Thank you for choosing Apollo today!";
            printService.PrintDocument(paragraphs, "ticket" + reservationId);
        }
    }
}