using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DAL.Models
{
    public class Transfer : BaseEntity
    {

        


        [Required]
        [DisplayName("Source Account")]
        public string SourceAccountName { get; set; }

        

        [Required]
        [DisplayName("Recipient Account")]
        public string RecipientAccountName { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        
    }
}
