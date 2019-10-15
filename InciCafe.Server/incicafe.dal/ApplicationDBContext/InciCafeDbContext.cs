using InciCafe.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;


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


            modelbuilder.Entity<Coffee>().HasData(
       new Coffee
       {
           Id = 1,
           Name = "Espresso",
           Image = ImgToByteArray(@"../Images/Espresso.png")

       },
        new Coffee
        {
            Id = 2,
            Name = "Latte",
            Image = ImgToByteArray(@"../Images/Latte.png")

        },
        new Coffee
        {
            Id = 3,
            Name = "Americano",
            Image = ImgToByteArray(@"../Images/Americano.png")
        },
        new Coffee
        {
            Id = 4,
            Name = "Cappuccino",
            Image = ImgToByteArray(@"../Images/Cappuccino.png")
        }




   );
            modelbuilder.Entity<Client>().HasIndex(e => e.Id)
             .HasName("Id")
             .IsUnique();
            modelbuilder.Entity<Client>().HasData(
new Client
{
    Id = 1,
    FirstName = "Philippe",
    LastName = "Harb",
    Email = "Philippe.h99@gmail.com"


},
new Client
{
    Id =2,
    FirstName = "Rayan",
    LastName = "Kazouiny",
    Email = "rayankazouiny@hotmail.com"

}
);

        }
        public byte[] ImgToByteArray(string FileName)

        {
            var img = Image.FromFile(FileName);
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }


    }
}
