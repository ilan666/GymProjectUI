using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProjectUI.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminDBID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminDBID);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Plan_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Plan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Plan_ID);
                });

            migrationBuilder.CreateTable(
                name: "AdminMessages",
                columns: table => new
                {
                    Message_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _From_ID = table.Column<int>(type: "int", nullable: false),
                    _To_ID = table.Column<int>(type: "int", nullable: false),
                    AdminsAdminDBID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMessages", x => x.Message_ID);
                    table.ForeignKey(
                        name: "FK_AdminMessages_Admins_AdminsAdminDBID",
                        column: x => x.AdminsAdminDBID,
                        principalTable: "Admins",
                        principalColumn: "AdminDBID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserDBID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    _Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminDBID = table.Column<int>(type: "int", nullable: false),
                    AdminDBID1 = table.Column<int>(type: "int", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plan_ID = table.Column<int>(type: "int", nullable: false),
                    Plan_ID1 = table.Column<int>(type: "int", nullable: true),
                    PlanExpiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserDBID);
                    table.ForeignKey(
                        name: "FK_Users_Admins_AdminDBID1",
                        column: x => x.AdminDBID1,
                        principalTable: "Admins",
                        principalColumn: "AdminDBID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Plans_Plan_ID1",
                        column: x => x.Plan_ID1,
                        principalTable: "Plans",
                        principalColumn: "Plan_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDBID = table.Column<int>(type: "int", nullable: false),
                    UserDBID1 = table.Column<int>(type: "int", nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Users_UserDBID1",
                        column: x => x.UserDBID1,
                        principalTable: "Users",
                        principalColumn: "UserDBID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersCalendar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDBID = table.Column<int>(type: "int", nullable: false),
                    UserDBID1 = table.Column<int>(type: "int", nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCalendar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersCalendar_Users_UserDBID1",
                        column: x => x.UserDBID1,
                        principalTable: "Users",
                        principalColumn: "UserDBID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminMessages_AdminsAdminDBID",
                table: "AdminMessages",
                column: "AdminsAdminDBID");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserDBID1",
                table: "UserNotifications",
                column: "UserDBID1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminDBID1",
                table: "Users",
                column: "AdminDBID1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Plan_ID1",
                table: "Users",
                column: "Plan_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCalendar_UserDBID1",
                table: "UsersCalendar",
                column: "UserDBID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMessages");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "UsersCalendar");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}
