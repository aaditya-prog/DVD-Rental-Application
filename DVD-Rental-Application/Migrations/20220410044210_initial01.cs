using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVD_Rental_Application.Migrations
{
    public partial class initial01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    ActorNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorSurname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.ActorNumber);
                });

            migrationBuilder.CreateTable(
                name: "dvdcategories",
                columns: table => new
                {
                    CategoryNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRestricted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dvdcategories", x => x.CategoryNumber);
                });

            migrationBuilder.CreateTable(
                name: "loantypes",
                columns: table => new
                {
                    LoanTypeNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfLoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanDuration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loantypes", x => x.LoanTypeNumber);
                });

            migrationBuilder.CreateTable(
                name: "membershipcategories",
                columns: table => new
                {
                    MembershipCategoryNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipCategoryTotalLoans = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membershipcategories", x => x.MembershipCategoryNumber);
                });

            migrationBuilder.CreateTable(
                name: "producers",
                columns: table => new
                {
                    ProducerNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producers", x => x.ProducerNumber);
                });

            migrationBuilder.CreateTable(
                name: "studios",
                columns: table => new
                {
                    StudioNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudioName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studios", x => x.StudioNumber);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserNumber);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    MemberNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipCategoryNumber = table.Column<int>(type: "int", nullable: false),
                    MemberFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberDateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.MemberNumber);
                    table.ForeignKey(
                        name: "FK_members_membershipcategories_MembershipCategoryNumber",
                        column: x => x.MembershipCategoryNumber,
                        principalTable: "membershipcategories",
                        principalColumn: "MembershipCategoryNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dvdtitles",
                columns: table => new
                {
                    DVDNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerNumber = table.Column<int>(type: "int", nullable: false),
                    CategoryNumber = table.Column<int>(type: "int", nullable: false),
                    StudioNumber = table.Column<int>(type: "int", nullable: false),
                    DateReleased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StandardCharge = table.Column<double>(type: "float", nullable: false),
                    PenaltyCharge = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dvdtitles", x => x.DVDNumber);
                    table.ForeignKey(
                        name: "FK_dvdtitles_dvdcategories_CategoryNumber",
                        column: x => x.CategoryNumber,
                        principalTable: "dvdcategories",
                        principalColumn: "CategoryNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dvdtitles_producers_ProducerNumber",
                        column: x => x.ProducerNumber,
                        principalTable: "producers",
                        principalColumn: "ProducerNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dvdtitles_studios_StudioNumber",
                        column: x => x.StudioNumber,
                        principalTable: "studios",
                        principalColumn: "StudioNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "castmembers",
                columns: table => new
                {
                    DVDNumber = table.Column<int>(type: "int", nullable: false),
                    ActorNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_castmembers_actors_ActorNumber",
                        column: x => x.ActorNumber,
                        principalTable: "actors",
                        principalColumn: "ActorNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_castmembers_dvdtitles_DVDNumber",
                        column: x => x.DVDNumber,
                        principalTable: "dvdtitles",
                        principalColumn: "DVDNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dvdcopies",
                columns: table => new
                {
                    CopyNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DVDNumber = table.Column<int>(type: "int", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dvdcopies", x => x.CopyNumber);
                    table.ForeignKey(
                        name: "FK_dvdcopies_dvdtitles_DVDNumber",
                        column: x => x.DVDNumber,
                        principalTable: "dvdtitles",
                        principalColumn: "DVDNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    LoanNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeNumber = table.Column<int>(type: "int", nullable: false),
                    CopyNumber = table.Column<int>(type: "int", nullable: false),
                    MemberNumber = table.Column<int>(type: "int", nullable: false),
                    DateOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReturned = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.LoanNumber);
                    table.ForeignKey(
                        name: "FK_loans_dvdcopies_CopyNumber",
                        column: x => x.CopyNumber,
                        principalTable: "dvdcopies",
                        principalColumn: "CopyNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_loans_loantypes_LoanTypeNumber",
                        column: x => x.LoanTypeNumber,
                        principalTable: "loantypes",
                        principalColumn: "LoanTypeNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_loans_members_MemberNumber",
                        column: x => x.MemberNumber,
                        principalTable: "members",
                        principalColumn: "MemberNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_castmembers_ActorNumber",
                table: "castmembers",
                column: "ActorNumber");

            migrationBuilder.CreateIndex(
                name: "IX_castmembers_DVDNumber",
                table: "castmembers",
                column: "DVDNumber");

            migrationBuilder.CreateIndex(
                name: "IX_dvdcopies_DVDNumber",
                table: "dvdcopies",
                column: "DVDNumber");

            migrationBuilder.CreateIndex(
                name: "IX_dvdtitles_CategoryNumber",
                table: "dvdtitles",
                column: "CategoryNumber");

            migrationBuilder.CreateIndex(
                name: "IX_dvdtitles_ProducerNumber",
                table: "dvdtitles",
                column: "ProducerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_dvdtitles_StudioNumber",
                table: "dvdtitles",
                column: "StudioNumber");

            migrationBuilder.CreateIndex(
                name: "IX_loans_CopyNumber",
                table: "loans",
                column: "CopyNumber");

            migrationBuilder.CreateIndex(
                name: "IX_loans_LoanTypeNumber",
                table: "loans",
                column: "LoanTypeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_loans_MemberNumber",
                table: "loans",
                column: "MemberNumber");

            migrationBuilder.CreateIndex(
                name: "IX_members_MembershipCategoryNumber",
                table: "members",
                column: "MembershipCategoryNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "castmembers");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "actors");

            migrationBuilder.DropTable(
                name: "dvdcopies");

            migrationBuilder.DropTable(
                name: "loantypes");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "dvdtitles");

            migrationBuilder.DropTable(
                name: "membershipcategories");

            migrationBuilder.DropTable(
                name: "dvdcategories");

            migrationBuilder.DropTable(
                name: "producers");

            migrationBuilder.DropTable(
                name: "studios");
        }
    }
}
