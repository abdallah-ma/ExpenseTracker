using ExpenseTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DAL.Data.Configuration
{
    internal class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Account> builder)
        {



            builder.HasKey(A => A.Id);

            builder.HasIndex(A => A.Name).IsUnique();
            builder.Property(A => A.Balance);



            builder.Property(A => A.Type);

            builder.HasMany(A => A.Budgets).WithMany(B => B.Accounts);


            
            
        }
    }
}
