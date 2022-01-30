using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bReady.Migrations
{
    public partial class carsmigradto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flag_Country_CountryId",
                table: "Flag");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelsRelations_Car_CarId",
                table: "ModelsRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelsRelations_Country_CountryId",
                table: "ModelsRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Car_carId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flag",
                table: "Flag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Flag",
                newName: "Flags");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_User_carId",
                table: "Users",
                newName: "IX_Users_carId");

            migrationBuilder.RenameIndex(
                name: "IX_Flag_CountryId",
                table: "Flags",
                newName: "IX_Flags_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flags",
                table: "Flags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flags_Countries_CountryId",
                table: "Flags",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsRelations_Cars_CarId",
                table: "ModelsRelations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsRelations_Countries_CountryId",
                table: "ModelsRelations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cars_carId",
                table: "Users",
                column: "carId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flags_Countries_CountryId",
                table: "Flags");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelsRelations_Cars_CarId",
                table: "ModelsRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelsRelations_Countries_CountryId",
                table: "ModelsRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cars_carId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flags",
                table: "Flags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Flags",
                newName: "Flag");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameIndex(
                name: "IX_Users_carId",
                table: "User",
                newName: "IX_User_carId");

            migrationBuilder.RenameIndex(
                name: "IX_Flags_CountryId",
                table: "Flag",
                newName: "IX_Flag_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flag",
                table: "Flag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flag_Country_CountryId",
                table: "Flag",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsRelations_Car_CarId",
                table: "ModelsRelations",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsRelations_Country_CountryId",
                table: "ModelsRelations",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Car_carId",
                table: "User",
                column: "carId",
                principalTable: "Car",
                principalColumn: "Id");
        }
    }
}
