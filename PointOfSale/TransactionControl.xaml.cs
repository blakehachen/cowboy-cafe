/*

* Author: Blake Hachen

* Class name: TransactionControl.xaml.cs

* Purpose: Control the transaction within CowboyCafe

*/
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CashRegister;
using CowboyCafe.Data;
using CowboyCafe.PointOfSale;


namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for TransactionControl.xaml
    /// </summary>
    public partial class TransactionControl : UserControl
    {
        public TransactionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves Order instance to use with cashregistermodelview
        /// </summary>
        private Order savedOrder;

        /// <summary>
        /// Specifies credit payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaymentCredit_Click(object sender, RoutedEventArgs e)
        {

            
            var terminal = new CardTerminal();
            var printer = new ReceiptPrinter();
            if(DataContext is Order)
            {
                var data = DataContext as Order;
                
                //Implies Credit Payment type false would imply a debit payment type.
                data.PaymentType = true;
                ResultCode result = terminal.ProcessTransaction(data.Total);
                switch (result)
                {
                    case ResultCode.Success:
                        printer.Print(data.Receipt);
                        CardPayment();
                        MessageBox.Show("Transaction Successful!");
                        break;
                    case ResultCode.CancelledCard:
                        CardPayment();
                        MessageBox.Show("Transaction failed due to cancelled card.");
                        break;
                    case ResultCode.InsufficentFunds:
                        CardPayment();
                        MessageBox.Show("Transaction failed due to Insufficient Funds.");
                        break;
                    case ResultCode.ReadError:
                        CardPayment();
                        MessageBox.Show("Transaction failed due to Read Error.");
                        break;
                    case ResultCode.UnknownErrror:
                        CardPayment();
                        MessageBox.Show("Transaction failed due to unkown error.");
                        break;
                    default:
                        CardPayment();
                        MessageBox.Show("Transaction failed due to unkown error.");
                        break;

                }
            }
        }

        /// <summary>
        /// Specifies Cash Payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaymentCash_Click(object sender, RoutedEventArgs e)
        {

            
            if(DataContext is Order)
            {

                var orderControl = this.FindAncestor<OrderControl>();
                orderControl.ItemSelectionButton.IsEnabled = false;
                orderControl.CompleteOrderButton.IsEnabled = false;
                savedOrder = DataContext as Order;
                var cashRegister = new CashRegisterModelView();
                this.DataContext = cashRegister;
                btnCashPay1.IsEnabled = false;
                btnCreditPay.IsEnabled = false;
            }
            
                
            
            
            

        }

        /// <summary>
        /// Finalizes the cash payment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinalizeCashPayment(object sender, RoutedEventArgs e)
        {
            var orderControl = this.FindAncestor<OrderControl>();
            orderControl.ItemSelectionButton.IsEnabled = true;
            orderControl.CompleteOrderButton.IsEnabled = true;
            var register = DataContext as CashRegisterModelView;
            var printer = new ReceiptPrinter();

            try
            {

                if (register.TotalCash >= savedOrder.Total && savedOrder.Total != 0 && register != null)
                {

                    register.ChangeToReturn(Math.Round(savedOrder.Total, 2), Math.Round(register.TotalCash, 2));
                    if (register.RegisterFailure == true)
                    {
                        register.ResetCash(Math.Round(register.TotalCash, 2));
                        MessageBox.Show("Something went wrong with your current order. Create a new one.");
                        CardPayment();
                    }
                    else
                    {

                        MessageBox.Show(register.DenominationAmount);
                        savedOrder.PaymentType = false;
                        savedOrder.CashPaid = Math.Round(register.TotalCash, 2);
                        savedOrder.Change = Math.Round(register.TotalCash - savedOrder.Total, 2);
                        printer.Print(savedOrder.Receipt);
                        CardPayment();
                    }


                }
                else
                {
                    MessageBox.Show("A transaction error has occured.");
                    register.ChangeToReturn(0, register.TotalCash);
                    CardPayment();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No Payment Type Selected.");
                CardPayment();

            }
        }

        /// <summary>
        /// A payment, card/cash was made and a new Order instance has been created
        /// </summary>
        private void CardPayment()
        {
            DataContext = new Order();
            var orderControl = this.FindAncestor<OrderControl>();
            orderControl?.SwapScreenAndNewOrder(new MenuItemSelectionControl());
        }

        


    }
}
