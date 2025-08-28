using Bank_Project.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project.Models.Interseptors
{
    class InHashPasswords : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var context = eventData.Context;
            // entites that have passwords 
            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.Entity is Accountc acc)
                {
                    if (entry.State == EntityState.Added)
                    {
                        if (!string.IsNullOrEmpty(acc.Password))
                            acc.Password = CryptoHelper.Encrypt(acc.Password);
                        acc.Account_Name = Generate_Account_Name(acc.Fname, acc.Lname);
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        var passwordProp = entry.Property(nameof(acc.Password));
                        if (passwordProp.IsModified && !string.IsNullOrEmpty(acc.Password))
                        {
                            acc.Password = CryptoHelper.Encrypt(acc.Password);
                        }
                    }
                }
            }


            return result;
        }
        public string Generate_Account_Name(string fname, string lname)
        {
            var min_r = new Random().Next(100);
            var max_r = new Random().Next(999);
            var rand = new Random().Next(Math.Min(min_r, max_r), Math.Max(min_r, max_r));

            return $"{fname}_{rand.ToString()}_{lname}";
        }
    }
}
