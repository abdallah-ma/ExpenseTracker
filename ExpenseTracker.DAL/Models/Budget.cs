using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExpenseTracker.DAL.Models
{
    public class Budget : BaseEntity
    {

        

        public string Name { get; set; }

        public string Period { get; set; }

        [DisplayName("Start Date")]
        
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
    
        public DateTime EndDate { get; set; }

        public decimal Limit { get; set; }


        public decimal? CurrentAmount { get; set; }



        public string Category { get; set; }


        public virtual ICollection<Account> Accounts { get; set; }

    }
}
