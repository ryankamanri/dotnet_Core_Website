using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "File",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FileName = table.Column<string>(nullable: false),
            //        Length = table.Column<string>(nullable: false),
            //        LastWriteTime = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_File", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Post",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Sender = table.Column<string>(nullable: false),
            //        Password = table.Column<string>(nullable: false),
            //        Title = table.Column<string>(nullable: false),
            //        CoTitle = table.Column<string>(nullable: false),
            //        Text = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Post", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Comment",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostID = table.Column<int>(nullable: false),
            //        Content = table.Column<string>(nullable: false),
            //        Commentator = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comment", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Comment_Post_PostID",
            //            column: x => x.PostID,
            //            principalTable: "Post",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comment_PostID",
            //    table: "Comment",
            //    column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
