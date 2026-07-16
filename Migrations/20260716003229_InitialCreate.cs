using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalChain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GearTypeId = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PurchaseYear = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gears_GearTypes_GearTypeId",
                        column: x => x.GearTypeId,
                        principalTable: "GearTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Writer = table.Column<string>(type: "text", nullable: false),
                    Artist = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    YearRecorded = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GearSongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GearId = table.Column<int>(type: "integer", nullable: false),
                    SongId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearSongs_Gears_GearId",
                        column: x => x.GearId,
                        principalTable: "Gears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GearSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d", 0, "dd357080-2f20-418f-83ed-5fdc4b705e34", "rjohnson@signalchain.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEPeRZE51cDEkzAXZw9XTpZXCbC8pLHe/OJwq2OEj6Lb9mloBcqoY+sJeFavoxsp8PA==", null, false, "5b75d106-cdb7-423c-bd41-dd9eee7623da", false, "rjohnson" },
                    { "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b", 0, "540b57f6-3d71-4dff-ae82-3abe3c9f307f", "ajohnson@signalchain.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEJxhaFvU95PJRo7ju29uMMDp353cNtDuLRWh0cO3fXJZCBenV7LCcarNGrNCLfgINA==", null, false, "eed99b5a-cf3d-4b20-aa91-e9d4237d58fe", false, "ajohnson" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "143c6e3b-bcca-4cdd-ae84-a505eb96e472", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEPIW16VRueSIO5b1WGuEf1/OStqQZnYmJiosHdfOeMJQgnH0GG3lG3S7IdeC8cOrdw==", null, false, "5ce25ac2-6af4-4e8f-8f19-9e881f8791f2", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "GearTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Computer" },
                    { 2, "Microphone" },
                    { 3, "Instrument" },
                    { 4, "Recording" },
                    { 5, "Stands" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Recording" },
                    { 2, "Mixing" },
                    { 3, "Mastering" },
                    { 4, "Released" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "Gears",
                columns: new[] { "Id", "GearTypeId", "Model", "PurchaseYear", "Quantity", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 1, "Apple MacBook Air 2020 M1", "2021", 1, "FVFQHNACQ6L7" },
                    { 2, 2, "Studio Projects B1 Match Pair lrg dia mics", "N/A", 1, "SPB1X9876" },
                    { 3, 2, "Studio Projects B1 lrg dia microphone", "2024", 1, "SPB1X12345" },
                    { 4, 2, "Audix i5 microphone", "2024", 2, "N/A" },
                    { 5, 3, "Zildjian K hi-hats pair 14-inch", "2003", 1, "Top: JC 24956-097, Bottom: JC 24964-085" },
                    { 6, 3, "Sabian AAX Metal crash 16-inch", "2004", 1, "N/A" },
                    { 7, 3, "Zildjian A Medium-Thin crash 18-inch", "2017", 1, "AG85199 061" },
                    { 8, 3, "Zildjian A Medium-Thin crash 19-inch", "2005", 1, "JE 43363 006" },
                    { 9, 3, "Zildjian K Custom Medium ride 20-inch", "2004", 1, "JB 23527-016" },
                    { 10, 3, "Gretsch Brooklyn 6.5x14 snare GB4164S", "2023", 1, "033239" },
                    { 11, 3, "Gretsch Brooklyn Series drums", "2024", 3, "021463, 021452, 021467" },
                    { 12, 3, "Fender 1105 SXE acoustic guitar", "1996", 1, "9091202" },
                    { 13, 3, "Digital Piano 88-Key Keyboard", "2025", 1, "N/A" },
                    { 14, 3, "Trombone Blessing BTB1488O", "2025", 1, "N/A" },
                    { 15, 3, "Tambourine 8-inch Rock 'N' Roll Hall of Fame", "N/A", 1, "N/A" },
                    { 16, 3, "Tambourine 10-inch Meinl Nino", "2005", 1, "N/A" },
                    { 17, 3, "LP cowbell", "2006", 1, "N/A" },
                    { 18, 4, "Vic Firth SIH3 Isolation headphones", "N/A", 1, "N/A" },
                    { 19, 4, "Sennheiser HD 280 Pro headphones", "2025", 1, "N/A" },
                    { 20, 4, "Sterling MX5 monitor speakers pair", "2024", 1, "N/A" },
                    { 21, 4, "PreSonus Studio 1824c audio interface", "2024", 1, "SC4E24090030" },
                    { 22, 5, "On-Stage MS7920B Bass Drum/Boom Combo Mic Stand", "2024", 3, "N/A" },
                    { 23, 5, "JamStands JS-MSFB50 Low Profile Boom Mic Stand", "2024", 2, "N/A" },
                    { 24, 5, "K&M 21021 Extra Tall Boom Microphone Stand", "2024", 2, "N/A" },
                    { 25, 2, "Vocal pop filter", "2025", 1, "N/A" },
                    { 26, 3, "Ludwig Classic Series 1972 14x5 metal snare", "N/A", 1, "3019535" },
                    { 27, 3, "Ludwig maple snare 14x6.5", "2002", 1, "3390269" },
                    { 28, 3, "LP Vibra-slap", "2025", 1, "N/A" },
                    { 29, 3, "LP Sleigh Bells", "N/A", 1, "N/A" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Artist", "StatusId", "Title", "Writer", "YearRecorded" },
                values: new object[,]
                {
                    { 1, "Three Hit Combo", 2, "Emily", "Josh Tinley", 2026 },
                    { 2, "Three Hit Combo", 4, "Baby Don't Go (It's Christmas)", "Josh Tinley", 2025 },
                    { 3, "Three Hit Combo", 4, "Mary Had a Baby (and the Baby Was the Lord)", "Josh Tinley", 2025 },
                    { 4, "Three Hit Combo", 4, "Jolly Old St. Nick", "Josh Tinley", 2025 },
                    { 5, "Three Hit Combo", 1, "What I Worry", "Josh Tinley", 2025 },
                    { 6, "Three Hit Combo", 1, "The Black Hole in the Middle of the Galaxy", "Josh Tinley", 2026 },
                    { 7, "Three Hit Combo", 3, "Morning Fog (Nothing Left to Be)", "Josh Tinley", 2026 },
                    { 8, "Three Hit Combo", 2, "The Grief We've Earned", "Josh Tinley", 2025 },
                    { 9, "Three Hit Combo", 3, "Rewasher", "Josh Tinley", 2025 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IdentityUserId", "LastName", "UserName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "admina@strator.comx", "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator", "Administrator" },
                    { 2, "202 Oak Avenue", "ajohnson@signalchain.comx", "Andre", "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b", "Johnson", "ajohnson" },
                    { 3, "202 Oak Avenue", "rjohnson@signalchain.comx", "Rainbow", "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d", "Johnson", "rjohnson" }
                });

            migrationBuilder.InsertData(
                table: "GearSongs",
                columns: new[] { "Id", "GearId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 7, 1 },
                    { 7, 8, 1 },
                    { 8, 9, 1 },
                    { 9, 10, 1 },
                    { 10, 11, 1 },
                    { 11, 15, 1 },
                    { 12, 18, 1 },
                    { 13, 19, 1 },
                    { 14, 20, 1 },
                    { 15, 21, 1 },
                    { 16, 22, 1 },
                    { 17, 23, 1 },
                    { 18, 24, 1 },
                    { 19, 25, 1 },
                    { 20, 1, 2 },
                    { 21, 2, 2 },
                    { 22, 3, 2 },
                    { 23, 4, 2 },
                    { 24, 5, 2 },
                    { 25, 7, 2 },
                    { 26, 8, 2 },
                    { 27, 9, 2 },
                    { 28, 10, 2 },
                    { 29, 11, 2 },
                    { 30, 15, 2 },
                    { 31, 18, 2 },
                    { 32, 20, 2 },
                    { 33, 21, 2 },
                    { 34, 22, 2 },
                    { 35, 23, 2 },
                    { 36, 24, 2 },
                    { 37, 25, 2 },
                    { 38, 29, 2 },
                    { 39, 1, 3 },
                    { 40, 2, 3 },
                    { 41, 3, 3 },
                    { 42, 4, 3 },
                    { 43, 5, 3 },
                    { 44, 7, 3 },
                    { 45, 8, 3 },
                    { 46, 9, 3 },
                    { 47, 10, 3 },
                    { 49, 12, 3 },
                    { 50, 13, 3 },
                    { 51, 14, 3 },
                    { 52, 16, 3 },
                    { 53, 18, 3 },
                    { 54, 19, 3 },
                    { 55, 20, 3 },
                    { 56, 21, 3 },
                    { 57, 22, 3 },
                    { 58, 23, 3 },
                    { 59, 24, 3 },
                    { 60, 25, 3 },
                    { 61, 26, 3 },
                    { 62, 28, 3 },
                    { 63, 29, 3 },
                    { 64, 1, 4 },
                    { 65, 2, 4 },
                    { 66, 3, 4 },
                    { 67, 4, 4 },
                    { 68, 5, 4 },
                    { 69, 7, 4 },
                    { 70, 8, 4 },
                    { 71, 9, 4 },
                    { 72, 10, 4 },
                    { 73, 12, 4 },
                    { 74, 15, 4 },
                    { 75, 17, 4 },
                    { 76, 18, 4 },
                    { 77, 20, 4 },
                    { 78, 21, 4 },
                    { 79, 22, 4 },
                    { 80, 23, 4 },
                    { 81, 24, 4 },
                    { 82, 25, 4 },
                    { 83, 27, 4 },
                    { 84, 28, 4 },
                    { 85, 29, 4 },
                    { 86, 1, 5 },
                    { 87, 2, 5 },
                    { 88, 3, 5 },
                    { 89, 4, 5 },
                    { 90, 5, 5 },
                    { 91, 7, 5 },
                    { 92, 8, 5 },
                    { 93, 9, 5 },
                    { 94, 10, 5 },
                    { 95, 11, 5 },
                    { 96, 15, 5 },
                    { 97, 18, 5 },
                    { 98, 20, 5 },
                    { 99, 21, 5 },
                    { 100, 22, 5 },
                    { 101, 23, 5 },
                    { 102, 24, 5 },
                    { 103, 25, 5 },
                    { 104, 1, 6 },
                    { 105, 2, 6 },
                    { 106, 3, 6 },
                    { 107, 4, 6 },
                    { 108, 5, 6 },
                    { 109, 6, 6 },
                    { 110, 7, 6 },
                    { 111, 9, 6 },
                    { 112, 10, 6 },
                    { 113, 12, 6 },
                    { 114, 13, 6 },
                    { 115, 15, 6 },
                    { 116, 16, 6 },
                    { 117, 18, 6 },
                    { 118, 19, 6 },
                    { 119, 20, 6 },
                    { 120, 21, 6 },
                    { 121, 22, 6 },
                    { 122, 23, 6 },
                    { 123, 24, 6 },
                    { 124, 25, 6 },
                    { 125, 27, 6 },
                    { 126, 1, 7 },
                    { 127, 2, 7 },
                    { 128, 3, 7 },
                    { 129, 4, 7 },
                    { 130, 5, 7 },
                    { 131, 7, 7 },
                    { 132, 8, 7 },
                    { 133, 9, 7 },
                    { 134, 10, 7 },
                    { 135, 11, 7 },
                    { 136, 12, 7 },
                    { 137, 14, 7 },
                    { 138, 15, 7 },
                    { 139, 18, 7 },
                    { 140, 20, 7 },
                    { 141, 21, 7 },
                    { 142, 22, 7 },
                    { 143, 23, 7 },
                    { 144, 24, 7 },
                    { 145, 25, 7 },
                    { 146, 1, 8 },
                    { 147, 2, 8 },
                    { 148, 3, 8 },
                    { 149, 4, 8 },
                    { 150, 5, 8 },
                    { 151, 7, 8 },
                    { 152, 8, 8 },
                    { 153, 9, 8 },
                    { 154, 10, 8 },
                    { 155, 12, 8 },
                    { 156, 13, 8 },
                    { 157, 16, 8 },
                    { 158, 17, 8 },
                    { 159, 18, 8 },
                    { 160, 19, 8 },
                    { 161, 20, 8 },
                    { 162, 21, 8 },
                    { 163, 22, 8 },
                    { 164, 23, 8 },
                    { 165, 24, 8 },
                    { 166, 25, 8 },
                    { 167, 26, 8 },
                    { 168, 1, 9 },
                    { 169, 2, 9 },
                    { 170, 3, 9 },
                    { 171, 4, 9 },
                    { 172, 5, 9 },
                    { 173, 7, 9 },
                    { 174, 8, 9 },
                    { 175, 9, 9 },
                    { 176, 10, 9 },
                    { 177, 11, 9 },
                    { 178, 13, 9 },
                    { 179, 15, 9 },
                    { 180, 17, 9 },
                    { 181, 18, 9 },
                    { 182, 19, 9 },
                    { 183, 20, 9 },
                    { 184, 21, 9 },
                    { 185, 22, 9 },
                    { 186, 23, 9 },
                    { 187, 24, 9 },
                    { 188, 25, 9 },
                    { 189, 28, 9 },
                    { 190, 29, 9 }
                });

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
                name: "IX_Gears_GearTypeId",
                table: "Gears",
                column: "GearTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSongs_GearId",
                table: "GearSongs",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSongs_SongId",
                table: "GearSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_StatusId",
                table: "Songs",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
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
                name: "GearSongs");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GearTypes");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
