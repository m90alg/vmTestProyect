using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace VMtest.Models.ModelConfiguration
{
    public class TransactionsConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder <Transactions> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Usuario).HasMaxLength(25).IsRequired();
            builder.Property(prop => prop.Moneda).HasMaxLength(10).IsRequired();
            builder.Property(prop => prop.Monto).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(prop => prop.Total).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(prop => prop.Fecha).HasColumnType("date").IsRequired();
        }
    }
}
