using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WakuWakuAPI.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dificulty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificulty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserDataId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UsersData_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UsersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false),
                    DificultyId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Dificulty_DificultyId",
                        column: x => x.DificultyId,
                        principalTable: "Dificulty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2368), null, "Some description", "Frontend", null },
                    { 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2370), null, "Some description", "Backend", null },
                    { 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2370), null, "Some description", "Mobile", null },
                    { 4, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2371), null, "Some description", "DevOps", null },
                    { 5, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2372), null, "Some description", "Data Science", null },
                    { 6, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2373), null, "Some description", "Design", null }
                });

            migrationBuilder.InsertData(
                table: "Dificulty",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2226), null, "Easy", null },
                    { 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2229), null, "Medium", null },
                    { 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2230), null, "Hard", null }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2344), null, "To Do", null },
                    { 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2346), null, "In Progress", null },
                    { 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2346), null, "Done", null }
                });

            migrationBuilder.InsertData(
                table: "UsersData",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2491), null, "email1@email.com", "password1", null },
                    { 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2493), null, "email2@email.com", "password2", null },
                    { 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2494), null, "email3@email.com", "password3", null }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2394), null, "Programing language", "HTML", null },
                    { 2, 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2396), null, "Programing language", "CSS", null },
                    { 3, 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2397), null, "Programing language", "JavaScript", null },
                    { 4, 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2398), null, "Library", "React", null },
                    { 5, 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2437), null, "Framework", "Angular", null },
                    { 6, 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2438), null, "Framework", "Vue", null },
                    { 7, 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2439), null, "Runtime environment", "Node", null },
                    { 8, 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2440), null, "Programing language", "Python", null },
                    { 9, 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2441), null, "Programing language", "Ruby", null },
                    { 10, 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2442), null, "Programing language", "Java", null },
                    { 11, 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2442), null, "Programing language", "C#", null },
                    { 12, 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2443), null, "Programing language", "PHP", null },
                    { 13, 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2444), null, "Programing language", "Swift", null },
                    { 14, 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2445), null, "Programing language", "Kotlin", null },
                    { 15, 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2445), null, "Programing language", "Objective-C", null },
                    { 16, 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2446), null, "Framework", "Xamarin", null },
                    { 17, 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2447), null, "Framework", "Flutter", null },
                    { 18, 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2447), null, "Framework", "Ionic", null },
                    { 19, 4, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2448), null, "Containerization platform", "Docker", null },
                    { 20, 4, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2449), null, "Container orchestration platform", "Kubernetes", null },
                    { 21, 4, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2450), null, "Automation server", "Jenkins", null },
                    { 22, 4, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2450), null, "DevOps platform", "GitLab", null },
                    { 23, 4, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2451), null, "DevOps platform", "GitHub", null },
                    { 24, 4, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2452), null, "DevOps platform", "Bitbucket", null },
                    { 25, 5, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2452), null, "Programing language", "Python", null },
                    { 26, 5, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2453), null, "Programing language", "R", null },
                    { 27, 5, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2454), null, "Programing language", "Scala", null },
                    { 28, 5, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2454), null, "Programing language", "Julia", null },
                    { 29, 5, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2455), null, "Programing language", "Matlab", null },
                    { 30, 6, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2456), null, "Design software", "Photoshop", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FirstName", "LastName", "UpdatedAt", "UserDataId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2513), null, "John", "Doe", null, 1 },
                    { 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2516), null, "Jane", "Doe", null, 2 },
                    { 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2517), null, "John", "Smith", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "CreatedAt", "Deadline", "DeletedAt", "Description", "DificultyId", "SkillId", "StatusId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2536), new DateTime(2024, 3, 14, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2537), null, "Learn HTML", 1, 1, 1, null, 1 },
                    { 2, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2547), new DateTime(2024, 3, 14, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2548), null, "Learn CSS", 1, 2, 1, null, 1 },
                    { 3, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2549), new DateTime(2024, 3, 14, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2549), null, "Learn JavaScript", 1, 3, 1, null, 1 },
                    { 4, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2550), new DateTime(2024, 3, 14, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2551), null, "Learn React", 1, 4, 1, null, 1 },
                    { 5, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2551), new DateTime(2024, 3, 14, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2552), null, "Learn Angular", 1, 5, 1, null, 1 },
                    { 6, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2553), new DateTime(2024, 3, 14, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2553), null, "Learn Vue", 1, 6, 1, null, 1 },
                    { 7, new DateTime(2024, 2, 13, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2554), new DateTime(2024, 3, 14, 9, 38, 32, 85, DateTimeKind.Utc).AddTicks(2555), null, "Learn Node", 1, 7, 1, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_DificultyId",
                table: "Goals",
                column: "DificultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_SkillId",
                table: "Goals",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_StatusId",
                table: "Goals",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserId",
                table: "Goals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CategoryId",
                table: "Skills",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDataId",
                table: "Users",
                column: "UserDataId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Dificulty");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UsersData");
        }
    }
}
