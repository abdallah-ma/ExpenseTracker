using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.PL.ViewModels
{
    public class ExpenseViewModel
    {

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }


        [Required]
        public string Category { get; set; }

        [Required]
        public string AccountName { get; set; }


    }
}
