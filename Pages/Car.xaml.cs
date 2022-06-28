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
    /// Interaction logic for Car.xaml
    /// </summary>
    public partial class Car : Page
    {
        Cars c = new Cars();
        public Car()
        {
            InitializeComponent();
            
            //c.makeAndModel = "";
            //c.purchasePrice = 0;
            //c.carInterestRate = 0;
            //c.carInsurancePremium = 0;
            //c.carDeposit = 0;

            //this.DataContext = c;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            c.makeAndModel = Make.Text;
            c.purchasePrice = Convert.ToDouble(price.Text); ;
            c.carInterestRate = Convert.ToDouble(interestRate.Text);
            c.carInsurancePremium = Convert.ToDouble(InsurancePrem.Text);
            c.carDeposit = Convert.ToDouble(Deposit.Text);

            MessageBox.Show("Values have been saved" +
                "\nIf you are making a savings plan, select the Savings icon" +
                "\nIf not select the results icon");
        }
    }
}
