using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Apollo.Terminal.ViewModels
{
    public class ShowDetailsViewModel
    {
        private readonly ISeatService seatService;
        public ShowDetailsViewModel(Show show, ISeatService seatService)
        {
            Show = show ?? throw new ArgumentNullException(nameof(show));
            this.seatService = seatService ?? throw new ArgumentNullException(nameof(seatService));
            Seats = new ObservableCollection<Seat>();
        }

        public Show Show { get; }
        public ObservableCollection<Seat> Seats { get; }

        public async Task InitializeAsync()
        {
            var seats = await seatService.GetSeatsByCinemaHall(Show.CinemaHall);
            foreach (var seat in seats)
            {
                Seats.Add(seat);
            }
        }
    }
}