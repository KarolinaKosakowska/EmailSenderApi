using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailSenderApi.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mails_Reciver_ReciverID",
                table: "Mails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reciver",
                table: "Reciver");

            migrationBuilder.RenameTable(
                name: "Reciver",
                newName: "Recivers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recivers",
                table: "Recivers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mails_Recivers_ReciverID",
                table: "Mails",
                column: "ReciverID",
                principalTable: "Recivers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mails_Recivers_ReciverID",
                table: "Mails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recivers",
                table: "Recivers");

            migrationBuilder.RenameTable(
                name: "Recivers",
                newName: "Reciver");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reciver",
                table: "Reciver",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mails_Reciver_ReciverID",
                table: "Mails",
                column: "ReciverID",
                principalTable: "Reciver",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
