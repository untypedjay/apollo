using Apollo.Core.Services;
using Apollo.Domain;
using Apollo.Terminal.ViewModels;
using IronPdf;
using System;
using System.Windows;

namespace Apollo.Terminal.Views
{
    /// <summary>
    /// Interaction logic for PaymentDialog.xaml
    /// </summary>
    public partial class PaymentDialog : Window
    {
		private PaymentDialogViewModel paymentDialogViewModel;
        public PaymentDialog(Seat seat)
        {
            InitializeComponent();
			paymentDialogViewModel = new PaymentDialogViewModel(seat, new PaymentService(), new PrintService());
			DataContext = paymentDialogViewModel;
		}

		private async void processPaymentButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			string errorMessage = await paymentDialogViewModel.HandlePayment(ccnInput.Text, 12.99m);

			if (errorMessage != "")
            {
				MessageBox.Show(errorMessage);
            }
            else
            {
				paymentDialogViewModel.PrintTicket("827492", "The Wolf of Wallstreet", "December 22th, 2020 8pm", "Row: 6 Seat: 3", "12.99€");
				MessageBox.Show("Payment successful!");
			}
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			ccnInput.SelectAll();
			ccnInput.Focus();
		}
	}
}
