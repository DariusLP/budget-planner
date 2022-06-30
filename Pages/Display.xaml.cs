using System;
using System.Collections.Generic;
using System.IO;
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

        public Display()
        {
            InitializeComponent();
            
        }



        public string notifyUser(double totExp, double house, double car, double income)
        {
            double totalOwed;
            string alertMes = "";

            //some of expenses excluding tax
            totalOwed = totExp + house + car;
            try
            {
                if (totalOwed >= (income * 0.75))
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

        public double totalExpense(double tax, double groceries, double waterAndLights, double travel, double phone, double other)
        {
            double total = tax +  groceries + waterAndLights + travel + phone + other;
            return total;
        }



        public double calcCarMonthlyCost(double interestRate, double purchasePrice, double deposit, double insurancePremium)
        {
            try
            {
                double cost = 0;
                double monthlyCost = 0;

                double principleAmount = purchasePrice - deposit;   //calc amount due
                interestRate = interestRate / 100;  //get interest rate to right format (7,5% = 0.075 ) 

                cost = principleAmount * (1 + (interestRate * 5));   //uses A = P(1 + (i * n)) formula
                monthlyCost = cost / 60; //gets monthly cost
                monthlyCost += insurancePremium;   //adds insurance premium cost to monthly costs

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
            double principleAmount = price - deposit;  //calcs amount due
            interestRate = interestRate / 100;  //changes format of percentage for calc (7,5% --> 0,075)
            double years = repayMonths / 12;   //calcs years to repay

            double totalOwed = principleAmount * (1 + (interestRate * years)); //full calc using formula

            double homeLoanRepayments = totalOwed / repayMonths;           //calc for monthly repayment
            homeLoanRepayments = Math.Round(homeLoanRepayments, 2);  //round off to 2 decimals

            //return monthly repayments
            return homeLoanRepayments;
        }

        public string checkApprovalLikeliness(double income, double homeLoanPrice, double homeLoanDeposit, double homeLoanInterestRate, double homeLoanRepayMonth)
        {
            double payments = monthlyHomeloanRepayments(homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);

            string approval = "";
            try
            {
                if ((income / 3) < payments)
                {
                    approval = "ALERT: It is unlikely that this home loan will be approved!";
                }
                return approval;
            }

            catch (Exception)
            {
                throw;
            }

        }

        public double savingsCalc(double savingAmount, double savingInterestRate, double months)
        {
            //calculation using formula: A = P(1 + (i * n))
            savingInterestRate = savingInterestRate / 100;  //changes format of percentage for calc (7,5% --> 0,075)
            double years = months / 12;           //calcs years to repay

            double totalOwed = savingAmount * (1 + (savingInterestRate * years)); //full calc using formula

            double monthlySavingPayments = totalOwed / months;           //calc for monthly payment
            monthlySavingPayments = Math.Round(monthlySavingPayments, 2);  //round off to 2 decimals

            //return monthly payments
            return monthlySavingPayments;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //counts number of lines in textfile
            var lineCount = File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Count();

            //do calculations according to number of lines in the textfile
            
            //expenses with rent, car and savings
            if (lineCount.Equals(14))
            {
                double income = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Take(1).First());
                double tax = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(1).Take(1).First());
                double grocery = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(2).Take(1).First());
                double waterAndLights = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(3).Take(1).First());
                double travel = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(4).Take(1).First());
                double phone = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(5).Take(1).First());
                double other = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(6).Take(1).First());
                double rent = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(7).Take(1).First());
                string makeAndModel = (File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(8).Take(1).First());
                double carPurchasePrice = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(9).Take(1).First());
                double carDeposit = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(10).Take(1).First());
                double carInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(11).Take(1).First());
                double carInsurancePremium = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(12).Take(1).First());
                double savingAmount = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(13).Take(1).First());
                double dateToSaveTill = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(14).Take(1).First());
                string savingReason = File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(15).Take(1).First();
                double savingInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(16).Take(1).First());

                double total = totalExpense(tax, grocery, waterAndLights, travel, phone, other);
                double carCost = calcCarMonthlyCost(carInterestRate, carPurchasePrice, carDeposit, carInsurancePremium);
                double monthlySaving = savingsCalc(savingAmount, savingInterestRate, dateToSaveTill);

                tExp1.Text = "Monthly Expenses: \tR" + total;
                tExp2.Text = "Rent Expenses: \tR" + rent;
                tExp3.Text = "Car Expenses for your " + makeAndModel + ": \tR" + carCost;
                tExp4.Text = "To save for " + savingReason + " you will need to save R" + monthlySaving + "for " + dateToSaveTill + " month(s)";
                tExp5.Text = notifyUser(total, rent, carCost, income);

            }

            //expenses with rent and car
            if (lineCount.Equals(13))
            {
                double income = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Take(1).First());
                double tax = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(1).Take(1).First());
                double grocery = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(2).Take(1).First());
                double waterAndLights = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(3).Take(1).First());
                double travel = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(4).Take(1).First());
                double phone = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(5).Take(1).First());
                double other = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(6).Take(1).First());
                double rent = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(7).Take(1).First());
                string makeAndModel = (File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(8).Take(1).First());
                double carPurchasePrice = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(9).Take(1).First());
                double carDeposit = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(10).Take(1).First());
                double carInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(11).Take(1).First());
                double carInsurancePremium = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(12).Take(1).First());

                double total = totalExpense(tax, grocery, waterAndLights, travel, phone, other);
                double carCost = calcCarMonthlyCost(carInterestRate, carPurchasePrice, carDeposit, carInsurancePremium);

                tExp1.Text = "Monthly Expenses: \tR" + total;
                tExp2.Text = "Rent Expenses: \t" + rent;
                tExp3.Text = "Car Expenses for your " + makeAndModel + ": \tR" + carCost;
                tExp4.Text = notifyUser(total, rent, carCost, income);
            }

            //expenses with rent and savings
            if (lineCount.Equals(12))
            {
                double income = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Take(1).First());
                double tax = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(1).Take(1).First());
                double grocery = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(2).Take(1).First());
                double waterAndLights = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(3).Take(1).First());
                double travel = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(4).Take(1).First());
                double phone = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(5).Take(1).First());
                double other = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(6).Take(1).First());
                double rent = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(7).Take(1).First());
                double savingAmount = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(8).Take(1).First());
                double dateToSaveTill = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(9).Take(1).First());
                string savingReason = File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(10).Take(1).First();
                double savingInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(11).Take(1).First());

                double val = 0;
                double total = totalExpense(tax, grocery, waterAndLights, travel, phone, other);
                double monthlySaving = savingsCalc(savingAmount, savingInterestRate, dateToSaveTill);

                tExp1.Text = "Monthly Expenses: \tR" + total;
                tExp2.Text = "Rent Expenses: \tR" + rent;
                tExp3.Text = "To save for " + savingReason + " you will need to save R" + monthlySaving + "for " + dateToSaveTill + " month(s)";
                tExp4.Text = notifyUser(total, rent, val, income);

            }

            //expenses with rent
            if (lineCount.Equals(8))
            {
                double income = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Take(1).First());
                double tax = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(1).Take(1).First());
                double grocery = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(2).Take(1).First());
                double waterAndLights = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(3).Take(1).First());
                double travel = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(4).Take(1).First());
                double phone = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(5).Take(1).First());
                double other = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(6).Take(1).First());
                double rent = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(7).Take(1).First());

                double total = totalExpense(tax, grocery, waterAndLights, travel, phone, other);
                double val = 0;

                tExp1.Text = "Monthly Expenses: \tR" + total;
                tExp2.Text = "Rent expenses: \tR" + rent;
                tExp3.Text = notifyUser(total, rent, val, income);

            }

            //expenses with home loan, car and savings
            if (lineCount.Equals(20))
            {
                double income = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Take(1).First());
                double tax = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(1).Take(1).First());
                double grocery = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(2).Take(1).First());
                double waterAndLights = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(3).Take(1).First());
                double travel = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(4).Take(1).First());
                double phone = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(5).Take(1).First());
                double other = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(6).Take(1).First());
                double homeLoanPrice = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(7).Take(1).First());
                double homeLoanDeposit = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(8).Take(1).First());
                double homeLoanInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(9).Take(1).First());
                double homeLoanRepayMonth = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(10).Take(1).First());
                string makeAndModel = (File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(11).Take(1).First());
                double carPurchasePrice = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(12).Take(1).First());
                double carDeposit = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(13).Take(1).First());
                double carInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(14).Take(1).First());
                double carInsurancePremium = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(15).Take(1).First());
                double savingAmount = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(16).Take(1).First());
                double dateToSaveTill = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(17).Take(1).First());
                string savingReason = File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(18).Take(1).First();
                double savingInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(19).Take(1).First());

                double total = totalExpense(tax, grocery, waterAndLights, travel, phone, other);
                double carCost = calcCarMonthlyCost(carInterestRate, carPurchasePrice, carDeposit, carInsurancePremium);
                double loanPayments = monthlyHomeloanRepayments(homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);
                double monthlySaving = savingsCalc(savingAmount, savingInterestRate, dateToSaveTill);

                tExp1.Text = "Monthly Expenses: \tR" + total;
                tExp2.Text = "Home Loan expenses: \tR" + loanPayments;
                tExp3.Text = checkApprovalLikeliness(income, homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);
                tExp4.Text = "Car Expenses for your " + makeAndModel + ": \tR" + carCost;
                tExp5.Text = "To save for " + savingReason + " you will need to save R" + monthlySaving + "for " + dateToSaveTill + " month(s)";
                tExp6.Text = notifyUser(totalExpense(tax, grocery, waterAndLights, travel, phone, other), loanPayments, carCost, income);
            }

            //Expenses with home loan and car
            if (lineCount.Equals(16))
            {
                double income = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Take(1).First());
                double tax = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(1).Take(1).First());
                double grocery = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(2).Take(1).First());
                double waterAndLights = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(3).Take(1).First());
                double travel = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(4).Take(1).First());
                double phone = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(5).Take(1).First());
                double other = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(6).Take(1).First());
                double homeLoanPrice = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(7).Take(1).First());
                double homeLoanDeposit = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(8).Take(1).First());
                double homeLoanInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(9).Take(1).First());
                double homeLoanRepayMonth = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(10).Take(1).First());
                string makeAndModel = File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(11).Take(1).First();
                double carPurchasePrice = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(12).Take(1).First());
                double carDeposit = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(13).Take(1).First());
                double carInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(14).Take(1).First());
                double carInsurancePremium = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(15).Take(1).First());

                double total = totalExpense(tax, grocery, waterAndLights, travel, phone, other);
                double loanPayments = monthlyHomeloanRepayments(homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);
                double carCost = calcCarMonthlyCost(carInterestRate, carPurchasePrice, carDeposit, carInsurancePremium);

                tExp1.Text = "Monthly Expenses: \tR" + total;
                tExp2.Text = "Home Loan expenses: \tR" + loanPayments;
                tExp3.Text = "Car Expenses for your " + makeAndModel + ": \tR" + carCost;
                tExp4.Text = checkApprovalLikeliness(income, homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);
                tExp5.Text = notifyUser(totalExpense(tax, grocery, waterAndLights, travel, phone, other), loanPayments, carCost, income);
            }

            //expenses with home loan and savings
            if (lineCount.Equals(15))
            {
                double income = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Take(1).First());
                double tax = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(1).Take(1).First());
                double grocery = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(2).Take(1).First());
                double waterAndLights = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(3).Take(1).First());
                double travel = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(4).Take(1).First());
                double phone = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(5).Take(1).First());
                double other = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(6).Take(1).First());
                double homeLoanPrice = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(7).Take(1).First());
                double homeLoanDeposit = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(8).Take(1).First());
                double homeLoanInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(9).Take(1).First());
                double homeLoanRepayMonth = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(10).Take(1).First());
                double savingAmount = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(11).Take(1).First());
                double dateToSaveTill = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(12).Take(1).First());
                string savingReason = File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(13).Take(1).First();
                double savingInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(14).Take(1).First());

                double total = totalExpense(tax, grocery, waterAndLights, travel, phone, other);
                double loanPayments = monthlyHomeloanRepayments(homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);
                double monthlySaving = savingsCalc(savingAmount, savingInterestRate, dateToSaveTill);
                double val = 0;

                tExp1.Text = "Monthly Expenses: \tR" + total;
                tExp2.Text = "Home Loan expenses: \tR" + loanPayments;
                tExp3.Text = checkApprovalLikeliness(income, homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);
                tExp4.Text = "To save for " + savingReason + " you will need to save R" + monthlySaving + "for " + dateToSaveTill + " month(s)";
                tExp5.Text = notifyUser(totalExpense(tax, grocery, waterAndLights, travel, phone, other), loanPayments, val, income);
            }

            //expenses with home loan
            if (lineCount.Equals(11))
            {
                double income = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Take(1).First());
                double tax = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(1).Take(1).First());
                double grocery = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(2).Take(1).First());
                double waterAndLights = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(3).Take(1).First());
                double travel = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(4).Take(1).First());
                double phone = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(5).Take(1).First());
                double other = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(6).Take(1).First());
                double homeLoanPrice = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(7).Take(1).First());
                double homeLoanDeposit = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(8).Take(1).First());
                double homeLoanInterestRate = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(9).Take(1).First());
                double homeLoanRepayMonth = Convert.ToDouble(File.ReadLines(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt").Skip(10).Take(1).First());

                double total = totalExpense(tax, grocery, waterAndLights, travel, phone, other);
                double loanPayments = monthlyHomeloanRepayments(homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);
                double val = 0;

                tExp1.Text = "Monthly Expenses: \tR" + total;
                tExp2.Text = "Home Loan expenses: \tR" + loanPayments;
                tExp3.Text = checkApprovalLikeliness(income, homeLoanPrice, homeLoanDeposit, homeLoanInterestRate, homeLoanRepayMonth);
                tExp4.Text = notifyUser(totalExpense(tax, grocery, waterAndLights, travel, phone, other), loanPayments, val, income);
            }

        }
    }
}
