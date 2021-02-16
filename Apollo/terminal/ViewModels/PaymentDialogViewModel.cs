using Apollo.Core.Interface.Services;
using Apollo.Domain;
using FHPay;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Apollo.Terminal.ViewModels
{
    public class PaymentDialogViewModel
    {
        private readonly IPaymentService paymentService;
        private readonly IPrintService printService;
        private readonly IReservationService reservationService;
        public PaymentDialogViewModel(decimal total, ObservableCollection<Seat> reservedSeats, Show show, IPaymentService paymentService, IPrintService printService, IReservationService reservationService)
        {
            this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            this.printService = printService ?? throw new ArgumentNullException(nameof(printService));
            this.reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            Total = total;
            ReservedSeats = reservedSeats;
            Show = show;
        }

        public decimal Total { get; }
        public ObservableCollection<Seat> ReservedSeats { get;  }
        public Show Show { get; }


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

        public async void CompleteReservation()
        {
            foreach (var seat in ReservedSeats)
            {
                long reservationID = await reservationService.CreateReservation(Show, 10, seat.SeatNumber, seat.RowNumber);
                PrintTicket(reservationID.ToString(), seat);
            }
        }

        public void PrintTicket(string reservationId, Seat seat)
        {
            string[] paragraphs = new string[15];
            paragraphs[0] = "Apollo Cinemas";
            paragraphs[1] = "=======================";
            paragraphs[2] = "";
            paragraphs[3] = "";
            paragraphs[4] = "Ticket ID: " + reservationId;
            paragraphs[5] = "Show: " + Show.Movie.Title;
            paragraphs[6] = "Begin: " + Show.StartsAt;
            paragraphs[7] = "Hall: " + Show.CinemaHall.Name;
            paragraphs[8] = "Row: " + seat.RowNumber + ", Seat: " + seat.SeatNumber;
            paragraphs[9] = "Price: " + seat.SeatCategory.Price + "€ (paid by card)";
            paragraphs[10] = "Printed at: " + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            paragraphs[11] = "";
            paragraphs[12] = "";
            paragraphs[13] = "Thank you for choosing Apollo today!";
            paragraphs[14] = "Apollo Entertainment, Ltd. 2021";
            
            printService.PrintDocument(paragraphs, "ticket" + reservationId);
        }
    }
}