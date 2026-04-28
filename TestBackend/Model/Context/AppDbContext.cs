using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestBackend.Model.Entity;

namespace TestBackend.Model.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Service> Services { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=G7CR;database=vstdb;Integrated Security=True;Trust Server Certificate=True;Multi Subnet Failover=False");
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Vehicle> vehicleBuilder = modelBuilder.Entity<Vehicle>();

            vehicleBuilder
                .ToTable("vehicles")
                .HasKey(v => v.VehicleNumber);


            vehicleBuilder
                .Property<string>(v => v.VehicleNumber)
                .HasColumnName("number")
                .HasColumnType("varchar(10)")
                .ValueGeneratedNever();

            vehicleBuilder
                .Property<string>(v => v.OwnerName)
                .HasColumnName("owner_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            vehicleBuilder
                .Property<string>(v => v.Type)
                //.HasConversion<string>()
                .HasColumnName("type")
                .HasColumnType("varchar(10)")
                .IsRequired();


            EntityTypeBuilder<Service> serviceBuilder = modelBuilder.Entity<Service>();

            serviceBuilder.ToTable("services")
                .HasKey(s => s.Id);

            serviceBuilder
                .Property<int>(s => s.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            serviceBuilder
                .Property<DateTime>(s => s.Date)
                .HasColumnName("date")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            serviceBuilder
                .Property<string>(s => s.Type)
                .HasColumnType("varchar(100)")
                .HasColumnName("type")
                .IsRequired();


            serviceBuilder
                .Property<decimal>(s => s.Cost)
                .HasColumnName("cost")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            serviceBuilder
                .Property<string>(s => s.VehicleNumber)
                .HasColumnName("vehicle_number")
                .HasColumnType("varchar(10)")
                .IsRequired();

            serviceBuilder
                .HasOne(s => s.Vehicle)
                .WithMany(v => v.Service)
                .HasForeignKey(s => s.VehicleNumber)
                .OnDelete(DeleteBehavior.Cascade);




        }

    }
}
