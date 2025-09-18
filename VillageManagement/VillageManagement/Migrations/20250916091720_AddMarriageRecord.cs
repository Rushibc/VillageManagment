using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillageManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddMarriageRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarriageRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrideName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarriageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfMarriage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Witnesses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarriageRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarriageRecords");
        }
    }
}
