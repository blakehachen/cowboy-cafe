/*

* Author: Blake Hachen
* Co-Author: Nathan Bean

* Class name: CashRegisterModelView.cs

* Purpose: This will control the cash transaction. whether change is needed and the quantities of denominations within the register

*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using CashRegister;
using System.Windows;

namespace PointOfSale
{
    public class CashRegisterModelView : INotifyPropertyChanged
    {
        /// <summary>
        /// Property Changed Event Handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Static cash drawer that represents the register on a given day.
        /// </summary>
        public static CashDrawer drawer = new CashDrawer();

        /// <summary>
        /// Gets total cash in drawer
        /// </summary>
        public double TotalValue => drawer.TotalValue;


        private double totalCash;
        /// <summary>
        /// Represents the total cash added to register by customer.
        /// </summary>
        public double TotalCash {
            get
            {
                return totalCash;
            }
            set
            {
                if(totalCash >= 0)
                {
                    totalCash = value;
                }
                else
                {
                    totalCash += -totalCash;
                }
                InvokePropertyChanged("TotalCash");
            }
        }
        
        /// <summary>
        /// The Pennies that are in the register
        /// </summary>
        public int Pennies
        {
            get => drawer.Pennies;
            set
            {
                if (drawer.Pennies == value || value < 0) return;
                var quantity = value - drawer.Pennies;

                if (quantity > 0)
                {
                    if (TotalCash >= 0 && TotalCash + 0.01 > 0)
                    {
                        drawer.AddCoin(Coins.Penny, quantity);
                        TotalCash += 0.01;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 0.01) >= 0)
                    {
                        drawer.RemoveCoin(Coins.Penny, -quantity);
                        TotalCash -= 0.01;

                    }

                }
                InvokePropertyChanged("Pennies");
            }
        }

        /// <summary>
        /// The Nickels that are in the register
        /// </summary>
        public int Nickels
        {
            get => drawer.Nickels;
            set
            {
                if (drawer.Nickels == value || value < 0) return;
                var quantity = value - drawer.Nickels;
                if (quantity > 0)
                {
                    if(TotalCash >= 0 && TotalCash + 0.05 > 0)
                    {
                        drawer.AddCoin(Coins.Nickel, quantity);
                        TotalCash += 0.05;
                    }
                    
                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash-0.05) >= 0) 
                    { 
                        drawer.RemoveCoin(Coins.Nickel, -quantity);
                        TotalCash -= 0.05;
                        
                    }   
                    
                }
                InvokePropertyChanged("Nickels");


            }
        }

        /// <summary>
        /// The Dimes that are in the register
        /// </summary>
        public int Dimes
        {
            get => drawer.Dimes;
            set
            {
                if (drawer.Dimes == value || value < 0) return;
                var quantity = value - drawer.Dimes;
                if (quantity > 0)
                {
                    if (TotalCash >= 0 && TotalCash + 0.10 > 0)
                    {
                        drawer.AddCoin(Coins.Dime, quantity);
                        TotalCash += 0.10;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 0.10) >= 0)
                    {
                        drawer.RemoveCoin(Coins.Dime, -quantity);
                        TotalCash -= 0.10;

                    }

                }
                InvokePropertyChanged("Dimes");
            }
        }

        /// <summary>
        /// The Quarters that are in the register
        /// </summary>
        public int Quarters
        {
            get => drawer.Quarters;
            set
            {
                if (drawer.Quarters == value || value < 0) return;
                var quantity = value - drawer.Quarters;
                if (quantity > 0)
                {
                    if (TotalCash >= 0 && TotalCash + 0.25 > 0)
                    {
                        drawer.AddCoin(Coins.Quarter, quantity);
                        TotalCash += 0.25;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 0.25) >= 0)
                    {
                        drawer.RemoveCoin(Coins.Quarter, -quantity);
                        TotalCash -= 0.25;

                    }

                }
                InvokePropertyChanged("Quarters");
            }
        }

        /// <summary>
        /// The Half Dollars that are in the register
        /// </summary>
        public int HalfDollars
        {
            get => drawer.HalfDollars;
            set
            {
                if (drawer.HalfDollars == value || value < 0) return;
                var quantity = value - drawer.HalfDollars;
                if (quantity > 0)
                {
                    if (TotalCash >= 0 && TotalCash + 0.50 > 0)
                    {
                        drawer.AddCoin(Coins.HalfDollar, quantity);
                        TotalCash += 0.50;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 0.50) >= 0)
                    {
                        drawer.RemoveCoin(Coins.HalfDollar, -quantity);
                        TotalCash -= 0.50;

                    }

                }
                InvokePropertyChanged("HalfDollars");
            }
        }

        /// <summary>
        /// The Dollars that are in the register
        /// </summary>
        public int Dollars
        {
            get => drawer.Dollars;
            set
            {
                if (drawer.Dollars == value || value < 0) return;
                var quantity = value - drawer.Dollars;
                if (quantity > 0)
                {
                    if (TotalCash >= 0 && TotalCash + 1.00 > 0)
                    {
                        drawer.AddCoin(Coins.Dollar, quantity);
                        TotalCash += 1.00;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 1.00) >= 0)
                    {
                        drawer.RemoveCoin(Coins.Dollar, -quantity);
                        TotalCash -= 1.00;

                    }

                }
                InvokePropertyChanged("Dollars");
            }
        }

        /// <summary>
        /// The Ones that are in the register
        /// </summary>
        public int Ones
        {
            get => drawer.Ones;
            set
            {
                if (drawer.Ones == value || value < 0) return;
                var quantity = value - drawer.Ones;
                if (quantity > 0)
                {
                    if (TotalCash >= 0 && TotalCash + 1.00 > 0)
                    {
                        drawer.AddBill(Bills.One, quantity);
                        TotalCash += 1.00;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 1.00) >= 0)
                    {
                        drawer.RemoveBill(Bills.One, -quantity);
                        TotalCash -= 1.00;

                    }

                }
                InvokePropertyChanged("Ones");
            }
        }

        /// <summary>
        /// The Twos that are in the register
        /// </summary>
        public int Twos
        {
            get => drawer.Twos;
            set
            {
                if (drawer.Twos == value || value < 0) return;
                var quantity = value - drawer.Twos;
                if (quantity > 0)
                {
                    if (TotalCash >= 0)
                    {
                        drawer.AddBill(Bills.Two, quantity);
                        TotalCash += 2.00;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 2.00) >= 0)
                    {
                        drawer.RemoveBill(Bills.Two, -quantity);
                        TotalCash -= 2.00;

                    }

                }
                InvokePropertyChanged("Twos");
            }
        }

        /// <summary>
        /// The Fives that are in the register
        /// </summary>
        public int Fives
        {
            get => drawer.Fives;
            set
            {
                if (drawer.Fives == value || value < 0) return;
                var quantity = value - drawer.Fives;
                if (quantity > 0)
                {
                    if (TotalCash >= 0)
                    {
                        drawer.AddBill(Bills.Five, quantity);
                        TotalCash += 5.00;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 5.00) >= 0)
                    {
                        drawer.RemoveBill(Bills.Five, -quantity);
                        TotalCash -= 5.00;

                    }

                }
                InvokePropertyChanged("Fives");
            }
        }

        /// <summary>
        /// The Tens that are in the register
        /// </summary>
        public int Tens
        {
            get => drawer.Tens;
            set
            {
                if (drawer.Tens == value || value < 0) return;
                var quantity = value - drawer.Tens;
                if (quantity > 0)
                {
                    if (TotalCash >= 0)
                    {
                        drawer.AddBill(Bills.Ten, quantity);
                        TotalCash += 10.00;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 10.00) >= 0)
                    {
                        drawer.RemoveBill(Bills.Ten, -quantity);
                        TotalCash -= 10.00;

                    }

                }
                InvokePropertyChanged("Tens");
            }
        }

        /// <summary>
        /// The Twenties that are in the register
        /// </summary>
        public int Twenties
        {
            get => drawer.Twenties;
            set
            {
                if (drawer.Twenties == value || value < 0) return;
                var quantity = value - drawer.Twenties;
                if (quantity > 0)
                {
                    if (TotalCash >= 0)
                    {
                        drawer.AddBill(Bills.Twenty, quantity);
                        TotalCash += 20.00;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 20.00) >= 0)
                    {
                        drawer.RemoveBill(Bills.Twenty, -quantity);
                        TotalCash -= 20.00;

                    }

                }
                InvokePropertyChanged("Twenties");
            }
        }
        /// <summary>
        /// The Fifties that are in the register
        /// </summary>
        public int Fifties
        {
            get => drawer.Fifties;
            set
            {
                if (drawer.Fifties == value || value < 0) return;
                var quantity = value - drawer.Fifties;
                if (quantity > 0)
                {
                    if (TotalCash >= 0)
                    {
                        drawer.AddBill(Bills.Fifty, quantity);
                        TotalCash += 50.00;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 50.00) >= 0)
                    {
                        drawer.RemoveBill(Bills.Fifty, -quantity);
                        TotalCash -= 50.00;

                    }

                }
                InvokePropertyChanged("Fifties");
            }
        }

        /// <summary>
        /// The hundreds that are in the register
        /// </summary>
        public int Hundreds
        {
            get => drawer.Hundreds;
            set
            {
                if (drawer.Hundreds == value || value < 0) return;
                var quantity = value - drawer.Hundreds;
                if (quantity > 0)
                {
                    if (TotalCash >= 0)
                    {
                        drawer.AddBill(Bills.Hundred, quantity);
                        TotalCash += 100.00;
                    }

                }
                else
                {
                    if (TotalCash >= 0 && (TotalCash - 100.00) >= 0)
                    {
                        drawer.RemoveBill(Bills.Hundred, -quantity);
                        TotalCash -= 100.00;

                    }

                }
                InvokePropertyChanged("Hundreds");
            }
        }

        private bool registerFailure = false;
        /// <summary>
        /// boolean in control of checking for a transaction failure
        /// </summary>
        public bool RegisterFailure
        {
            get => registerFailure;
            set
            {
                registerFailure = value;
            }
        }

        /// <summary>
        /// String builder that will tell the cashier the change that needs to be given back to the customer.
        /// </summary>
        StringBuilder denominationAmount = new StringBuilder();
        

        /// <summary>
        /// Collection of denomination counters to check if a denomination needs to be returned to the register in case of transaction failure.
        /// </summary>
        private int pennyCount = 0;
        private int nickelCount = 0;
        private int dimeCount = 0;
        private int quarterCount = 0;
        private int dollarCount = 0;
        private int halfdollarCount = 0;
        private int oneCount = 0;
        private int twoCount = 0;
        private int fiveCount = 0;
        private int tenCount = 0;
        private int twentyCount = 0;
        private int fiftyCount = 0;
        private int hundredCount = 0;


        /// <summary>
        /// The Initialization of the string builder above.
        /// </summary>
        public string DenominationAmount => denominationAmount.ToString();

        /// <summary>
        /// Function in charge of getting the change back to the customer
        /// </summary>
        /// <param name="priceOfOrder">Total Order Price</param>
        /// <param name="totalPaid">Total Paid by customer</param>
        public void ChangeToReturn(double priceOfOrder, double totalPaid)
        {
            
            var change = totalPaid - priceOfOrder;

            var denominations = new[]
            {
                new {denom = "Hundred", val=100.00},
                new {denom = "Fifty", val=50.00},
                new {denom = "Twenty", val=25.00},
                new {denom = "Ten", val=10.00},
                new {denom = "Five", val=5.00},
                new {denom = "Two", val=2.00},
                new {denom = "One", val=1.00},
                new {denom = "Dollar", val=1.00},
                new {denom = "HalfDollar", val=0.50},
                new {denom = "Quarter", val=0.25},
                new {denom = "Dime", val=0.10},
                new {denom = "Nickel", val=0.05},
                new {denom = "Penny", val=0.01}
                
            };

            
            foreach(var item in denominations)
            {
                
                int count = (int) (change / item.val);
                change -= Math.Round((count * item.val),2);
                change = Math.Round(change, 2);

                if(count > 0)
                {
                    switch (item.denom)
                    {
                        case "Hundred":
                            try
                            {
                                if (drawer.Hundreds > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Hundred, 1);
                                        
                                        hundredCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Hundreds.\n");
                                    InvokePropertyChanged("Hundreds");






                                }
                                else if (drawer.Hundreds <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                                
                            }
                            break;
                        case "Fifty":
                            try
                            {
                                if (drawer.Fifties > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Fifty, 1);
                                        
                                        fiftyCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Fifties.\n");
                                    InvokePropertyChanged("Fifties");






                                }
                                else if (drawer.Fifties <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                                
                            }

                            break;
                        case "Twenty":
                            try
                            {
                                if (drawer.Twenties > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Twenty, 1);
                                        
                                        twentyCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Twenties.\n");
                                    InvokePropertyChanged("Twenties");






                                }
                                else if (drawer.Twenties <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                                
                            }
                            break;
                        case "Ten":

                            try
                            {
                                if (drawer.Tens > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Ten, 1);
                                        
                                        tenCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Tens.\n");
                                    InvokePropertyChanged("Tens");






                                }
                                else if (drawer.Twos <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                                
                            }
                            break;
                        case "Five":
                            try
                            {
                                if (drawer.Fives > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Five, 1);
                                        
                                        fiveCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Fives.\n");
                                    InvokePropertyChanged("Fives");





                                }
                                else if (drawer.Fives <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                                
                            }
                            break;
                        case "Two":
                            try
                            {
                                if (drawer.Twos > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Two, 1);
                                        twoCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Twos.\n");
                                    InvokePropertyChanged("Twos");





                                }
                                else if (drawer.Twos <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                registerFailure = true;
                                
                            }
                            break;
                        case "One":
                            try
                            {
                                if (drawer.Dimes > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.One, 1);
                                        oneCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Ones.\n");
                                    InvokePropertyChanged("Ones");


                                }
                                else if (drawer.Ones <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                                
                            }
                            break;
                        case "Dollar":
                            try
                            {
                                if (drawer.Dollars > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Dollar, 1);
                                        dollarCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Dollars.\n");
                                    InvokePropertyChanged("Dollars");






                                }
                                else if (drawer.Dimes <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                                
                            }

                            break;
                        case "HalfDollar":
                            try
                            {
                                if (drawer.HalfDollars > 0)
                                {

                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.HalfDollar, 1);
                                        halfdollarCount += 1;

                                    }
                                    denominationAmount.Append($"{count} HalfDollars.\n");
                                    InvokePropertyChanged("HalfDollars");
                                }
                                else if (drawer.HalfDollars <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                                
                            }
                            break;
                        case "Quarter":
                            try
                            {
                                if (drawer.Quarters > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Quarter, 1);
                                        quarterCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Quarters.\n");
                                    InvokePropertyChanged("Quarters");





                                }
                                else if (drawer.Quarters <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }
                                
                            }
                            catch (DrawerOverdrawException)
                            {
                                
                                registerFailure = true;
                               
                            }

                            break;
                        case "Dime":
                            try
                            {
                                if (drawer.Dimes > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Dime, 1);
                                        dimeCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Dimes.\n");
                                    InvokePropertyChanged("Dimes");





                                }
                                else if (drawer.Dimes <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }

                            break;
                        case "Nickel":
                            try
                            {
                                if (drawer.Nickels > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Nickel, 1);
                                        nickelCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Nickels.\n");
                                    InvokePropertyChanged("Nickels");





                                }
                                else if (drawer.Nickels <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }

                            break;
                        case "Penny":
                            try
                            {
                                if (drawer.Pennies > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Penny, 1);
                                        pennyCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Pennies.\n");
                                    InvokePropertyChanged("Pennies");





                                }
                                else if (drawer.Pennies <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;
                                
                            }

                            break;
                        default:
                            
                            break;
                    }



                }
                else if(registerFailure)
                {
                    drawer.AddCoin(Coins.Dime, dimeCount);
                    drawer.AddCoin(Coins.Penny, pennyCount);
                    drawer.AddCoin(Coins.Quarter, quarterCount);
                    drawer.AddCoin(Coins.HalfDollar, halfdollarCount);
                    drawer.AddCoin(Coins.Dollar, dollarCount);
                    drawer.AddCoin(Coins.Nickel, nickelCount);
                    drawer.AddBill(Bills.Fifty, fiftyCount);
                    drawer.AddBill(Bills.Hundred, hundredCount);
                    drawer.AddBill(Bills.Twenty, twentyCount);
                    drawer.AddBill(Bills.Ten, tenCount);
                    drawer.AddBill(Bills.Five, fiveCount);
                    drawer.AddBill(Bills.Two, twoCount);
                    drawer.AddBill(Bills.One, oneCount);
                    dimeCount = 0;
                    pennyCount = 0;
                    quarterCount = 0;
                    halfdollarCount = 0;
                    dollarCount = 0;
                    nickelCount = 0;
                    fiftyCount = 0;
                    hundredCount = 0;
                    twentyCount = 0;
                    tenCount = 0;
                    fiveCount = 0;
                    twoCount = 0;
                    oneCount = 0;
                    InvokeOnAllDenominations();
                    break;
                }
                
                

            }
        }
        /// <summary>
        /// This method will return the cash to the user on a transaction failure.
        /// </summary>
        /// <param name="totalPaid">Total cash paid by customer</param>
        public void ResetCash(double totalPaid)
        {

            var change = totalPaid;

            var denominations = new[]
            {
                new {denom = "Hundred", val=100.00},
                new {denom = "Fifty", val=50.00},
                new {denom = "Twenty", val=25.00},
                new {denom = "Ten", val=10.00},
                new {denom = "Five", val=5.00},
                new {denom = "Two", val=2.00},
                new {denom = "One", val=1.00},
                new {denom = "Dollar", val=1.00},
                new {denom = "HalfDollar", val=0.50},
                new {denom = "Quarter", val=0.25},
                new {denom = "Dime", val=0.10},
                new {denom = "Nickel", val=0.05},
                new {denom = "Penny", val=0.01}

            };


            foreach (var item in denominations)
            {

                int count = (int)(change / item.val);
                change -= Math.Round((count * item.val), 2);
                change = Math.Round(change, 2);

                if (count > 0)
                {
                    switch (item.denom)
                    {
                        case "Hundred":
                            try
                            {
                                if (drawer.Hundreds > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Hundred, 1);

                                        hundredCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Hundreds.\n");
                                    InvokePropertyChanged("Hundreds");






                                }
                                else if (drawer.Hundreds <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }
                            break;
                        case "Fifty":
                            try
                            {
                                if (drawer.Fifties > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Fifty, 1);

                                        fiftyCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Fifties.\n");
                                    InvokePropertyChanged("Fifties");






                                }
                                else if (drawer.Fifties <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }

                            break;
                        case "Twenty":
                            try
                            {
                                if (drawer.Twenties > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Twenty, 1);

                                        twentyCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Twenties.\n");
                                    InvokePropertyChanged("Twenties");






                                }
                                else if (drawer.Twenties <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }
                            break;
                        case "Ten":

                            try
                            {
                                if (drawer.Tens > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Ten, 1);

                                        tenCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Tens.\n");
                                    InvokePropertyChanged("Tens");






                                }
                                else if (drawer.Twos <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }
                            break;
                        case "Five":
                            try
                            {
                                if (drawer.Fives > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Five, 1);

                                        fiveCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Fives.\n");
                                    InvokePropertyChanged("Fives");





                                }
                                else if (drawer.Fives <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }
                            break;
                        case "Two":
                            try
                            {
                                if (drawer.Twos > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.Two, 1);
                                        twoCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Twos.\n");
                                    InvokePropertyChanged("Twos");





                                }
                                else if (drawer.Twos <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {
                                registerFailure = true;

                            }
                            break;
                        case "One":
                            try
                            {
                                if (drawer.Dimes > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveBill(Bills.One, 1);
                                        oneCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Ones.\n");
                                    InvokePropertyChanged("Ones");


                                }
                                else if (drawer.Ones <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }
                            break;
                        case "Dollar":
                            try
                            {
                                if (drawer.Dollars > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Dollar, 1);
                                        dollarCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Dollars.\n");
                                    InvokePropertyChanged("Dollars");






                                }
                                else if (drawer.Dimes <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }

                            break;
                        case "HalfDollar":
                            try
                            {
                                if (drawer.HalfDollars > 0)
                                {

                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.HalfDollar, 1);
                                        halfdollarCount += 1;

                                    }
                                    denominationAmount.Append($"{count} HalfDollars.\n");
                                    InvokePropertyChanged("HalfDollars");
                                }
                                else if (drawer.HalfDollars <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }
                            break;
                        case "Quarter":
                            try
                            {
                                if (drawer.Quarters > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Quarter, 1);
                                        quarterCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Quarters.\n");
                                    InvokePropertyChanged("Quarters");





                                }
                                else if (drawer.Quarters <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }

                            break;
                        case "Dime":
                            try
                            {
                                if (drawer.Dimes > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Dime, 1);
                                        dimeCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Dimes.\n");
                                    InvokePropertyChanged("Dimes");





                                }
                                else if (drawer.Dimes <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }

                            break;
                        case "Nickel":
                            try
                            {
                                if (drawer.Nickels > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Nickel, 1);
                                        nickelCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Nickels.\n");
                                    InvokePropertyChanged("Nickels");





                                }
                                else if (drawer.Nickels <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }

                            break;
                        case "Penny":
                            try
                            {
                                if (drawer.Pennies > 0)
                                {



                                    for (int i = 0; i < count; i++)
                                    {
                                        drawer.RemoveCoin(Coins.Penny, 1);
                                        pennyCount += 1;

                                    }
                                    denominationAmount.Append($"{count} Pennies.\n");
                                    InvokePropertyChanged("Pennies");





                                }
                                else if (drawer.Pennies <= 0)
                                {
                                    change += Math.Round(count * item.val, 2);

                                }

                            }
                            catch (DrawerOverdrawException)
                            {

                                registerFailure = true;

                            }

                            break;
                        default:

                            break;
                    }



                }
            }
        }




        /// <summary>
        /// Invokes property changed on given denomination and total value
        /// </summary>
        /// <param name="denomination">Coin/Bill denomination</param>
        private void InvokePropertyChanged(string denomination)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(denomination));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalValue"));
        }

        /// <summary>
        /// Invokes property changed on all coin and bill denominations.
        /// </summary>
        private void InvokeOnAllDenominations()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pennies"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nickels"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dimes"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Quarters"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HalfDollars"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollars"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ones"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Twos"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fives"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tens"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Twenties"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fifties"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hundreds"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalValue"));
        }
    }
}

