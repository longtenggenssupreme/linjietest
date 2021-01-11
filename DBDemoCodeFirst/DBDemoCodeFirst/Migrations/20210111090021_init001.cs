using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBDemoCodeFirst.Migrations
{
    public partial class init001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ParentCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CategoryLevel = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    State = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    LastModifierId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_001",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_001", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_002",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_002", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_003",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_003", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_004",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_004", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_005",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_005", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_006",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_006", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_007",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_007", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_008",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_008", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_009",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_009", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_010",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_010", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_011",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_011", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_012",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_012", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_013",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_013", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_014",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_014", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_015",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_015", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_016",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_016", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_017",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_017", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_018",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_018", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_019",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_019", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_020",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_020", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_021",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_021", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_022",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_022", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_023",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_023", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_024",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_024", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_025",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_025", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_026",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_026", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_027",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_027", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_028",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_028", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_029",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_029", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JD_Commodity_030",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JD_Commodity_030", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, comment: "操作者名称，没有就写系统生成"),
                    Introduction = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "简介"),
                    Detail = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "详细信息"),
                    LogType = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))", comment: "操作类型：0信息操作，1 登陆退出\r\n   2 增\r\n   3 删\r\n   4 改\r\n   5 启用禁用\r\n   6 申请/审核通过/拒绝\r\n   7 导入导出\r\n   8 上传下载\r\n   100 其他"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "添加时间"),
                    CreatorId = table.Column<int>(type: "int", nullable: false, comment: "操作用户"),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间"),
                    LastModifierId = table.Column<int>(type: "int", nullable: true, comment: "修改用户")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysLog", x => x.Id);
                },
                comment: "系统日志表");

            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "编号")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false, comment: "上级菜单：根目录id为0"),
                    Text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "菜单名称"),
                    Url = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true, comment: "链接地址"),
                    MenuLevel = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))", comment: "菜单等级"),
                    MenuType = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))", comment: "类型：1 菜单 2 按钮"),
                    MenuIcon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "菜单图标"),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "说明"),
                    SourcePath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true, comment: "菜单路径：parentpath/guid\r\n   一级菜单为 root/guid"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序值"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "状态：0  正常  1 冻结  2 删除"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "添加时间"),
                    CreatorId = table.Column<int>(type: "int", nullable: false, comment: "添加用户"),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间"),
                    LastModifierId = table.Column<int>(type: "int", nullable: true, comment: "修改用户")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                },
                comment: "管理后台菜单表");

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "状态：0  正常  1 冻结  2 删除"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: false),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                },
                comment: "管理后台用户角色表");

            migrationBuilder.CreateTable(
                name: "SysRoleMenuMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "编号")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysRoleId = table.Column<int>(type: "int", nullable: false, comment: "角色Id"),
                    SysMenuId = table.Column<int>(type: "int", nullable: false, comment: "菜单Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleMenuMapping", x => x.Id);
                },
                comment: "角色和菜单映射表，一个角色对应多菜单   一个菜单多个角色");

            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "编号")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "用户名"),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "密码"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "用户状态"),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "联系电话"),
                    Mobile = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "手机号"),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "联系地址"),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "联系邮箱"),
                    QQ = table.Column<long>(type: "bigint", nullable: true, comment: "联系QQ"),
                    WeChat = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "微信号"),
                    Sex = table.Column<byte>(type: "tinyint", nullable: true, comment: "性别  0男 1女"),
                    LastLoginTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "最后登陆时间"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "添加时间"),
                    CreateId = table.Column<int>(type: "int", nullable: false, comment: "添加用户"),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间"),
                    LastModifyId = table.Column<int>(type: "int", nullable: true, comment: "修改用户")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.Id);
                },
                comment: "后台管理员表");

            migrationBuilder.CreateTable(
                name: "SysUserMenuMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysUserId = table.Column<int>(type: "int", nullable: false),
                    SysMenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserMenuMapping", x => x.Id);
                },
                comment: "用户和菜单映射表,额外补充用户权限\r\n   一个用户对应多菜单   一个菜单多个角色");

            migrationBuilder.CreateTable(
                name: "SysUserRoleMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "编号")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SysUserId = table.Column<int>(type: "int", nullable: false, comment: "用户Id"),
                    SysRoleId = table.Column<int>(type: "int", nullable: false, comment: "角色Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserRoleMapping", x => x.Id);
                },
                comment: "用户和角色映射表，一个用户可能多个角色，一个角色多个用户");

            migrationBuilder.CreateTable(
                name: "WPFClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Teacher = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WPFClass", x => x.Id);
                },
                comment: "WPFClass");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Account = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Mobile = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    State = table.Column<int>(type: "int", nullable: false, comment: "用户状态  0正常 1冻结 2删除"),
                    UserType = table.Column<int>(type: "int", nullable: false, comment: "用户类型  1 普通用户 2管理员 4超级管理员"),
                    LastLoginTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    LastModifierId = table.Column<int>(type: "int", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STUDENT_REFERENCE_WPFCLASS",
                        column: x => x.Id,
                        principalTable: "WPFClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "记录WPF班的VIP学员");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "NonClusteredIndex-20210104-213253",
                table: "WPFClass",
                columns: new[] { "ClassName", "Teacher" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "JD_Commodity_001");

            migrationBuilder.DropTable(
                name: "JD_Commodity_002");

            migrationBuilder.DropTable(
                name: "JD_Commodity_003");

            migrationBuilder.DropTable(
                name: "JD_Commodity_004");

            migrationBuilder.DropTable(
                name: "JD_Commodity_005");

            migrationBuilder.DropTable(
                name: "JD_Commodity_006");

            migrationBuilder.DropTable(
                name: "JD_Commodity_007");

            migrationBuilder.DropTable(
                name: "JD_Commodity_008");

            migrationBuilder.DropTable(
                name: "JD_Commodity_009");

            migrationBuilder.DropTable(
                name: "JD_Commodity_010");

            migrationBuilder.DropTable(
                name: "JD_Commodity_011");

            migrationBuilder.DropTable(
                name: "JD_Commodity_012");

            migrationBuilder.DropTable(
                name: "JD_Commodity_013");

            migrationBuilder.DropTable(
                name: "JD_Commodity_014");

            migrationBuilder.DropTable(
                name: "JD_Commodity_015");

            migrationBuilder.DropTable(
                name: "JD_Commodity_016");

            migrationBuilder.DropTable(
                name: "JD_Commodity_017");

            migrationBuilder.DropTable(
                name: "JD_Commodity_018");

            migrationBuilder.DropTable(
                name: "JD_Commodity_019");

            migrationBuilder.DropTable(
                name: "JD_Commodity_020");

            migrationBuilder.DropTable(
                name: "JD_Commodity_021");

            migrationBuilder.DropTable(
                name: "JD_Commodity_022");

            migrationBuilder.DropTable(
                name: "JD_Commodity_023");

            migrationBuilder.DropTable(
                name: "JD_Commodity_024");

            migrationBuilder.DropTable(
                name: "JD_Commodity_025");

            migrationBuilder.DropTable(
                name: "JD_Commodity_026");

            migrationBuilder.DropTable(
                name: "JD_Commodity_027");

            migrationBuilder.DropTable(
                name: "JD_Commodity_028");

            migrationBuilder.DropTable(
                name: "JD_Commodity_029");

            migrationBuilder.DropTable(
                name: "JD_Commodity_030");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "SysLog");

            migrationBuilder.DropTable(
                name: "SysMenu");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "SysRoleMenuMapping");

            migrationBuilder.DropTable(
                name: "SysUser");

            migrationBuilder.DropTable(
                name: "SysUserMenuMapping");

            migrationBuilder.DropTable(
                name: "SysUserRoleMapping");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WPFClass");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
