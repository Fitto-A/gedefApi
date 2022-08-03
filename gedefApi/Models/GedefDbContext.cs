using Microsoft.EntityFrameworkCore;

namespace gedefApi.Models
{
    public class GedefDbContext : DbContext
    {
        public GedefDbContext(DbContextOptions<GedefDbContext> options) : base(options)
        { }
        public DbSet<Legajos> TBA_LEGAJOS { get; set; }
        public DbSet<Usuarios> TBA_USUARIOS { get; set; }
        public DbSet<RolxBar> TBA_ROLXBAR { get; set; }
        public DbSet<Barcos> TBA_BARCOS { get; set; }
        public DbSet<Mareas> TBA_MAREAS { get; set; }
        public DbSet<RolxBarxMar> TBA_ROLXBARXMAR { get; set; }
        public DbSet<Numeradores> TBA_NUMERADORES { get; set; }
        public DbSet<DiasxMar> TBA_DIASXMAR { get; set; }
        public DbSet<Puertos> TBA_PUERTOS { get; set; }

    }

}