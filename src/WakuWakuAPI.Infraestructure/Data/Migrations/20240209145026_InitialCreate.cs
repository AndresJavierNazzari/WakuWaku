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
                    { 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9604), null, "Some description", "Frontend", null },
                    { 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9605), null, "Some description", "Backend", null },
                    { 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9606), null, "Some description", "Mobile", null },
                    { 4, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9607), null, "Some description", "DevOps", null },
                    { 5, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9607), null, "Some description", "Data Science", null },
                    { 6, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9608), null, "Some description", "Design", null }
                });

            migrationBuilder.InsertData(
                table: "Dificulty",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9456), null, "Easy", null },
                    { 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9461), null, "Medium", null },
                    { 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9462), null, "Hard", null }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9582), null, "To Do", null },
                    { 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9583), null, "In Progress", null },
                    { 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9585), null, "Done", null }
                });

            migrationBuilder.InsertData(
                table: "UsersData",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9726), null, "email1@email.com", "password1", null },
                    { 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9728), null, "email2@email.com", "password2", null },
                    { 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9729), null, "email3@email.com", "password3", null }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9668), null, "Programing language", "HTML", null },
                    { 2, 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9671), null, "Programing language", "CSS", null },
                    { 3, 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9672), null, "Programing language", "JavaScript", null },
                    { 4, 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9673), null, "Library", "React", null },
                    { 5, 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9673), null, "Framework", "Angular", null },
                    { 6, 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9674), null, "Framework", "Vue", null },
                    { 7, 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9675), null, "Runtime environment", "Node", null },
                    { 8, 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9676), null, "Programing language", "Python", null },
                    { 9, 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9676), null, "Programing language", "Ruby", null },
                    { 10, 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9677), null, "Programing language", "Java", null },
                    { 11, 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9678), null, "Programing language", "C#", null },
                    { 12, 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9678), null, "Programing language", "PHP", null },
                    { 13, 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9679), null, "Programing language", "Swift", null },
                    { 14, 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9680), null, "Programing language", "Kotlin", null },
                    { 15, 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9681), null, "Programing language", "Objective-C", null },
                    { 16, 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9681), null, "Framework", "Xamarin", null },
                    { 17, 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9682), null, "Framework", "Flutter", null },
                    { 18, 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9683), null, "Framework", "Ionic", null },
                    { 19, 4, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9684), null, "Containerization platform", "Docker", null },
                    { 20, 4, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9684), null, "Container orchestration platform", "Kubernetes", null },
                    { 21, 4, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9685), null, "Automation server", "Jenkins", null },
                    { 22, 4, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9686), null, "DevOps platform", "GitLab", null },
                    { 23, 4, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9687), null, "DevOps platform", "GitHub", null },
                    { 24, 4, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9688), null, "DevOps platform", "Bitbucket", null },
                    { 25, 5, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9690), null, "Programing language", "Python", null },
                    { 26, 5, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9691), null, "Programing language", "R", null },
                    { 27, 5, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9692), null, "Programing language", "Scala", null },
                    { 28, 5, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9693), null, "Programing language", "Julia", null },
                    { 29, 5, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9693), null, "Programing language", "Matlab", null },
                    { 30, 6, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9694), null, "Design software", "Photoshop", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FirstName", "LastName", "UpdatedAt", "UserDataId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9744), null, "John", "Doe", null, 1 },
                    { 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9746), null, "Jane", "Doe", null, 2 },
                    { 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9747), null, "John", "Smith", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "CreatedAt", "Deadline", "DeletedAt", "Description", "DificultyId", "SkillId", "StatusId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9764), new DateTime(2024, 3, 10, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9765), null, "Learn HTML", 1, 1, 1, null, 1 },
                    { 2, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9773), new DateTime(2024, 3, 10, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9774), null, "Learn CSS", 1, 2, 1, null, 1 },
                    { 3, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9775), new DateTime(2024, 3, 10, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9775), null, "Learn JavaScript", 1, 3, 1, null, 1 },
                    { 4, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9776), new DateTime(2024, 3, 10, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9777), null, "Learn React", 1, 4, 1, null, 1 },
                    { 5, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9778), new DateTime(2024, 3, 10, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9778), null, "Learn Angular", 1, 5, 1, null, 1 },
                    { 6, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9779), new DateTime(2024, 3, 10, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9779), null, "Learn Vue", 1, 6, 1, null, 1 },
                    { 7, new DateTime(2024, 2, 9, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9780), new DateTime(2024, 3, 10, 14, 50, 26, 548, DateTimeKind.Utc).AddTicks(9781), null, "Learn Node", 1, 7, 1, null, 1 }
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
