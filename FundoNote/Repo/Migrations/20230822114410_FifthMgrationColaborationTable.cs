using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repo.Migrations
{
    public partial class FifthMgrationColaborationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RemindMe",
                table: "Notes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Colab",
                columns: table => new
                {
                    ColabId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    userId = table.Column<long>(nullable: false),
                    NoteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colab", x => x.ColabId);
                    table.ForeignKey(
                        name: "FK_Colab_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Colab_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colab_NoteId",
                table: "Colab",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Colab_userId",
                table: "Colab",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colab");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemindMe",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
