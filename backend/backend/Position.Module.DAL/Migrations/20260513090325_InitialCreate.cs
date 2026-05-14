using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Position.Module.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypePosads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    NameFull = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Category = table.Column<short>(type: "smallint", nullable: false),
                    NameTbl1C8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentForTabel = table.Column<short>(type: "smallint", nullable: true),
                    Active_AD = table.Column<bool>(type: "bit", nullable: false),
                    Active_BOS = table.Column<bool>(type: "bit", nullable: false),
                    CheckDnVidp = table.Column<bool>(type: "bit", nullable: false),
                    LogLinPers = table.Column<bool>(type: "bit", nullable: false),
                    TrUtrPodatk = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePosads", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypePosads");
        }
    }
}
