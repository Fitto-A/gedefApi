using Microsoft.EntityFrameworkCore;

namespace gedefApi.Models
{
    public class GedefDbContext : DbContext
    {
        public GedefDbContext(DbContextOptions<GedefDbContext> options) : base(options)
        { }
        
        public DbSet<Legajos> TBA_LEGAJOS { get; set; }        
    }

}