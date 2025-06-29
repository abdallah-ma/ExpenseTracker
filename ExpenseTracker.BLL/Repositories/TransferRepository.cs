using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.DAL.Models;
using ExpenseTracker.DAL.Data;
using ExpenseTracker.BLL.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.BLL.Repositories
{
    public class TransferRepository : GenericRepository<Transfer>
    {


        public TransferRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task AddAsync(Transfer transfer)
        {
            
            var SourceAccount = _dbContext.Accounts.FirstOrDefault(x => x.Name == transfer.SourceAccountName);
            var RecipientAccount = _dbContext.Accounts.FirstOrDefault(x => x.Name == transfer.RecipientAccountName);

            SourceAccount.Balance -= transfer.Amount;
            RecipientAccount.Balance += transfer.Amount;


            await _dbContext.Transfers.AddAsync(transfer);
        }


        public override async Task UpdateAsync(Transfer transfer)
        {
            var CurrentTransfer = _dbContext.Transfers.FirstOrDefault(x => x.Id == transfer.Id);

            _dbContext.Entry(CurrentTransfer).State = EntityState.Detached;

            var SourceAccount = _dbContext.Accounts.FirstOrDefault(x => x.Name == CurrentTransfer.SourceAccountName);
            var RecipientAccount = _dbContext.Accounts.FirstOrDefault(x => x.Name == CurrentTransfer.RecipientAccountName);


            SourceAccount.Balance += CurrentTransfer.Amount;
            RecipientAccount.Balance -= CurrentTransfer.Amount;

            
            var NewSourceAccount = _dbContext.Accounts.FirstOrDefault(x => x.Name == transfer.SourceAccountName);
            var NewRecipientAccount = _dbContext.Accounts.FirstOrDefault(x => x.Name == transfer.RecipientAccountName);

            _dbContext.Update(transfer);
            await Task.CompletedTask;
        }

    }
}
