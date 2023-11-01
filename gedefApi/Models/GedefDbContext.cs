using gedefApi.Models.PartesPesca;
using gedefApi.Models.PlanillaRoles;
using gedefApi.Models.RRHH;
using Microsoft.EntityFrameworkCore;

namespace gedefApi.Models
{
    public class GedefDbContext : DbContext
    {
        public GedefDbContext(DbContextOptions<GedefDbContext> options) : base(options)
        { }

        public DbSet<Legajos> TBA_LEGAJOS { get; set; } 
        public DbSet<Usuarios> TBA_USUARIOS { get; set; }
        public DbSet<Barcos> TBA_BARCOS { get; set; }
        public DbSet<Mareas> TBA_MAREAS { get; set; }
        public DbSet<Numeradores> TBA_NUMERADORES { get; set; } 
        public DbSet<Puertos> TBA_PUERTOS { get; set; } 
        public DbSet<EmailSend> TBA_EMAILSEND { get; set; } 
        public DbSet<Empresas> TBA_EMPRESAS { get; set; }

        //PLANILLAROLES
        public DbSet<RolxBar> TBA_ROLXBAR { get; set; } 
        public DbSet<RolxBarxMar> TBA_ROLXBARXMAR { get; set; } 
        public DbSet<DiasxMar> TBA_DIASXMAR { get; set; } 
        //public DbSet<Categorias> TBA_CATEGORIAS { get; set; }
        public DbSet<Roles> TBA_ROLES { get; set; } 
        public DbSet<DiasExtraordinarios> TBA_DIASEXTRAORDINARIOS { get; set; }

        //PARTESPESCA
        public DbSet<PartePesca> TBA_PARTEPESCA { get; set; } 
        public DbSet<ParteSinPesca> TBA_PARTESINPESCA { get; set; } 
        public DbSet<ParteFinal> TBA_PARTEFINAL { get; set; } 
        public DbSet<Especies> TBA_ESPECIES { get; set; }
        public DbSet<Motivos> TBA_MOTIVOS { get; set; }
        public DbSet<PFPCongeladores> TBA_PFPCongeladores { get; set; }
        public DbSet<PFPFresqueros> TBA_PFPFresqueros { get; set; }
        public DbSet<ActaDescarga> TBA_ACTADESCARGA { get; set; }
        public DbSet<ActaDescargaPP> TBA_ACTADESCARGA_PP { get; set; }

        //RRHH
        public DbSet<CambioRoles> TBA_CAMBIOROLES { get; set; }
        public DbSet<Sueldos> TBA_SUELDOS { get; set; }

    }

}