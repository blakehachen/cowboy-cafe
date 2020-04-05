using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using CashRegister;

namespace PointOfSale
{
    public class CashRegisterModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public static CashDrawer drawer = new CashDrawer();

        /// <summary>
        /// Gets total cash in drawer
        /// </summary>
        public double TotalValue => drawer.TotalValue;


        private double totalCash;
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

        public int Quarters
        {
            get => drawer.Quarters;
            set
            {
                if (drawer.Quarters == value || value < 0) return;
                var quantity = value - drawer.Quarters;
                if (quantity > 0) drawer.AddCoin(Coins.Quarter, quantity);
                else drawer.RemoveCoin(Coins.Quarter, -quantity);
                InvokePropertyChanged("Quarters");
            }
        }

        public int HalfDollars
        {
            get => drawer.HalfDollars;
            set
            {
                if (drawer.HalfDollars == value || value < 0) return;
                var quantity = value - drawer.HalfDollars;
                if (quantity > 0) drawer.AddCoin(Coins.HalfDollar, quantity);
                else drawer.RemoveCoin(Coins.HalfDollar, -quantity);
                InvokePropertyChanged("HalfDollars");
            }
        }

        public int Dollars
        {
            get => drawer.Dollars;
            set
            {
                if (drawer.Dollars == value || value < 0) return;
                var quantity = value - drawer.Dollars;
                if (quantity > 0) drawer.AddCoin(Coins.Dollar, quantity);
                else drawer.RemoveCoin(Coins.Dollar, -quantity);
                InvokePropertyChanged("HalfDollars");
            }
        }

        public int Ones
        {
            get => drawer.Ones;
            set
            {
                if (drawer.Ones == value || value < 0) return;
                var quantity = drawer.Ones - value;
                if (quantity > 0) drawer.RemoveBill(Bills.One, quantity);
                else drawer.AddBill(Bills.One, -quantity);
                InvokePropertyChanged("Ones");
            }
        }

        public int Twos
        {
            get => drawer.Twos;
            set
            {
                if (drawer.Twos == value || value < 0) return;
                var quantity = drawer.Twos - value;
                if (quantity > 0) drawer.RemoveBill(Bills.Two, quantity);
                else drawer.AddBill(Bills.Two, -quantity);
                InvokePropertyChanged("Twos");
            }
        }

        public int Fives
        {
            get => drawer.Fives;
            set
            {
                if (drawer.Fives == value || value < 0) return;
                var quantity = drawer.Fives - value;
                if (quantity > 0) drawer.RemoveBill(Bills.Five, quantity);
                else drawer.AddBill(Bills.Five, -quantity);
                InvokePropertyChanged("Fives");
            }
        }

        public int Tens
        {
            get => drawer.Tens;
            set
            {
                if (drawer.Tens == value || value < 0) return;
                var quantity = drawer.Tens - value;
                if (quantity > 0) drawer.RemoveBill(Bills.Ten, quantity);
                else drawer.AddBill(Bills.Ten, -quantity);
                InvokePropertyChanged("Tens");
            }
        }

        public int Twenties
        {
            get => drawer.Twenties;
            set
            {
                if (drawer.Twenties == value || value < 0) return;
                var quantity = drawer.Twenties - value;
                if (quantity > 0) drawer.RemoveBill(Bills.Twenty, quantity);
                else drawer.AddBill(Bills.Twenty, -quantity);
                InvokePropertyChanged("Twenties");
            }
        }

        public int Fifties
        {
            get => drawer.Fifties;
            set
            {
                if (drawer.Fifties == value || value < 0) return;
                var quantity = drawer.Fifties - value;
                if (quantity > 0) drawer.RemoveBill(Bills.Fifty, quantity);
                else drawer.AddBill(Bills.Fifty, -quantity);
                InvokePropertyChanged("Fifties");
            }
        }

        public int Hundreds
        {
            get => drawer.Hundreds;
            set
            {
                if (drawer.Hundreds == value || value < 0) return;
                var quantity = drawer.Hundreds - value;
                if (quantity > 0) drawer.RemoveBill(Bills.Hundred, quantity);
                else drawer.AddBill(Bills.Hundred, -quantity);
                InvokePropertyChanged("Hundreds");
            }
        }



        private void InvokePropertyChanged(string denomination)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(denomination));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalValue"));
        }
    }
}

