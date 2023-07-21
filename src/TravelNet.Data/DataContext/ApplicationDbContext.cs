using Microsoft.EntityFrameworkCore;
using TravelNet.Data.Mapping.ClienteContext;
using TravelNet.Domain.Entities.ClienteContext;
using TravelNet.Domain.Entities.ProdutoContext;
using TravelNet.Domain.Entities.SelfServiceSalesContext;
using TravelNet.Domain.Entities.VooContext;

namespace TravelNet.Data.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<SelfServiceSale> SelfieServiceSales { get; set; }
        public DbSet<CodigoVoo> Voos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.Entity<Cliente>(new ClienteMap().Configure);

            //builder.Entity<User>()
            //     .HasIndex(e => e.Email)
            //     .IsUnique();

            //builder.Entity<User>()
            //       .ToTable("AspNetUsers")
            //       .HasKey(e => e.Id);


        }
    }
}
