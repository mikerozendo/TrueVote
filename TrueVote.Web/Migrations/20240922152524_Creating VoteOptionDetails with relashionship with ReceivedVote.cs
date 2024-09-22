using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrueVote.Web.Migrations
{
    /// <inheritdoc />
    public partial class CreatingVoteOptionDetailswithrelashionshipwithReceivedVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoteOptionDetails",
                columns: table => new
                {
                    OptionKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteOptionDetails", x => x.OptionKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteOptionDetails_OptionKey",
                table: "VoteOptionDetails",
                column: "OptionKey");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteOptions_VoteOptionDetails_OptionKey",
                table: "VoteOptions",
                column: "OptionKey",
                principalTable: "VoteOptionDetails",
                principalColumn: "OptionKey",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteOptions_VoteOptionDetails_OptionKey",
                table: "VoteOptions");

            migrationBuilder.DropTable(
                name: "VoteOptionDetails");
        }
    }
}
