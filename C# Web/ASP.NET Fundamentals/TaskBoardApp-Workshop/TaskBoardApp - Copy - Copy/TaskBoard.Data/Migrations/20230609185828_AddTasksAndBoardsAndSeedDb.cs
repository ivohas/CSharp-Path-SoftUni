using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTasksAndBoardsAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("09d09049-93d6-4dd3-87d3-2310487f15a0"), 2, new DateTime(2023, 6, 8, 18, 58, 28, 471, DateTimeKind.Utc).AddTicks(8661), "Create Desktop client app for the TaskBorad RestFul API", "c7626073-c7b3-4049-9e09-99a5097998d8", "Desktop Client App" },
                    { new Guid("4fd301c3-4b06-43ac-830d-2864c6b7cd06"), 1, new DateTime(2023, 6, 4, 18, 58, 28, 471, DateTimeKind.Utc).AddTicks(8659), "Create Android client app for the TaskBorad RestFul API", "c7626073-c7b3-4049-9e09-99a5097998d8", "Android Client App" },
                    { new Guid("66fe8d2a-7b32-479d-a1c5-f6883ef95d0e"), 3, new DateTime(2022, 6, 9, 18, 58, 28, 471, DateTimeKind.Utc).AddTicks(8663), "Implement [Create Task] page for adding new Task", "3f3836d4-ace7-4e9a-9081-0513f8a09d10", "Create Task" },
                    { new Guid("72d07c60-2e3f-4298-b821-f11d42e7482d"), 1, new DateTime(2022, 11, 21, 18, 58, 28, 471, DateTimeKind.Utc).AddTicks(8649), "Implement better styling for all public pages", "3f3836d4-ace7-4e9a-9081-0513f8a09d10", "Improve CSS styles" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
