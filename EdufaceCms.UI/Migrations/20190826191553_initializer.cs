using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdufaceCms.UI.Migrations
{
    public partial class initializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreRegister",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    CreDate = table.Column<DateTime>(nullable: false),
                    ModDate = table.Column<DateTime>(nullable: false),
                    ModUser = table.Column<string>(maxLength: 30, nullable: true),
                    CreUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    InterviewPerson = table.Column<string>(nullable: false),
                    InterviewDate = table.Column<string>(nullable: false),
                    CellPhone = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AppointmentDate = table.Column<string>(nullable: false),
                    GivenPrice = table.Column<decimal>(nullable: false),
                    EstimatedPrice = table.Column<decimal>(nullable: false),
                    Not = table.Column<string>(maxLength: 500, nullable: false),
                    IsRegister = table.Column<bool>(nullable: false),
                    DataQualityId = table.Column<int>(nullable: false),
                    DataSourceId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    TimeId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreRegister_AspNetUsers_CreUserId",
                        column: x => x.CreUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreRegister_DataQuality_DataQualityId",
                        column: x => x.DataQualityId,
                        principalTable: "DataQuality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreRegister_DataSource_DataSourceId",
                        column: x => x.DataSourceId,
                        principalTable: "DataSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreRegister_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreRegister_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreRegister_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreRegister_CreUserId",
                table: "PreRegister",
                column: "CreUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PreRegister_DataQualityId",
                table: "PreRegister",
                column: "DataQualityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreRegister_DataSourceId",
                table: "PreRegister",
                column: "DataSourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreRegister_LevelId",
                table: "PreRegister",
                column: "LevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreRegister_PaymentTypeId",
                table: "PreRegister",
                column: "PaymentTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreRegister_TimeId",
                table: "PreRegister",
                column: "TimeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreRegister");
        }
    }
}
