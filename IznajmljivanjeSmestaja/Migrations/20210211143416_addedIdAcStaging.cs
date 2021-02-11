using Microsoft.EntityFrameworkCore.Migrations;

namespace IznajmljivanjeSmestaja.Migrations
{
    public partial class addedIdAcStaging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAccomodationStaging",
                table: "AccomadationGallery",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAccomodationStaging",
                table: "AccomadationGallery");
        }
    }
}
