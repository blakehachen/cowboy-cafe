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
                result = ResultCode.Success;
                switch (result)
                {
                    case ResultCode.Success:
                        printer.Print(data.Receipt);
                        CardPayment();
                        break;
                    case ResultCode.CancelledCard:
                        CardPayment();
                        break;
                    case ResultCode.InsufficentFunds:
                        CardPayment();
                        break;
                    case ResultCode.ReadError:
                        CardPayment();
                        break;
                    case ResultCode.UnknownErrror:
                        CardPayment();
                        break;
                    default:
                        CardPayment();
                        break;

                }
            }
        }

        private void OnPaymentCash_Click(object sender, RoutedEventArgs e)
        {
            
            var cashRegister = new CashRegisterModelView();
            this.DataContext = cashRegister;
        }

        private void CardPayment()
        {
            DataContext = new Order();
            var orderControl = this.FindAncestor<OrderControl>();
            orderControl?.SwapScreenAndNewOrder(new MenuItemSelectionControl());
        }


    }
}
