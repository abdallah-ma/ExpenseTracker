using ExpenseTracker.BLL.Repository;
using ExpenseTracker.DAL.Data;
using ExpenseTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.BLL.Repositories
{
    public class IncomeRepository : GenericRepository<Income>
    {

        public IncomeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task AddAsync(Income income)
        {
            var Account = await _dbContext.Accounts.FirstOrDefaultAsync(A => A.Name ==income.AccountName);

            if (Account is null) return;

            Account.Balance += income.Amount;

            _dbContext.Update(Account);

            await _dbContext.Incomes.AddAsync(income);
        }

        public override async Task DeleteAsync(Income income)
        {
            var Account = await _dbContext.Accounts.FirstOrDefaultAsync(A => A.Name == income.AccountName);
            if (Account is null) return;


            Account.Balance -= income.Amount;
            _dbContext.Update(Account);
            _dbContext.Incomes.Remove(income);

            await Task.CompletedTask;
        }

        public override async Task UpdateAsync(Income income)
        {
            var existingIncome = await _dbContext.Incomes.FindAsync(income.Id);

            if (existingIncome == null) return;

            var Account = await _dbContext.Accounts.FirstOrDefaultAsync(A => A.Name == existingIncome.AccountName);


            if (Account is null) return;

            Account.Balance += income.Amount - existingIncome.Amount;


            _dbContext.Update(Account);
            existingIncome.Amount = income.Amount;
            existingIncome.Date = income.Date;
            existingIncome.AccountName = income.AccountName;

            await Task.CompletedTask;

        }
    }
}
