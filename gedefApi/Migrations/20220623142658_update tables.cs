using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gedefApi.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBA_BARCOS",
                columns: table => new
                {
                    IDBAR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODBAR = table.Column<string>(type: "nchar(3)", nullable: false),
                    NOMBAR = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NUMMAR = table.Column<int>(type: "int", nullable: false),
                    ACTBAR = table.Column<string>(type: "nchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBA_BARCOS", x => x.IDBAR);
                });

            migrationBuilder.CreateTable(
                name: "TBA_LEGAJOS",
                columns: table => new
                {
                    IDLEG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LEGAJO = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CUIL = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NOMBRE = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CODPOS = table.Column<int>(type: "int", nullable: false),
                    RELEVO = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBA_LEGAJOS", x => x.IDLEG);
                });

            migrationBuilder.CreateTable(
                name: "TBA_PLANTILLAS",
                columns: table => new
                {
                    IDPLA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODPLA = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NOMBAR = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NUMMAR = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CODROLXBAR = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CAPITAN = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PRIMEROF = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    COCINERO = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MARINCUB1 = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBA_PLANTILLAS", x => x.IDPLA);
                });

            migrationBuilder.CreateTable(
                name: "TBA_ROLXBAR",
                columns: table => new
                {
                    IDROLXBAR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODROLXBAR = table.Column<string>(type: "nchar(3)", nullable: false),
                    CODBAR = table.Column<string>(type: "nchar(3)", nullable: false),
                    CAPITAN = table.Column<string>(type: "nchar(1)", nullable: false),
                    PRIMEROF = table.Column<string>(type: "nchar(1)", nullable: false),
                    JEFEMAQUINA = table.Column<string>(type: "nchar(1)", nullable: false),
                    COCINERO = table.Column<string>(type: "nchar(1)", nullable: false),
                    MARINCUB1 = table.Column<string>(type: "nchar(1)", nullable: false),
                    MARINPLA1 = table.Column<string>(type: "nchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBA_ROLXBAR", x => x.IDROLXBAR);
                });

            migrationBuilder.CreateTable(
                name: "TBA_USUARIOS",
                columns: table => new
                {
                    USUARIOID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIO = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CONTRASEÑA = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CATEGORIA = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBA_USUARIOS", x => x.USUARIOID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBA_BARCOS");

            migrationBuilder.DropTable(
                name: "TBA_LEGAJOS");

            migrationBuilder.DropTable(
                name: "TBA_PLANTILLAS");

            migrationBuilder.DropTable(
                name: "TBA_ROLXBAR");

            migrationBuilder.DropTable(
                name: "TBA_USUARIOS");
        }
    }
}
