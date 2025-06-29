using ExpenseTracker.BLL.Repositories;
using ExpenseTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.BLL.Interfaces
{
    public interface IUnitOfWork
    {

        AccountRepository AccountRepository { get; }
        BudgetRepository BudgetRepository { get; }
        TransferRepository TransferRepository { get; }
        IncomeRepository IncomeRepository { get; }
        ExpenseRepository ExpenseRepository { get; }
        

        public Task<int> CompleteAsync();

        
        

    }
}
