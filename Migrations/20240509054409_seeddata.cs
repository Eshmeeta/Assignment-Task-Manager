using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_Eshmeeta.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "Collect the PRD from the client", "Completed", "Requirements Gathering" },
                    { 2, "Discuss the requirements with the team", "Completed", "Requirements Analysis" },
                    { 3, "Provide a suitable timeline to the client", "Completed", "Provide Timeline" },
                    { 4, "Develop the product", "In-Progress", "Development" },
                    { 5, "Test the product", "Incomplete", "Testing" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
