using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonToSqlite.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddYgoProDeckId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YgoProDeckId",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YgoProDeckId",
                table: "Cards");
        }
    }
}
