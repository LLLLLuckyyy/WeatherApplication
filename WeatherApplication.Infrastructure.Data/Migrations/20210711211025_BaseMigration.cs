using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApplication.Infrastructure.Data.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: false),
                    NumberOfAllowedStatisticalModels = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatisticalModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxTemperature = table.Column<double>(nullable: false),
                    MinTemperature = table.Column<double>(nullable: false),
                    AverageTemperature = table.Column<double>(nullable: false),
                    CurrentTemperature = table.Column<string>(nullable: false),
                    MaxRainProbability = table.Column<double>(nullable: false),
                    MinRainProbability = table.Column<double>(nullable: false),
                    AverageRainProbability = table.Column<double>(nullable: false),
                    CurrentRainProbability = table.Column<string>(nullable: false),
                    MaxWindForce = table.Column<double>(nullable: false),
                    MinWindForce = table.Column<double>(nullable: false),
                    AverageWindForce = table.Column<double>(nullable: false),
                    CurrentWindForce = table.Column<string>(nullable: false),
                    DateStatisticsCreated = table.Column<DateTime>(nullable: false),
                    CityModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticalModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticalModels_CityModels_CityModelId",
                        column: x => x.CityModelId,
                        principalTable: "CityModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(nullable: false),
                    RainProbability = table.Column<double>(nullable: false),
                    WindForce = table.Column<double>(nullable: false),
                    ObservationTime = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    CityModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherModels_CityModels_CityModelId",
                        column: x => x.CityModelId,
                        principalTable: "CityModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatisticalModels_CityModelId",
                table: "StatisticalModels",
                column: "CityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherModels_CityModelId",
                table: "WeatherModels",
                column: "CityModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatisticalModels");

            migrationBuilder.DropTable(
                name: "WeatherModels");

            migrationBuilder.DropTable(
                name: "CityModels");
        }
    }
}
