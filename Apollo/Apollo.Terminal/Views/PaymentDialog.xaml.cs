using Apollo.Core;
using Apollo.Core.Services;
using Apollo.Domain;
using Apollo.Terminal.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Apollo.Terminal.Views
{
    /// <summary>
    /// Interaction logic for PaymentDialog.xaml
    /// </summary>
    public partial class PaymentDialog : Window
    {
		private PaymentDialogViewModel paymentDialogViewModel;
        public PaymentDialog(decimal total, ObservableCollection<Seat> reservedSeats, Show show)
        {
            InitializeComponent();
			paymentDialogViewModel = new PaymentDialogViewModel(total, reservedSeats, show, new PaymentService(), new PrintService(), ServiceFactory.GetReservationService());
			DataContext = paymentDialogViewModel;
		}

		private async void processPaymentButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			string errorMessage = await paymentDialogViewModel.HandlePayment(ccnInput.Text, paymentDialogViewModel.Total);

			if (errorMessage != "")
            {
				MessageBox.Show(errorMessage);
            }
            else
            {
				MessageBox.Show("Payment successful, printing tickets...");
				paymentDialogViewModel.CompleteReservation();
				MessageBox.Show("You can find your tickets on your desktop!");
			}
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			ccnInput.SelectAll();
			ccnInput.Focus();
		}
	}
}
