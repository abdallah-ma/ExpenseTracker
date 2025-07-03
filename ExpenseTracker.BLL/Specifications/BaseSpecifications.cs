using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.BLL.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T> where T : BaseEntity
    {
        
        public Expression<Func<T, bool>> Criteria { get; set; }

        
        public List<  Expression<Func<T, object>>  > Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set;}
        public void ApplyPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }

        public BaseSpecifications()
        {
        }

        public BaseSpecifications(Expression<Func<T, bool>>  criteria)
        {
            Criteria = criteria;
        }

    }
}
