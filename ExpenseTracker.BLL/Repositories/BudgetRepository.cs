using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.BLL.Repository;
using ExpenseTracker.BLL.Specifications;
using ExpenseTracker.DAL.Data;
using ExpenseTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.BLL.Repositories
{
    public class BudgetRepository : GenericRepository<Budget>
    {


        public BudgetRepository(AppDbContext DbContext) : base(DbContext)
        {
            
        }


        public async override Task AddAsync(Budget budget)
        {



            foreach (var Account in budget.Accounts)
            {

                var Spec = new ExpenseSpecification(E => E.AccountName == Account.Name && E.Category == budget.Category);

                _dbContext.Entry(Account).State = EntityState.Unchanged;

                var Expenses = await _dbContext.Expenses
                    .Where(E => E.Category == budget.Category && E.AccountName == Account.Name)
                    .ToListAsync();

                foreach (var Expense in Expenses)
                {
                    budget.CurrentAmount += Expense.Amount;
                }



            }

           await _dbContext.AddAsync(budget);
        }

        public override async Task UpdateAsync(Budget budget)
        {

            var ExistingBudget = await _dbContext.Budgets
                .Include(b => b.Accounts)
                .FirstOrDefaultAsync(b => b.Id == budget.Id);

            

            ExistingBudget.CurrentAmount = 0;
            ExistingBudget.Limit = budget.Limit;
            ExistingBudget.Category = budget.Category;
            ExistingBudget.Name = budget.Name;
            ExistingBudget.Period = budget.Period;
            ExistingBudget.StartDate = budget.StartDate;
            ExistingBudget.EndDate = budget.EndDate;

            var Expenses = await _dbContext.Expenses
                .Where(E => E.Category == budget.Category)
                .ToListAsync();

            foreach (var Account in budget.Accounts)
            {
                if(!ExistingBudget.Accounts.Any(a => a.Name == Account.Name))
                {
                    ExistingBudget.Accounts.Add(_dbContext.Accounts.FirstOrDefault(A => A.Name == Account.Name) );
                }

                Expenses = Expenses.Where(E => E.AccountName == Account.Name).ToList();

                foreach (var Expense in Expenses)
                {
                    ExistingBudget.CurrentAmount += Expense.Amount;
                }

            }



            _dbContext.Update(ExistingBudget);

        }




    }
}
