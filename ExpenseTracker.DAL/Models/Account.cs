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
    public class Account : BaseEntity
    {

        

        public  string Name { get; set; }

        public  decimal Balance { get; set; }

        


        
        public  string Type { get; set; }


        public virtual ICollection<Income> Incomes { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }

        public virtual ICollection<Transfer> Transfers { get; set; }


        public virtual ICollection<Budget> Budgets { get; set; }




    }
}
