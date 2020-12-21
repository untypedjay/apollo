using Apollo.Domain;
using Apollo.Terminal.ViewModels;
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
            showDetailsViewModel = new ShowDetailsViewModel(currentShow);
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
            MessageBox.Show("Processing payment...");
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
