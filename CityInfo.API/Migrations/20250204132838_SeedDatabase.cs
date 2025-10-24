using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This category includes landmarks, monuments, and sites of historical significance such as museums, forts, ancient ruins, and heritage buildings.", "Historical Site" },
                    { 2, "Natural attractions encompass parks, gardens, beaches, mountains, lakes, waterfalls, and other scenic spots where visitors can enjoy nature and outdoor activities.", "Natural Attractions" },
                    { 3, "This category includes theaters, art galleries, performance venues, and cultural institutions where visitors can experience art, music, dance, theater, and other cultural events.", "Cultural Centers" },
                    { 4, "Dining establishments ranging from fine dining restaurants to casual eateries, cafes, food markets, and street food vendors offering a variety of cuisines and culinary experiences.", "Restaurants and Cafés" },
                    { 5, "Activities such as hiking trails, biking paths, water sports facilities, adventure parks, and recreational areas where visitors can engage in outdoor pursuits.", "Outdoor Activities" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name", "OfficialWebsite" },
                values: new object[,]
                {
                    { 1, "The one with that big park.", "New York City", null },
                    { 2, "The one with the cathedral that was never really finished.", "Antwerp", null },
                    { 3, "The one with that big tower.", "Paris", null }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The most visited urban park in the United States.", "Central Park" },
                    { 2, 1, "A 102-story skyscraper located in Midtown Manhattan.", "Empire State Building" },
                    { 3, 2, "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.", "Cathedral" },
                    { 4, 2, "The the finest example of railway architecture in Belgium.", "Antwerp Central Station" },
                    { 5, 3, "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel.", "Eiffel Tower" },
                    { 6, 3, "The world's largest museum.", "The Louvre" }
                });

            migrationBuilder.InsertData(
                table: "PointOfInterestCategories",
                columns: new[] { "Id", "CategoryId", "PointOfInterestId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 5, 1 },
                    { 3, 3, 2 },
                    { 4, 1, 3 },
                    { 5, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointOfInterestCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointOfInterestCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointOfInterestCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointOfInterestCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointOfInterestCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
