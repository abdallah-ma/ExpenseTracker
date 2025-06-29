using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.PL.ViewModels
{
    public class TransferViewModel
    {

        [Required]
        public string SourceAccountName { get; set; }
        [Required]

        public string RecipientAccountName { get; set; }
        [Required]

        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

    }
}
