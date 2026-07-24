using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalChain.Migrations
{
    /// <inheritdoc />
    public partial class AddSongsStatusRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c61ff349-92b5-47c5-9867-3f2dd5775449", "AQAAAAIAAYagAAAAEIe4/B8SiUWHte/KTUyRThu20766KVFxjM2/0zhudgJFkODs49hGIVFTDxdtb818SQ==", "2e8db894-3ef7-4f26-9ce8-c869042acc87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce5f8314-f1e4-4681-8ea5-d95a42e855ed", "AQAAAAIAAYagAAAAEDqVumm2dd+6WcyOm8Y5vLk05sX4EzogPtPNZv6q0pSIbSy7HnWHvQUL88hj+Pf4BA==", "f689a41e-686b-4385-8ec6-627371165bb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6773a00b-f923-464d-bf02-63f47dd374d4", "AQAAAAIAAYagAAAAEBk3HkqHsUPsRWBHEW73mSrfCtxMKlqRNmJetQa33ujhTyj+OPyKacOBYlKwosPhsg==", "13ffa87f-38a3-4050-94bb-04b546c63e10" });
        }
    }
}
