﻿using ExpenseTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.BLL.Interfaces
{
    public interface ISpecification<T> where T : BaseEntity
    {

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
