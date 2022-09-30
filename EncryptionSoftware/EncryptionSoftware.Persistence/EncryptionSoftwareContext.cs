using EncryptionSoftware.Domain;
using EncryptionSoftware.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EncryptionSoftware.Persistence
{
    public class EncryptionSoftwareContext : DbContext
    {
        public EncryptionSoftwareContext(DbContextOptions<EncryptionSoftwareContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>()
                .Property(x => x.ListaDePrecios)
                .HasConversion(
                    listOfIntPrices => JsonConvert.SerializeObject(listOfIntPrices),
                    pricesJsonRepresentation => JsonConvert.DeserializeObject<List<int>>(pricesJsonRepresentation));
            modelBuilder.Entity<Productos>()
                .HasData(SeedData.Products);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Frases> Frases { get; set; }
    }
}