using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Apollo.Terminal.ViewModels
{
    public class ShowDetailsViewModel : INotifyPropertyChanged
    {
        private readonly ISeatService seatService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ShowDetailsViewModel(Show show, ISeatService seatService)
        {
            Show = show ?? throw new ArgumentNullException(nameof(show));
            this.seatService = seatService ?? throw new ArgumentNullException(nameof(seatService));
            Seats = new ObservableCollection<Seat>();
            Total = 0;
            ReservedSeats = new ObservableCollection<Seat>();
        }

        public Show Show { get; }
        public ObservableCollection<Seat> Seats { get; }
        private decimal total;

        public decimal Total
        {
            get { return total; }
            set
            {
                total = value;
                NotifyPropertyChanged("Total");
            }
        }

        public ObservableCollection<Seat> ReservedSeats { get; set; }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async Task InitializeAsync()
        {
            var seats = await seatService.GetSeatsByCinemaHall(Show.CinemaHall);
            foreach (var seat in seats)
            {
                Seats.Add(seat);
            }
        }

        public void AddToCheckout(Seat seat)
        {
            ReservedSeats.Add(seat);
            Total = Total + seat.SeatCategory.Price;
        }
    }
}