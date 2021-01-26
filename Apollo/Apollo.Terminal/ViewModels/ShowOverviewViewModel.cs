using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Apollo.Terminal.ViewModels
{
    public class ShowOverviewViewModel
    {
        private readonly IShowService showService;

        public ShowOverviewViewModel(IShowService showService)
        {
            this.showService = showService ?? throw new ArgumentNullException(nameof(showService));
            Shows = new ObservableCollection<Show>();
        }
        
        public ObservableCollection<Show> Shows { get; }

        public async Task InitializeAsync()
        {
            await GetShowsToday();
        }

        public async Task GetShowsToday()
        {
            var shows = await showService.GetShowsToday();
            UpdateShows(shows);
        }

        public async Task SearchByTitle(string searchTerm)
        {
            var shows = await showService.GetShowsByMovieSearch(searchTerm);
            UpdateShows(shows);
        }

        public async Task SearchByGenre(string searchTerm)
        {
            var shows = await showService.GetShowsByGenreSearch(searchTerm);
            UpdateShows(shows);
        }

        private void UpdateShows(IEnumerable<Show> shows)
        {
            Shows.Clear();
            foreach (var show in shows)
            {
                Shows.Add(show);
            }
        }
    }
}
