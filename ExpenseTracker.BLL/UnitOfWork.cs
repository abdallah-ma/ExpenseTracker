using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.DAL.Data;
using ExpenseTracker.DAL.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.BLL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.BLL{

    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository AccountRepository { get; }
        public BudgetRepository BudgetRepository { get; }
        public TransferRepository TransferRepository { get; }
        public IncomeRepository IncomeRepository { get; }
        public ExpenseRepository ExpenseRepository { get; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            AccountRepository = new AccountRepository(_dbContext);
            BudgetRepository = new BudgetRepository(_dbContext);
            TransferRepository = new TransferRepository(_dbContext);
            IncomeRepository = new IncomeRepository(_dbContext);
            ExpenseRepository = new ExpenseRepository(_dbContext);
        }

        public Task<int> CompleteAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }



    }
}
