using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Contracts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_Accounts_AccountId",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_AccountId",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AccountId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "UserOperationClaims");

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountContracts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountContracts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 21, 142, 49, 128, 244, 23, 23, 91, 202, 188, 38, 59, 68, 160, 79, 189, 98, 191, 239, 28, 219, 128, 176, 92, 127, 172, 138, 187, 90, 117, 107, 34, 106, 204, 205, 241, 28, 77, 16, 99, 35, 173, 59, 138, 255, 161, 191, 237, 166, 117, 76, 200, 91, 153, 133, 27, 52, 234, 182, 184, 104, 201, 13 }, new byte[] { 66, 8, 233, 90, 89, 36, 218, 206, 65, 177, 127, 107, 140, 72, 230, 178, 183, 44, 2, 39, 43, 145, 147, 236, 11, 131, 170, 211, 242, 62, 87, 155, 44, 122, 142, 83, 63, 246, 19, 243, 51, 30, 181, 155, 103, 210, 49, 207, 179, 85, 196, 251, 9, 228, 141, 216, 180, 77, 248, 157, 178, 152, 61, 234, 241, 191, 11, 181, 171, 73, 193, 236, 30, 73, 141, 54, 254, 211, 142, 19, 124, 44, 86, 70, 112, 21, 161, 240, 139, 118, 73, 63, 127, 177, 24, 28, 153, 107, 60, 224, 225, 16, 232, 26, 102, 19, 163, 216, 27, 228, 4, 106, 228, 236, 172, 131, 192, 192, 62, 219, 101, 117, 100, 28, 127, 37, 22, 66 } });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AccountId",
                table: "Addresses",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContracts_AccountId",
                table: "AccountContracts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContracts_ContractId",
                table: "AccountContracts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountContracts");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AccountId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "UserOperationClaims",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 123, 237, 99, 173, 254, 140, 109, 47, 75, 207, 21, 71, 143, 60, 42, 79, 8, 236, 248, 253, 84, 79, 52, 112, 107, 26, 182, 195, 150, 21, 166, 50, 35, 71, 132, 10, 196, 130, 193, 212, 201, 169, 196, 68, 235, 172, 202, 99, 69, 38, 242, 46, 162, 57, 182, 74, 83, 42, 57, 117, 57, 23, 138 }, new byte[] { 67, 113, 85, 71, 187, 51, 87, 107, 97, 165, 75, 105, 169, 93, 188, 249, 40, 96, 152, 209, 128, 9, 20, 105, 51, 206, 185, 30, 16, 198, 225, 165, 159, 150, 173, 224, 148, 109, 66, 248, 207, 144, 254, 125, 25, 234, 118, 23, 58, 192, 169, 138, 229, 248, 195, 199, 52, 117, 205, 31, 3, 192, 42, 49, 135, 134, 176, 44, 159, 80, 50, 51, 212, 28, 241, 142, 3, 20, 192, 143, 49, 51, 216, 47, 99, 113, 114, 227, 150, 231, 214, 233, 123, 202, 214, 102, 165, 79, 30, 205, 206, 244, 58, 17, 159, 152, 109, 209, 28, 39, 180, 226, 100, 210, 90, 17, 212, 255, 207, 169, 11, 141, 61, 184, 125, 162, 246, 226 } });

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_AccountId",
                table: "UserOperationClaims",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AccountId",
                table: "Addresses",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_Accounts_AccountId",
                table: "UserOperationClaims",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
