using Microsoft.EntityFrameworkCore;
using ProvaWeek6.Core.EF.Configuration;
using ProvaWeek6.Core.Entity;
using System;

namespace ProvaWeek6.Core.EF
{
    public class ManagerContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ManagerContext() : base() { }
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = GestioneOrdini; Integrated Security = true; MultipleActiveResultSets = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
        }

    }
}
