using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOT.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    PostalCode = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.PostalCode);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassificationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Classification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    LocationPostalCode = table.Column<long>(type: "bigint", nullable: false),
                    MemberSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberUntil = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Location_LocationPostalCode",
                        column: x => x.LocationPostalCode,
                        principalTable: "Location",
                        principalColumn: "PostalCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeciesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bird",
                columns: table => new
                {
                    RingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RingingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RingingLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassificationId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    RingerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bird", x => x.RingId);
                    table.ForeignKey(
                        name: "FK_Bird_Classification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bird_Member_RingerId",
                        column: x => x.RingerId,
                        principalTable: "Member",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subclass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubclassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subclass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subclass_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Watching",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirdRingId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watching", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watching_Bird_BirdRingId",
                        column: x => x.BirdRingId,
                        principalTable: "Bird",
                        principalColumn: "RingId");
                    table.ForeignKey(
                        name: "FK_Watching_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tribe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TribeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubclassId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tribe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tribe_Subclass_SubclassId",
                        column: x => x.SubclassId,
                        principalTable: "Subclass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bird_ClassificationId",
                table: "Bird",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bird_RingerId",
                table: "Bird",
                column: "RingerId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_SpeciesId",
                table: "Class",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_LocationPostalCode",
                table: "Member",
                column: "LocationPostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Species_ClassificationId",
                table: "Species",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Subclass_ClassId",
                table: "Subclass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Tribe_SubclassId",
                table: "Tribe",
                column: "SubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_Watching_BirdRingId",
                table: "Watching",
                column: "BirdRingId");

            migrationBuilder.CreateIndex(
                name: "IX_Watching_MemberId",
                table: "Watching",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tribe");

            migrationBuilder.DropTable(
                name: "Watching");

            migrationBuilder.DropTable(
                name: "Subclass");

            migrationBuilder.DropTable(
                name: "Bird");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Classification");
        }
    }
}
