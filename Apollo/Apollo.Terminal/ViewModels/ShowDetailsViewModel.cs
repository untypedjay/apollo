using Apollo.Domain;
using System;

namespace Apollo.Terminal.ViewModels
{
    public class ShowDetailsViewModel
    {
        public ShowDetailsViewModel(Show show)
        {
            Show = show ?? throw new ArgumentNullException(nameof(show));
        }

        public Show Show { get; }
    }
}
