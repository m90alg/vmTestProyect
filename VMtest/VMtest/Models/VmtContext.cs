using Microsoft.EntityFrameworkCore;
using VMtest.Models.ModelConfiguration;

namespace VMtest.Models
{
    public class VmtContext : DbContext
    {
        public VmtContext(DbContextOptions<VmtContext> options) 
            :base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder vmModelBuilder)
        {
            vmModelBuilder.UseSerialColumns();
            vmModelBuilder.ApplyConfiguration(new TransactionsConfiguration());
        }
                
        public DbSet<Transactions> Transactions { get; set; }
    }
}
