using Microsoft.EntityFrameworkCore;

namespace gedefApi.Models
{
    public class GedefDbContext : DbContext
    {
        public GedefDbContext(DbContextOptions<GedefDbContext> options) : base(options)
        { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Legajo> Legajos { get; set; }
        public DbSet<TBA_LEGAJO> TBA_LEGAJOS { get; set; }
        public DbSet<TBA_USUARIOS> TBA_USUARIOS { get; set; }
        public DbSet<TBA_BARCOS> TBA_BARCOS { get; set; }
        public DbSet<TBA_ROLXBAR> TBA_ROLXBAR { get; set; }
        public DbSet<TBA_PLANTILLAS> TBA_PLANTILLAS { get; set; }


    }

}