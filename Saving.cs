using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV3
{
    internal class Saving
    {
        public double savingAmount { get; set; }
        public DateTime savingDate;
        public string sd
        {
            get { return savingDate.ToString(); }
            set { DateTime.TryParse(value, out savingDate); }
        }
        public string reasonForSaving { get; set; }
        public double savingInterestRate { get; set; }
    }
}
