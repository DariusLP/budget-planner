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
    /// Interaction logic for Savings.xaml
    /// </summary>
    public partial class Savings : Page
    {
        Saving s = new Saving();
        public Savings()
        {
            InitializeComponent();
            //s.savingAmount = 0;
            //s.sd = "";
            //s.reasonForSaving = "";
            //s.savingInterestRate = 0;

            //this.DataContext = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            s.savingAmount = Convert.ToDouble(AmountToSave.Text);
            s.sd = DateToSaveTill.Text;
            s.reasonForSaving = Reason.Text;
            s.savingInterestRate = Convert.ToDouble(interestRate.Text);

            MessageBox.Show("Values have been entered");
        }
    }
}
