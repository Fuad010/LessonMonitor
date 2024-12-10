using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class UpdatePricePerDayPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_GithubAccounts_GithubAccountMemberId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_GithubAccountMemberId",
                table: "Members");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_GithubAccounts_MemberId",
                table: "GithubAccounts");

            migrationBuilder.DropColumn(
                name: "GithubAccountMemberId",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeAccountId",
                table: "Members",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkMember",
                columns: table => new
                {
                    HomeworksId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkMember", x => new { x.HomeworksId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_HomeworkMember_Homeworks_HomeworksId",
                        column: x => x.HomeworksId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GithubAccounts_MemberId",
                table: "GithubAccounts",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkMember_MembersId",
                table: "HomeworkMember",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_GithubAccounts_Members_MemberId",
                table: "GithubAccounts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GithubAccounts_Members_MemberId",
                table: "GithubAccounts");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "HomeworkMember");

            migrationBuilder.DropIndex(
                name: "IX_GithubAccounts_MemberId",
                table: "GithubAccounts");

            migrationBuilder.DropColumn(
                name: "YoutubeAccountId",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "GithubAccountMemberId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_GithubAccounts_MemberId",
                table: "GithubAccounts",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GithubAccountMemberId",
                table: "Members",
                column: "GithubAccountMemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_GithubAccounts_GithubAccountMemberId",
                table: "Members",
                column: "GithubAccountMemberId",
                principalTable: "GithubAccounts",
                principalColumn: "MemberId");
        }
    }
}
