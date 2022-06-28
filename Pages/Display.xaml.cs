using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetPlannerV3.Pages
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Page
    {
        Expense e = new Expense();
        Cars c = new Cars();
        Rents r = new Rents();
        HomeLoans hl = new HomeLoans();
        Saving s = new Saving();

        public Display()
        {
            InitializeComponent();
            
            this.DataContext = e;
            this.DataContext = c;
            this.DataContext = r;
            this.DataContext = hl;
            this.DataContext = s;
        }

        public string notifyUser(double totExp, double house, double car, double gmi)
        {
            double totalOwed;
            string alertMes = "";

            //some of expenses excluding tax
            totalOwed = totExp + house + car;
            try
            {
                if (totalOwed >= (gmi * 0.75))
                {
                    alertMes = "ALERT: Your total expenses and loan repayments exceed 75% of your income!";
                    
                }
                return alertMes;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public double totalExpense()
        {
            double total = e.groceriesCost + e.waterAndLightsCost + e.travelCost + e.phoneCost + e.otherCost;
            return total;
        }



        public double calcCarMonthlyCost()
        {
            try
            {
                double cost = 0;
                double monthlyCost = 0;

                double principleAmount = c.purchasePrice - c.carDeposit;   //calc amount due
                c.carInterestRate = c.carInterestRate / 100;  //get interest rate to right format (7,5% = 0.075 ) 

                cost = principleAmount * (1 + (c.carInterestRate * 5));   //uses A = P(1 + (i * n)) formula
                monthlyCost = cost / 60; //gets monthly cost
                monthlyCost += c.carInsurancePremium;   //adds insurance premium cost to monthly costs

                return monthlyCost;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public double monthlyHomeloanRepayments(double price, double deposit, double interestRate, double repayMonths)
        {
            //calculation using formula: A = P(1 + (i * n))
            hl.principleAmount = price - deposit;  //calcs amount due
            interestRate = interestRate / 100;  //changes format of percentage for calc (7,5% --> 0,075)
            hl.years = repayMonths / 12;           //calcs years to repay

            double totalOwed = hl.principleAmount * (1 + (interestRate * hl.years)); //full calc using formula

            hl.homeLoanRepayments = totalOwed / repayMonths;           //calc for monthly repayment
            hl.homeLoanRepayments = Math.Round(hl.homeLoanRepayments, 2);  //round off to 2 decimals

            //return monthly repayments
            return hl.homeLoanRepayments;
        }

        public string checkApprovalLikeliness(double gmi)
        {
            string approval =""; 
            try
            {
                if ((gmi / 3) < hl.homeLoanRepayments)
                {
                    approval = "ALERT: It is unlikely that this home loan will be approved!";
                }
                return approval;
            }
            
            catch (Exception)
            {
                Console.WriteLine("An error occured when calculating the approvement of the loan");
                throw;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tExp1.Text = "Monthly Expenses: " + totalExpense()
                +"\nCar Expenses: " + calcCarMonthlyCost();
            if (r.rentAmount.Equals(0))
            {
                tExp2.Text = "Home Loan expenses: " + hl.homeLoanRepayments;
            }
            else
            {
                tExp2.Text = "Rent Expenses: " + r.rentAmount;
            }
            tExp3.Text = "After " + s.savingDate + " you will have saved " + s.savingAmount + "for " + s.reasonForSaving;

        }
    }
}
