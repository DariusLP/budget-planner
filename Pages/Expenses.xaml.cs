using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

namespace BudgetPlannerV3.Pages
{
    /// <summary>
    /// Interaction logic for Expenses.xaml
    /// </summary>
    public partial class Expenses : Page
    {
        Expense ex = new Expense();
        public Expenses()
        {
            InitializeComponent();
            //ex.grossMonthlyIncome = 0;
            //ex.monthlyTax = 0;
            //ex.groceriesCost = 0;
            //ex.waterAndLightsCost = 0;
            //ex.travelCost = 0;
            //ex.phoneCost = 0;
            //ex.otherCost = 0;

            //this.DataContext = ex;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ex.grossMonthlyIncome = Convert.ToDouble(mntlyInc.Text);
            ex.monthlyTax = Convert.ToDouble(mnthyTax.Text);
            ex.groceriesCost = Convert.ToDouble(groceries.Text);
            ex.waterAndLightsCost = Convert.ToDouble(waterlights.Text);
            ex.travelCost = Convert.ToDouble(travel.Text);
            ex.phoneCost = Convert.ToDouble(phone.Text);
            ex.otherCost = Convert.ToDouble(otherCosts.Text);

            StreamWriter sw = new StreamWriter(@"C:\Users\dariu\OneDrive\Desktop\PROG6221\POE\BudgetPlannerV3\Values.txt");
            sw.WriteLine(ex.grossMonthlyIncome);
            sw.WriteLine(ex.monthlyTax);
            sw.WriteLine(ex.groceriesCost);
            sw.WriteLine(ex.waterAndLightsCost);
            sw.WriteLine(ex.travelCost);
            sw.WriteLine(ex.phoneCost);
            sw.WriteLine(ex.otherCost);
            //Close the file
            sw.Close();

            MessageBox.Show("Values have been entered" +
                "\nPlease choose in the menu whether you are renting or buying a home" +
                "\nOnce chosen this option cannot be changed!");
        }
    }
}
