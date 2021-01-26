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
        public PaymentDialogViewModel(decimal total, IPaymentService paymentService, IPrintService printService)
        {
            this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            this.printService = printService ?? throw new ArgumentNullException(nameof(printService));
            Total = total;
        }

        public decimal Total { get; }

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
            string[] paragraphs = new string[14];
            paragraphs[0] = "Apollo Cinemas";
            paragraphs[1] = "=======================";
            paragraphs[2] = "";
            paragraphs[3] = "";
            paragraphs[4] = "Ticket ID: " + reservationId;
            paragraphs[5] = "Show: " + movieTitle;
            paragraphs[6] = "Begin: " + date;
            paragraphs[7] = "Seats: " + seats;
            paragraphs[8] = price + "€ (payed by card)";
            paragraphs[9] = "Printed at: " + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            paragraphs[10] = "";
            paragraphs[11] = "";
            paragraphs[12] = "Thank you for choosing Apollo today!";
            paragraphs[13] = "Apollo Entertainment, Ltd. 2021";
            
            printService.PrintDocument(paragraphs, "ticket" + reservationId);
        }
    }
}