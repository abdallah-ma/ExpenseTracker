using ExpenseTracker.BLL.Repository;
using ExpenseTracker.DAL.Data;
using ExpenseTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracker.BLL.Repositories
{
    public class ExpenseRepository : GenericRepository<Expense>
    {
        public ExpenseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public async override Task AddAsync(Expense expense)
        {

            var AffectedBudgets = await _dbContext.Budgets.Where(B => B.Category == expense.Category && B.Accounts.Any(A => A.Name == expense.AccountName))
                .ToListAsync();

            foreach (var budget in AffectedBudgets)
            {
                budget.CurrentAmount += expense.Amount;
            }

            _dbContext.UpdateRange(AffectedBudgets);
            await _dbContext.Expenses.AddAsync(expense);
        }

        public async override Task DeleteAsync(Expense expense)
        {

            var AffectedBudgets = await _dbContext.Budgets.Where(B => B.Category == expense.Category && B.Accounts.Any(A => A.Name == expense.AccountName))
                .ToListAsync();

            foreach (var budget in AffectedBudgets)
            {
                budget.CurrentAmount -= expense.Amount;
            }

            _dbContext.UpdateRange(AffectedBudgets);
             _dbContext.Expenses.Remove(expense);
            await Task.CompletedTask;
        }

        public async override Task UpdateAsync(Expense expense)
        {

            var OldAffectedBudgets = await _dbContext.Budgets.Where(B => B.Category == expense.Category && B.Accounts.Any(A => A.Name == expense.AccountName))
                .ToListAsync();

            foreach (var budget in OldAffectedBudgets)
            {
                budget.CurrentAmount -= expense.Amount;
            }

            var CurrentAffectedBudgets = await _dbContext.Budgets.Where(B => B.Category == expense.Category && B.Accounts.Any(A => A.Name == expense.AccountName))
                .ToListAsync();

            foreach (var budget in CurrentAffectedBudgets)
            {
                budget.CurrentAmount += expense.Amount;
            }

            _dbContext.Update(expense);

            await Task.CompletedTask;
        }




    }

}
