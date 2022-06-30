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
    /// Interaction logic for HomeLoan.xaml
    /// </summary>
    public partial class HomeLoan : Page
    {
        HomeLoans hl = new HomeLoans();
        public HomeLoan()
        {
            InitializeComponent();
            //hl.price = 0;
            //hl.deposit = 0;
            //hl.interestRate = 0;
            //hl.repayMonths = 0;

            //this.DataContext = hl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hl.price = Convert.ToDouble(price.Text);
            hl.deposit = Convert.ToDouble(deposit.Text);
            hl.interestRate = Convert.ToDouble(interestRate.Text);
            hl.repayMonths = Convert.ToDouble(months.Text);

            StreamWriter sw = File.AppendText(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt");
            sw.WriteLine(hl.price);
            sw.WriteLine(hl.deposit);
            sw.WriteLine(hl.interestRate);
            sw.WriteLine(hl.repayMonths);
            //Close the file
            sw.Close();

            MessageBox.Show("Values have been entered" +
                "\nIf you are buying a car please select the car icon" +
                "\nIf not select the savings icon");
        }
    }
}
