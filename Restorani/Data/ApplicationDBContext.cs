using Microsoft.EntityFrameworkCore;
using Restorani.Models;

namespace Restorani.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Restoran> Restorani { get; set; }
        public virtual DbSet<Jelo> Jela { get; set; }
    }
}
