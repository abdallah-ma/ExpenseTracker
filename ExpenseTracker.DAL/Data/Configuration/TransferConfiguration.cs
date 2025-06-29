using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExpenseTracker.DAL.Models;

namespace ExpenseTracker.DAL.Data.Configuration
{
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {

            builder.HasKey(T => T.Id);

            builder.Property(T => T.Amount);


            builder.Property(T => T.Date);

            builder.Property(T => T.RecipientAccountName);

            builder.Property(T => T.SourceAccountName);

            

        }
    }
}
