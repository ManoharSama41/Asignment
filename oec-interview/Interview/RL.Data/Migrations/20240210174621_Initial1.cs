using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RL.Data.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PlanProcedures_PlanProcedurePlanId_PlanProcedureProcedureId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PlanProcedurePlanId_PlanProcedureProcedureId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlanProcedurePlanId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlanProcedureProcedureId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "PlanProcedureUser",
                columns: table => new
                {
                    AssignedUsersUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanProceduresPlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanProceduresProcedureId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanProcedureUser", x => new { x.AssignedUsersUserId, x.PlanProceduresPlanId, x.PlanProceduresProcedureId });
                    table.ForeignKey(
                        name: "FK_PlanProcedureUser_PlanProcedures_PlanProceduresPlanId_PlanProceduresProcedureId",
                        columns: x => new { x.PlanProceduresPlanId, x.PlanProceduresProcedureId },
                        principalTable: "PlanProcedures",
                        principalColumns: new[] { "PlanId", "ProcedureId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanProcedureUser_Users_AssignedUsersUserId",
                        column: x => x.AssignedUsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanProcedureUser_PlanProceduresPlanId_PlanProceduresProcedureId",
                table: "PlanProcedureUser",
                columns: new[] { "PlanProceduresPlanId", "PlanProceduresProcedureId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanProcedureUser");

            migrationBuilder.AddColumn<int>(
                name: "PlanProcedurePlanId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanProcedureProcedureId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlanProcedurePlanId_PlanProcedureProcedureId",
                table: "Users",
                columns: new[] { "PlanProcedurePlanId", "PlanProcedureProcedureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PlanProcedures_PlanProcedurePlanId_PlanProcedureProcedureId",
                table: "Users",
                columns: new[] { "PlanProcedurePlanId", "PlanProcedureProcedureId" },
                principalTable: "PlanProcedures",
                principalColumns: new[] { "PlanId", "ProcedureId" });
        }
    }
}
