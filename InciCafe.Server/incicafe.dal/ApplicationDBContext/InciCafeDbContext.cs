using InciCafe.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace InciCafe.DAL
{

    public class InciCafeDbContext : IdentityDbContext
    {
     
        public DbSet<Client> Clients { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Status { get; set; }

        public InciCafeDbContext(DbContextOptions<InciCafeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }
    }
}
