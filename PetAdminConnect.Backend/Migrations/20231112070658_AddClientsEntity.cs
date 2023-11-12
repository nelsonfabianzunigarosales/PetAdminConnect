using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdminConnect.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddClientsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Species_SpecieId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Pets_PetId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_PetId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Species");

            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SpecieId",
                table: "Breeds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedId",
                table: "Pets",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ClientId",
                table: "Pets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SpecieId",
                table: "Pets",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Species_SpecieId",
                table: "Breeds",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clients_ClientId",
                table: "Pets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Species_SpecieId",
                table: "Pets",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Species_SpecieId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clients_ClientId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Species_SpecieId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Pets_BreedId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ClientId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_SpecieId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Species",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpecieId",
                table: "Breeds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Species_PetId",
                table: "Species",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Species_SpecieId",
                table: "Breeds",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Pets_PetId",
                table: "Species",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }
    }
}
