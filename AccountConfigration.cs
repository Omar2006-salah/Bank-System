using Bank_Project.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project.Models.config
{
    public class AccountConfigration : IEntityTypeConfiguration<Accountc>
    {
        public void Configure(EntityTypeBuilder<Accountc> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.Fname).HasColumnType("VARCHAR").HasMaxLength(40).IsRequired(true);
            builder.Property(a => a.Lname).HasColumnType("VARCHAR").HasMaxLength(40).IsRequired(true);
            builder.Property(a => a.Phone).HasColumnType("VARCHAR").HasMaxLength(15).IsRequired(true);
            builder.Property(a => a.Email).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(true);
            builder.Property(a => a.Account_Name).HasColumnType("VARCHAR").HasMaxLength(40);
            builder.HasMany(a => a.Transactions).WithOne(a => a.Navigation_Account).HasForeignKey(a => a.Account_ID);
        }

      
    }
}
