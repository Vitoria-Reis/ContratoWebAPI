using Microsoft.EntityFrameworkCore;
using ContratoWebAPI.Models;

namespace ContratoWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Installment> Installments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
}