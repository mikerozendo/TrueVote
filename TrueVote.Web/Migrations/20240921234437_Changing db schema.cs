using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrueVote.Web.Migrations
{
    /// <inheritdoc />
    public partial class Changingdbschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteOptions_Surveys_SurveyId",
                table: "VoteOptions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_VoteOptions_SurveyId",
                table: "VoteOptions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "VoteOptions");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "VoteOptions");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "VoteOptions");

            migrationBuilder.RenameColumn(
                name: "ReceivedVotes",
                table: "VoteOptions",
                newName: "OptionKey");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "VoteOptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_VoteOptions_OptionKey",
                table: "VoteOptions",
                column: "OptionKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VoteOptions_OptionKey",
                table: "VoteOptions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VoteOptions");

            migrationBuilder.RenameColumn(
                name: "OptionKey",
                table: "VoteOptions",
                newName: "ReceivedVotes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "VoteOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "VoteOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "VoteOptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteOptions_SurveyId",
                table: "VoteOptions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_Id",
                table: "Surveys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteOptions_Surveys_SurveyId",
                table: "VoteOptions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
