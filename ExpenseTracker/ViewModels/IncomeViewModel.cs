using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.PL.ViewModels
{
    public class IncomeViewModel
    {

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        
        public string AccountName { get; set; }


    }
}
