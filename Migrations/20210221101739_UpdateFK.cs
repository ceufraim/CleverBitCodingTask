using Microsoft.EntityFrameworkCore.Migrations;

namespace CleverBitCodingTask.Migrations
{
    public partial class UpdateFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameMatchParticipants_ParticipantId",
                table: "GameMatchParticipants");

            migrationBuilder.CreateIndex(
                name: "IX_GameMatchParticipants_ParticipantId",
                table: "GameMatchParticipants",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameMatchParticipants_ParticipantId",
                table: "GameMatchParticipants");

            migrationBuilder.CreateIndex(
                name: "IX_GameMatchParticipants_ParticipantId",
                table: "GameMatchParticipants",
                column: "ParticipantId",
                unique: true);
        }
    }
}
