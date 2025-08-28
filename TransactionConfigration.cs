using Bank_Project.Models.Entites;
using Bank_Project.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bank_Project.Models.config
{
    public class TransactionConfigration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Date).HasColumnType("DATE");
            // convert fron enum in code source - - > string in database then string 
            // in db - - > enum in code source 
            builder.Property(x => x.Type).HasConversion(
                x => x.ToString() , x => (Enums.Transaction_Types)Enum.Parse(typeof(Enums.Transaction_Types) , x)
                );

            builder.Property(x => x.Some_Notes).HasColumnType("VARCHAR").HasMaxLength(300);
        }
    }
}
