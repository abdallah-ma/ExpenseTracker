using ExpenseTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DAL.Data.Configuration
{
    internal class BudgetConfigurations : IEntityTypeConfiguration<Budget>

    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
           builder.HasKey(B => B.Id);
            builder.Property(B => B.Id).UseIdentityColumn();
            
           builder.HasIndex(B => B.Name).IsUnique(); 

           builder.Property(B => B.Period).IsRequired();

            builder.Property(B => B.StartDate);

            builder.Property(B => B.EndDate);

            builder.Property(B => B.Limit);

            builder.Property(B => B.CurrentAmount);


            builder.Property(B => B.Category);

            builder.HasMany(B => B.Accounts).WithMany(A => A.Budgets).UsingEntity("AccountBudgets");
                

        }
    }
}
