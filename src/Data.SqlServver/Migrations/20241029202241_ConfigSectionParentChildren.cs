using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ploch.EditorConfigTools.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ConfigSectionParentChildren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ConfigSections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigSections_ParentId",
                table: "ConfigSections",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigSections_ConfigSections_ParentId",
                table: "ConfigSections",
                column: "ParentId",
                principalTable: "ConfigSections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigSections_ConfigSections_ParentId",
                table: "ConfigSections");

            migrationBuilder.DropIndex(
                name: "IX_ConfigSections_ParentId",
                table: "ConfigSections");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ConfigSections");
        }
    }
}
