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

        public ShowOverviewViewModel(IShowService showService)
        {
            this.showService = showService ?? throw new ArgumentNullException(nameof(showService));
            Shows = new ObservableCollection<Show>();
        }
        
        public ObservableCollection<Show> Shows { get; }

        public async Task InitializeAsync()
        {
            var shows = await showService.GetShowsToday();
            foreach (var show in shows)
            {
                Shows.Add(show);
            }
        }

        public async Task SearchByTitle(string searchTerm)
        {
            EmptyShowContainer();
            var shows = await showService.GetShowsByMovieSearch(searchTerm);
            foreach (var show in shows)
            {
                Shows.Add(show);
            }
        }

        public async Task SearchByGenre(string searchTerm)
        {
            EmptyShowContainer();
            var shows = await showService.GetShowsByGenreSearch(searchTerm);
            foreach (var show in shows)
            {
                Shows.Add(show);
            }
        }

        private void EmptyShowContainer()
        {
            for (int i = 0; i < Shows.Count; i++)
            {
                Shows.Remove(Shows[i]);
            }
        }
    }
}
