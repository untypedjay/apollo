using Apollo.Core;
using Apollo.Domain;
using Apollo.Terminal.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Apollo.Terminal.Views
{
    /// <summary>
    /// Interaction logic for ShowDetails.xaml
    /// </summary>
    public partial class ShowDetails : Window
    {
        private ShowDetailsViewModel showDetailsViewModel;
        public ShowDetails(Show currentShow)
        {
            InitializeComponent();
            showDetailsViewModel = new ShowDetailsViewModel(currentShow, ServiceFactory.GetSeatService());
            DataContext = showDetailsViewModel;

            PreviewKeyDown += new KeyEventHandler(HandleEsc);

            Loaded += async (s, e) => await showDetailsViewModel.InitializeAsync();
        }

        private void cancelButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void completeButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PaymentDialog paymentDialog = new PaymentDialog(showDetailsViewModel.Total);
            paymentDialog.ShowDialog();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void cinemaLayoutContainer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(cinemaLayoutContainer, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                Seat currentSeat = (Seat)item.DataContext;
                showDetailsViewModel.AddToCheckout(currentSeat.SeatCategory.Price);
            }
        }
    }
}
