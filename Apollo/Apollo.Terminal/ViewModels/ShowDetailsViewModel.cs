using Apollo.Domain;
using System;
using System.Threading.Tasks;

namespace Apollo.Terminal.ViewModels
{
    public class ShowDetailsViewModel
    {
        public ShowDetailsViewModel(Show show)
        {
            Show = show ?? throw new ArgumentNullException(nameof(show));
            Show = show;
        }

        public Show Show { get; }

        public async Task InitializeAsync()
        {

        }
    }
}
