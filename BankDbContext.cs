using Bank_Project.Models.config;
using Bank_Project.Models.Entites;
using Bank_Project.Models.Interseptors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project.Models
{
    public class BankDbContext : DbContext
    {
        public DbSet<Accountc> Accounts { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.Connection_String())
                .AddInterceptors(new InHashPasswords()) ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfigration).Assembly);
        }
    }
}
