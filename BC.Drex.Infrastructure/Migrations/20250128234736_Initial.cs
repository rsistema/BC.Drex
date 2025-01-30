using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BC.Drex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransferLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FromWalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToWalletId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransferLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Changed", "Created", "Deleted", "Email", "Name", "Password" },
                values: new object[] { new Guid("0ffa140f-f66e-4c7c-b9dd-5e9eb32f4430"), new DateTime(2025, 1, 28, 23, 47, 35, 866, DateTimeKind.Utc).AddTicks(2372), new DateTime(2025, 1, 28, 23, 47, 35, 866, DateTimeKind.Utc).AddTicks(2367), null, "admin@bc.com", "admin", "$2a$11$JVno08MUGtByvXXuzO3xuO.5JLUkp3RrCqYdvUuQVXqmSSHZf9.5q" });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Active", "Amount", "UserId" },
                values: new object[] { new Guid("378edd6a-71a0-40ef-9e9f-135a70bb5f7f"), true, 5000m, new Guid("0ffa140f-f66e-4c7c-b9dd-5e9eb32f4430") });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "WalletTransferLogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
