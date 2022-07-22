using Microsoft.EntityFrameworkCore;

namespace gedefApi.Models
{
    public class GedefDbContext : DbContext
    {
        public GedefDbContext(DbContextOptions<GedefDbContext> options) : base(options)
        { }
        public DbSet<Legajos> TBA_LEGAJOSTEST { get; set; }
        public DbSet<Usuarios> TBA_USUARIOS { get; set; }
        public DbSet<Plantillas> TBA_PLANTILLAS { get; set; }
        public DbSet<RolxBar> TBA_ROLXBAR { get; set; }
        public DbSet<Barcos> TBA_BARCOS { get; set; }
        public DbSet<Mareas> TBA_MAREAS { get; set; }
        public DbSet<RolxBarxMar> TBA_ROLXBARXMAR { get; set; }

    }

}