using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPruebaAleix.Infrastructure.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Apellidos", "Email", "Nif", "Nombre" },
                values: new object[,]
                {
                    { 1, "Jimenez Pato", "paco.jimenez@hotmail.com", "453453254P", "Paco" },
                    { 2, "Garcia De Mato", "carladm@gmail.com", "456345654O", "Carla" },
                    { 3, "Sanchez Martin", "ramon55@gmail.com", "342342412Y", "Ramon" },
                    { 4, "Loro Ayuso", "lorito@gmail.com", "821378223Y", "Irene" },
                    { 5, "Lorenzo Marquez", "lorenzo@gmail.com", "456542342I", "Alex" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 5);
        }
    }
}
