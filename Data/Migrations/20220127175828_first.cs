using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Summary = table.Column<string>(maxLength: 255, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "Id", "Image", "Name", "Summary" },
                values: new object[,]
                {
                    { 1, "portfolio-1.jpg", "Stationary", "A yellow pencil with envelopes on a clean, blue backdrop!" },
                    { 2, "portfolio-1.jpg", "Stationary", "A yellow pencil with envelopes on a clean, blue backdrop!" },
                    { 3, "portfolio-1.jpg", "Stationary", "A yellow pencil with envelopes on a clean, blue backdrop!" },
                    { 4, "portfolio-1.jpg", "Stationary", "A yellow pencil with envelopes on a clean, blue backdrop!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}
