using ExpenseTracker.DAL.Models;
using ExpenseTracker.PL.Helpers;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ExpenseTracker.PL.ViewModels
{
    public class BudgetViewModel
    {

        public string Name { get; set; }

        public string Period { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        
        public DateTime? EndDate { get; set; }

        public decimal CurrentAmount { get; set; }

        public decimal Limit { get; set; }

       

        public string Category { get; set; }

        public ICollection<int> Accounts { get; set; } 

    }
}
