using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrueVote.Web.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoteOptionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionKey = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteOptionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoteOptionDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivedVotes_VoteOptionDetails_Id",
                        column: x => x.Id,
                        principalTable: "VoteOptionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedVotes_Id",
                table: "ReceivedVotes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VoteOptionDetails_Id",
                table: "VoteOptionDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VoteOptionDetails_OptionKey",
                table: "VoteOptionDetails",
                column: "OptionKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivedVotes");

            migrationBuilder.DropTable(
                name: "VoteOptionDetails");
        }
    }
}
