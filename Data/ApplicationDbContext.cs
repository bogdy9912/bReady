using Microsoft.EntityFrameworkCore;
using bReady.Models;

namespace bReady.Data
{
    public class ApplicationDbContext : DbContext{
        
        public virtual DbSet<User> Users { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }
    }
}