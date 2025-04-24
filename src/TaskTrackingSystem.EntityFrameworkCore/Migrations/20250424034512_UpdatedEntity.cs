using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTaskItems_AppProjects_ProjectId",
                table: "AppTaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AppTaskItems_AppProjects_ProjectId1",
                table: "AppTaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AppTimeLogs_AppTaskItems_TaskItemId",
                table: "AppTimeLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppTimeLogs_AppTaskItems_TaskItemId1",
                table: "AppTimeLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppTimeLogs",
                table: "AppTimeLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppTaskItems",
                table: "AppTaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppProjects",
                table: "AppProjects");

            migrationBuilder.RenameTable(
                name: "AppTimeLogs",
                newName: "TimeLogs");

            migrationBuilder.RenameTable(
                name: "AppTaskItems",
                newName: "TaskItems");

            migrationBuilder.RenameTable(
                name: "AppProjects",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_AppTimeLogs_TaskItemId1",
                table: "TimeLogs",
                newName: "IX_TimeLogs_TaskItemId1");

            migrationBuilder.RenameIndex(
                name: "IX_AppTimeLogs_TaskItemId",
                table: "TimeLogs",
                newName: "IX_TimeLogs_TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_AppTaskItems_ProjectId1",
                table: "TaskItems",
                newName: "IX_TaskItems_ProjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_AppTaskItems_ProjectId",
                table: "TaskItems",
                newName: "IX_TaskItems_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeLogs",
                table: "TimeLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskItems",
                table: "TaskItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Projects_ProjectId",
                table: "TaskItems",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Projects_ProjectId1",
                table: "TaskItems",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeLogs_TaskItems_TaskItemId",
                table: "TimeLogs",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeLogs_TaskItems_TaskItemId1",
                table: "TimeLogs",
                column: "TaskItemId1",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Projects_ProjectId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Projects_ProjectId1",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeLogs_TaskItems_TaskItemId",
                table: "TimeLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeLogs_TaskItems_TaskItemId1",
                table: "TimeLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeLogs",
                table: "TimeLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskItems",
                table: "TaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "TimeLogs",
                newName: "AppTimeLogs");

            migrationBuilder.RenameTable(
                name: "TaskItems",
                newName: "AppTaskItems");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "AppProjects");

            migrationBuilder.RenameIndex(
                name: "IX_TimeLogs_TaskItemId1",
                table: "AppTimeLogs",
                newName: "IX_AppTimeLogs_TaskItemId1");

            migrationBuilder.RenameIndex(
                name: "IX_TimeLogs_TaskItemId",
                table: "AppTimeLogs",
                newName: "IX_AppTimeLogs_TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_ProjectId1",
                table: "AppTaskItems",
                newName: "IX_AppTaskItems_ProjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_ProjectId",
                table: "AppTaskItems",
                newName: "IX_AppTaskItems_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppTimeLogs",
                table: "AppTimeLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppTaskItems",
                table: "AppTaskItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppProjects",
                table: "AppProjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTaskItems_AppProjects_ProjectId",
                table: "AppTaskItems",
                column: "ProjectId",
                principalTable: "AppProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppTaskItems_AppProjects_ProjectId1",
                table: "AppTaskItems",
                column: "ProjectId1",
                principalTable: "AppProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppTimeLogs_AppTaskItems_TaskItemId",
                table: "AppTimeLogs",
                column: "TaskItemId",
                principalTable: "AppTaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppTimeLogs_AppTaskItems_TaskItemId1",
                table: "AppTimeLogs",
                column: "TaskItemId1",
                principalTable: "AppTaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
