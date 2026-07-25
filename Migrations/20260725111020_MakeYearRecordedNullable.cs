using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalChain.Migrations
{
    /// <inheritdoc />
    public partial class MakeYearRecordedNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearRecorded",
                table: "Songs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16e2e1b1-3b9f-4f99-bf3e-64bbe3f0d392", "AQAAAAIAAYagAAAAEM8xnFYK6AGQ3NrQYdkOvz3gWcB/2Go+Rg03Ad9K4FxcGWloBEjWCmPa7cQdVdwNkQ==", "bc3089d7-b8ae-4088-8f4d-b58497f81f09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "457dda37-17bf-4794-8c49-4db2c55972da", "AQAAAAIAAYagAAAAEN/v0aAtUYBiyyDl7LUOmrsvoSLXmk6ngYmAC0YjeswqToyh+Vfpnu1Gr6ePntV3Kw==", "1dc8040d-e7f3-4da0-8c98-105c496c2dea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b5b3511-9c09-451a-8876-617683e4b333", "AQAAAAIAAYagAAAAEDP0yqdxqjAuC975ywj5+WWM8lHfZc4hFgWsskTzpsWBMuKoNcAPKACbLNMC8/pF5A==", "d7cacea5-f443-4152-b129-480e7bb1b7f0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearRecorded",
                table: "Songs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "512d139e-ba8a-4356-bdae-33bb8137bbc1", "AQAAAAIAAYagAAAAEKzX5ZcAe4aW1RqLG7d/CQ9olaS39qDI4w87syERtiCP9hyWxwNjPpSkJYIb5nSFgA==", "b9d27e03-ede6-479b-82d6-1ca196ef007c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddde2dce-746d-45fb-8c29-aa837c134b89", "AQAAAAIAAYagAAAAEJMKt/QTdaIHjOlSZUqcAbJw/T+bUT2dZXCznUebcQt2cK/kMOp/JPCPN3xK/PEGoQ==", "50b3ccee-a4a3-4d94-b8c9-9194311b0ec2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "378c862b-2fee-4d7b-bc54-8eaf4d6950bb", "AQAAAAIAAYagAAAAEPHuKi2yd3twxsfhO0FBRBw+HOOnve/2AXxtEIQ3gd+VhZw0XWDhjAaQFuDzxu8RSQ==", "6017731d-f6b1-47be-9566-1757fe7e6dda" });
        }
    }
}
