using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DAL.Models
{
    public class Expense : BaseEntity

    {


        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }


        [Required]
        public string Category { get; set; }

        [Required]
        [DisplayName("Account")]
        public string AccountName { get; set; }


    }
}
