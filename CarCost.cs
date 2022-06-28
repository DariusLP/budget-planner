using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV3
{
    internal class CarCost
    {
        public string makeAndModel { get; set; }
        public double price { get; set; }
        public double deposit { get; set; }
        public double interestRate { get; set; }
        public double insurancePremium { get; set; }

    }
}
