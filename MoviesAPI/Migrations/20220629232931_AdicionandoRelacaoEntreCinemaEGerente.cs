using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.Migrations
{
    public partial class AdicionandoRelacaoEntreCinemaEGerente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "MovieTheaters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Managers_AddressId",
                table: "MovieTheaters",
                column: "AddressId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Managers_AddressId",
                table: "MovieTheaters");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "MovieTheaters");
        }
    }
}
