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
        public PaymentDialog(decimal total)
        {
            InitializeComponent();
			paymentDialogViewModel = new PaymentDialogViewModel(total, new PaymentService(), new PrintService());
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
				MessageBox.Show("Payment successful, printing ticket...");
				paymentDialogViewModel.PrintTicket("827492", "The Wolf of Wallstreet", "December 22th, 2020 8pm", "Row: 6 Seat: 3", paymentDialogViewModel.Total.ToString());
				MessageBox.Show("You can find your ticket on your desktop!");
			}
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			ccnInput.SelectAll();
			ccnInput.Focus();
		}
	}
}
