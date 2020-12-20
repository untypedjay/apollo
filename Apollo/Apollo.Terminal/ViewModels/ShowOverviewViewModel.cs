using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Apollo.Terminal.ViewModels
{
    public class ShowOverviewViewModel
    {
        private readonly IShowService showService;
        private ShowDetailsViewModel currentShow;

        public ShowOverviewViewModel(IShowService showService)
        {
            this.showService = showService ?? throw new ArgumentNullException(nameof(showService));
            Shows = new ObservableCollection<Show>();
        }
        
        public ObservableCollection<Show> Shows { get; }

        public ShowDetailsViewModel CurrentShow
        {
            get => currentShow;
            set
            {
                currentShow = value;
            }
        }

        public async Task InitializeAsync()
        {
            var shows = await showService.GetShowsToday();
            foreach (var show in shows)
            {
                Shows.Add(show);
            }
        }
    }
}
