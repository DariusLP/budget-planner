using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV3
{
    internal class Expense
    {
        public double grossMonthlyIncome { get; set; }
        public double monthlyTax { get; set; }
        public double groceriesCost { get; set; }
        public double waterAndLightsCost { get; set; }
        public double travelCost { get; set; }
        public double phoneCost { get; set; }
        public double otherCost { get; set; }
    }
}
