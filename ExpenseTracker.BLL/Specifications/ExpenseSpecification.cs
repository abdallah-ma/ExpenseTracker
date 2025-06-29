using ExpenseTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.BLL.Specifications
{
    public class ExpenseSpecification : BaseSpecifications<Expense>
    {
        public ExpenseSpecification(Expression<Func<Expense, bool>> Criteria) 
            : 
            base()
        {

        }
     
        

    }
    
}
