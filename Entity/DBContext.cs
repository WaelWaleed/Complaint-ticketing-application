using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
            
        }
        public DBContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            var ConnectionString = @"Data Source=.;Initial Catalog=CTA;user id=sa;password=abc_123;TrustServerCertificate=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Complaint> Complaint {  get; set; }
        public DbSet<Demand> Demand { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complaint>()
                .HasMany<Demand>(e=>e.Demands)
                .WithOne(e=>e.Complaint)
                .HasForeignKey(e=>e.ComplaintID)
                .HasConstraintName("FK_Complaint_Demand")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany<Complaint>(e=>e.Complaints)
                .WithOne(e=>e.User)
                .HasForeignKey(e=>e.UserID)
                .HasConstraintName("FK_User_Complaint")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserType>()
                .HasMany<User>(e=>e.Users)
                .WithOne(e=>e.UserType)
                .HasForeignKey(e=>e.TypeID)
                .HasConstraintName("FK_UserType_User")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserType>()
                .HasData(
                    new UserType
                    {
                        ID = 1,
                        IsDeleted = false,
                        Name = "User",
                    },
                    new UserType
                    {
                        ID = 2,
                        IsDeleted = false,
                        Name = "Adminstrator",
                    }
                );

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Name = "user",
                        Mobile = "1037059021",
                        ID = 1,
                        TypeID = 2,
                    }
                );

        }


    }
}
