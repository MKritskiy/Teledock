using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teledock.Migrations
{
    /// <inheritdoc />
    public partial class INNAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "INN",
                table: "Founders",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INN",
                table: "Founders");
        }
    }
}
