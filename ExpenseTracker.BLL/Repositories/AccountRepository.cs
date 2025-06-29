using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.DAL.Models;
using ExpenseTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.BLL.Repository;

namespace ExpenseTracker.BLL.Repositories
{
    public class AccountRepository : GenericRepository<Account>
    {

        public AccountRepository(AppDbContext DbContext) : base(DbContext) {

        }

    }
}
