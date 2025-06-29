using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DAL.Models
{
    public class Income : BaseEntity
    {

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string AccountName { get; set; }

    }
}
