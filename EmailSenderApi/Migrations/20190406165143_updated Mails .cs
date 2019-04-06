using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailSenderApi.Migrations
{
    public partial class updatedMails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mails_Recivers_ReciverID",
                table: "Mails");

            migrationBuilder.DropIndex(
                name: "IX_Mails_ReciverID",
                table: "Mails");

            migrationBuilder.DropColumn(
                name: "ReciverID",
                table: "Mails");

            migrationBuilder.RenameColumn(
                name: "MailTo",
                table: "Recivers",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "MailFrom",
                table: "Mails",
                newName: "To");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Mails",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Mails");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Recivers",
                newName: "MailTo");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Mails",
                newName: "MailFrom");

            migrationBuilder.AddColumn<int>(
                name: "ReciverID",
                table: "Mails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mails_ReciverID",
                table: "Mails",
                column: "ReciverID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mails_Recivers_ReciverID",
                table: "Mails",
                column: "ReciverID",
                principalTable: "Recivers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
