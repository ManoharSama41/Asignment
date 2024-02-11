using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RL.Data.Migrations
{
    public partial class Initial0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
