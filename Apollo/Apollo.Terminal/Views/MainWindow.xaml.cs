using System.Windows;
using System.Windows.Input;

namespace Apollo.Terminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            ShowOverview showOverview = new ShowOverview();
            showOverview.ShowDialog();
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
