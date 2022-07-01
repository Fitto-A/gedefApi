using Microsoft.EntityFrameworkCore;

namespace gedefApi.Models
{
    public class GedefDbContext : DbContext
    {
        public GedefDbContext(DbContextOptions<GedefDbContext> options) : base(options)
        { }

        public DbSet<Legajos> TBA_LEGAJOS { get; set; }
        public DbSet<Usuarios> TBA_USUARIOS { get; set; }
        public DbSet<Plantillas> TBA_PLANTILLAS { get; set; }
        public DbSet<RolxBar> TBA_ROLXBAR { get; set; }
        public DbSet<Barcos> TBA_BARCOS { get; set; }

    }

}