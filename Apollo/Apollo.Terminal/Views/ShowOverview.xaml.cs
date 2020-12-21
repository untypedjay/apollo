using Apollo.Core;
using Apollo.Domain;
using Apollo.Terminal.ViewModels;
using Apollo.Terminal.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Apollo.Terminal
{
    /// <summary>
    /// Interaction logic for ShowOverview.xaml
    /// </summary>
    public partial class ShowOverview : Window
    {
        private ShowOverviewViewModel showOverviewViewModel;
        public ShowOverview()
        {
            InitializeComponent();

            showOverviewViewModel = new ShowOverviewViewModel(ServiceFactory.GetShowService());
            DataContext = showOverviewViewModel;

            PreviewKeyDown += new KeyEventHandler(HandleEsc);

            Loaded += async (s, e) => await showOverviewViewModel.InitializeAsync();
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = searchTextBox.Text;
            if (searchTypeComboBox.Text == "Title")
            {
                await showOverviewViewModel.SearchByTitle(searchTerm);
            }
            else
            {
                await showOverviewViewModel.SearchByGenre(searchTerm);
            }
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }


        private void showContainer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(showContainer, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                ShowDetails showDetails = new ShowDetails((Show)item.DataContext);
                showDetails.ShowDialog();
            }
        }
    }
}
