using Apollo.Core;
using Apollo.Terminal.ViewModels;
using System.Windows;
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

            PreviewKeyDown += new KeyEventHandler(HandleEsc);

            Loaded += async (s, e) => await showOverviewViewModel.InitializeAsync();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Searching...");
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
