using Microsoft.EntityFrameworkCore;
using bReady.Models;

namespace bReady.Data
{
    public class ApplicationDbContext : DbContext{
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Flag> Flags { get; set; }

        public DbSet<ModelsRelation> ModelsRelations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // One to Many

            builder.Entity<Car>()
                    .HasMany(m1 => m1.Users)
                    .WithOne(m2 => m2.car);

            builder.Entity<User>()
                .HasOne(m2 => m2.car)
                .WithMany(m1 => m1.Users);


            // One to One

            builder.Entity<Country>()
                .HasOne(m5 => m5.Flag)
                .WithOne(m6 => m6.Country)
                .HasForeignKey<Flag>(m6 => m6.CountryId);


            //builder.Entity<Model5>()
            //    .HasOptional(x => x.Model6)
            //    .WithRequired(x => x.Model7);


            // Many to Many

            builder.Entity<ModelsRelation>().HasKey(mr => new { mr.CarId, mr.CountryId });

            builder.Entity<ModelsRelation>()
                   .HasOne<Car>(mr => mr.Car)
                   .WithMany(m3 => m3.ModelsRelations)
                   .HasForeignKey(mr => mr.CarId);


            builder.Entity<ModelsRelation>()
                   .HasOne<Country>(mr => mr.Country)
                   .WithMany(m4 => m4.ModelsRelations)
                   .HasForeignKey(mr => mr.CountryId);


            base.OnModelCreating(builder);
        }

    }
}