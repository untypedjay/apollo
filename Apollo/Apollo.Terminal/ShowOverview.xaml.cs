using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Apollo.Terminal
{
    /// <summary>
    /// Interaction logic for ShowOverview.xaml
    /// </summary>
    public partial class ShowOverview : Window
    {
        public ShowOverview()
        {
            InitializeComponent();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
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
