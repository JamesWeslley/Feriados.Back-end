using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feriados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "varchar(5)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Legislacao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(50)", nullable: false),
                    HoraInicio = table.Column<string>(type: "varchar(8)", nullable: false),
                    HoraFim = table.Column<string>(type: "varchar(8)", nullable: false),
                    DatasMoveis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feriados", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feriados_Titulo",
                table: "Feriados",
                column: "Titulo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feriados");
        }
    }
}
