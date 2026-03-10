using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PokemonBlog.Migrations
{
    /// <inheritdoc />
    public partial class LatestDbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendShip_Status_StatusId",
                table: "FriendShip");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendShip_Users_RecieverId",
                table: "FriendShip");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendShip_Users_SenderId",
                table: "FriendShip");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendShip",
                table: "FriendShip");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "DeckLists");

            migrationBuilder.RenameTable(
                name: "FriendShip",
                newName: "FriendShips");

            migrationBuilder.RenameColumn(
                name: "ListDescription",
                table: "DeckLists",
                newName: "URL");

            migrationBuilder.RenameIndex(
                name: "IX_FriendShip_StatusId",
                table: "FriendShips",
                newName: "IX_FriendShips_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendShip_SenderId",
                table: "FriendShips",
                newName: "IX_FriendShips_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendShip_RecieverId",
                table: "FriendShips",
                newName: "IX_FriendShips_RecieverId");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfComments",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendShips",
                table: "FriendShips",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendShips_Users_RecieverId",
                table: "FriendShips",
                column: "RecieverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendShips_Users_SenderId",
                table: "FriendShips",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendShips_statuses_StatusId",
                table: "FriendShips",
                column: "StatusId",
                principalTable: "statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendShips_Users_RecieverId",
                table: "FriendShips");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendShips_Users_SenderId",
                table: "FriendShips");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendShips_statuses_StatusId",
                table: "FriendShips");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendShips",
                table: "FriendShips");

            migrationBuilder.DropColumn(
                name: "NumberOfComments",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "FriendShips",
                newName: "FriendShip");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "DeckLists",
                newName: "ListDescription");

            migrationBuilder.RenameIndex(
                name: "IX_FriendShips_StatusId",
                table: "FriendShip",
                newName: "IX_FriendShip_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendShips_SenderId",
                table: "FriendShip",
                newName: "IX_FriendShip_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendShips_RecieverId",
                table: "FriendShip",
                newName: "IX_FriendShip_RecieverId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "DeckLists",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendShip",
                table: "FriendShip",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FriendShip_Status_StatusId",
                table: "FriendShip",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendShip_Users_RecieverId",
                table: "FriendShip",
                column: "RecieverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendShip_Users_SenderId",
                table: "FriendShip",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
