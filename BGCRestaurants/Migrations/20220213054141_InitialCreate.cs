using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BGCRestaurants.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    SmallTables = table.Column<int>(type: "INTEGER", nullable: false),
                    MediumTables = table.Column<int>(type: "INTEGER", nullable: false),
                    LargeTables = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    RestaurantName = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfPeople = table.Column<int>(type: "INTEGER", nullable: false),
                    Valid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Restaurants_RestaurantName",
                        column: x => x.RestaurantName,
                        principalTable: "Restaurants",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Name", "ClosingTime", "LargeTables", "MediumTables", "OpeningTime", "SmallTables" },
                values: new object[] { "ABC", new TimeSpan(0, 23, 0, 0, 0), 1, 2, new TimeSpan(0, 15, 0, 0, 0), 2 });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Name", "ClosingTime", "LargeTables", "MediumTables", "OpeningTime", "SmallTables" },
                values: new object[] { "DEF", new TimeSpan(0, 22, 0, 0, 0), 2, 3, new TimeSpan(0, 16, 0, 0, 0), 2 });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Name", "ClosingTime", "LargeTables", "MediumTables", "OpeningTime", "SmallTables" },
                values: new object[] { "GHI", new TimeSpan(0, 21, 0, 0, 0), 1, 2, new TimeSpan(0, 17, 0, 0, 0), 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 1, new DateTime(2020, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, "ABC", "17:00 PM", "aaa@example.com", true });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 2, new DateTime(2020, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 4, "ABC", "17:00 PM", "bbb@example.com", true });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 3, new DateTime(2020, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 4, "ABC", "17:00 PM", "ccc@example.com", false });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 4, new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "ABC", "18:00 PM", "ddd@example.com", true });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 5, new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "ABC", "18:00 PM", "eee@example.com", true });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 6, new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, "ABC", "18:00 PM", "fff@example.com", false });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 7, new DateTime(2020, 7, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, "ABC", "19:00 PM", "ggg@example.com", true });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 8, new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 6, "DEF", "18:00 PM", "hhh@example.com", true });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 9, new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 7, "DEF", "18:00 PM", "iii@example.com", true });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 10, new DateTime(2020, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 8, "DEF", "18:00 PM", "jjj@example.com", false });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 11, new DateTime(2020, 7, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, "GHI", "16:00 PM", "kkk@example.com", false });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 12, new DateTime(2020, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, "GHI", "17:00 PM", "lll@example.com", true });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "NumberOfPeople", "RestaurantName", "Time", "UserName", "Valid" },
                values: new object[] { 13, new DateTime(2020, 7, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), 3, "GHI", "22:00 PM", "mmm@example.com", false });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantName",
                table: "Reservations",
                column: "RestaurantName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
