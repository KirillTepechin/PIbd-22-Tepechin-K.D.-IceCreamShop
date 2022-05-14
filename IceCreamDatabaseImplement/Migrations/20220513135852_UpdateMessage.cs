using Microsoft.EntityFrameworkCore.Migrations;

namespace IceCreamShopDatabaseImplement.Migrations
{
    public partial class UpdateMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reply",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Viewed",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reply",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Viewed",
                table: "Messages");
        }
    }
}
