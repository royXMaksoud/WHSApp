using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandGUID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryGUID);
                });

            migrationBuilder.CreateTable(
                name: "DeterminerTypes",
                columns: table => new
                {
                    DeterminerTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeterminerTypes", x => x.DeterminerTypeGUID);
                });

            migrationBuilder.CreateTable(
                name: "EntryDetails",
                columns: table => new
                {
                    EntryDetailGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentRequestGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentOwnedWarehousGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentProductStatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentMovementStatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentPhysicalStatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CurrentUSDPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryDetails", x => x.EntryDetailGUID);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationGUID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryGUID);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeGUID);
                });

            migrationBuilder.CreateTable(
                name: "RequesterTypes",
                columns: table => new
                {
                    RequesterTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequesterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequesterTypes", x => x.RequesterTypeGUID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodeTables",
                columns: table => new
                {
                    TableGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTables", x => x.TableGUID);
                    table.ForeignKey(
                        name: "FK_CodeTables_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryLocations",
                columns: table => new
                {
                    LocationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLocations", x => x.LocationGUID);
                    table.ForeignKey(
                        name: "FK_CountryLocations_Countries_CountryGUID",
                        column: x => x.CountryGUID,
                        principalTable: "Countries",
                        principalColumn: "CountryGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryDetailPrices",
                columns: table => new
                {
                    EntryDetailPriceGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDetailGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryDetailPrices", x => x.EntryDetailPriceGUID);
                    table.ForeignKey(
                        name: "FK_EntryDetailPrices_EntryDetails_EntryDetailPriceGUID",
                        column: x => x.EntryDetailPriceGUID,
                        principalTable: "EntryDetails",
                        principalColumn: "EntryDetailGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryDeterminers",
                columns: table => new
                {
                    EntryDeterminerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDetailGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeterminerTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeterminerValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryDeterminers", x => x.EntryDeterminerGUID);
                    table.ForeignKey(
                        name: "FK_EntryDeterminers_EntryDetails_EntryDeterminerGUID",
                        column: x => x.EntryDeterminerGUID,
                        principalTable: "EntryDetails",
                        principalColumn: "EntryDetailGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryMovements",
                columns: table => new
                {
                    EntryMovementGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDetailGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowStatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsLastAction = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryMovements", x => x.EntryMovementGUID);
                    table.ForeignKey(
                        name: "FK_EntryMovements_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryMovements_EntryDetails_EntryMovementGUID",
                        column: x => x.EntryMovementGUID,
                        principalTable: "EntryDetails",
                        principalColumn: "EntryDetailGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionByCountries",
                columns: table => new
                {
                    InstitutionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstitutioName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionByCountries", x => x.InstitutionGUID);
                    table.ForeignKey(
                        name: "FK_InstitutionByCountries_Countries_CountryGUID",
                        column: x => x.CountryGUID,
                        principalTable: "Countries",
                        principalColumn: "CountryGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstitutionByCountries_Organizations_OrganizationGUID",
                        column: x => x.OrganizationGUID,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubCategories",
                columns: table => new
                {
                    ProductSubCategoryGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubCategories", x => x.ProductSubCategoryGUID);
                    table.ForeignKey(
                        name: "FK_ProductSubCategories_ProductCategories_ProductCategoryGUID",
                        column: x => x.ProductCategoryGUID,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseRequests",
                columns: table => new
                {
                    ReleaseRequestGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestNameGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseUserGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastRequestStatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    SequenceCode = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseRequests", x => x.ReleaseRequestGUID);
                    table.ForeignKey(
                        name: "FK_ReleaseRequests_RequesterTypes_RequestTypeGUID",
                        column: x => x.RequestTypeGUID,
                        principalTable: "RequesterTypes",
                        principalColumn: "RequesterTypeGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CodeTableValues",
                columns: table => new
                {
                    TableValueGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTableValues", x => x.TableValueGUID);
                    table.ForeignKey(
                        name: "FK_CodeTableValues_CodeTables_TableGUID",
                        column: x => x.TableGUID,
                        principalTable: "CodeTables",
                        principalColumn: "TableGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierGUID);
                    table.ForeignKey(
                        name: "FK_Suppliers_CountryLocations_LocationGUID",
                        column: x => x.LocationGUID,
                        principalTable: "CountryLocations",
                        principalColumn: "LocationGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DutyStations",
                columns: table => new
                {
                    DutyStationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DutyStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyStations", x => x.DutyStationGUID);
                    table.ForeignKey(
                        name: "FK_DutyStations_InstitutionByCountries_InstitutionGUID",
                        column: x => x.InstitutionGUID,
                        principalTable: "InstitutionByCountries",
                        principalColumn: "InstitutionGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSubCategoryGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductGUID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandGUID",
                        column: x => x.BrandGUID,
                        principalTable: "Brands",
                        principalColumn: "BrandGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductSubCategories_ProductSubCategoryGUID",
                        column: x => x.ProductSubCategoryGUID,
                        principalTable: "ProductSubCategories",
                        principalColumn: "ProductSubCategoryGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeGUID",
                        column: x => x.ProductTypeGUID,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseRequestDetails",
                columns: table => new
                {
                    ReleaseRequestDetailGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReleaseRequestGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDetailGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDetailPriceGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    D = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseRequestDetails", x => x.ReleaseRequestDetailGUID);
                    table.ForeignKey(
                        name: "FK_ReleaseRequestDetails_EntryDetailPrices_ReleaseRequestDetailGUID",
                        column: x => x.ReleaseRequestDetailGUID,
                        principalTable: "EntryDetailPrices",
                        principalColumn: "EntryDetailPriceGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseRequestDetails_EntryDetails_ReleaseRequestDetailGUID",
                        column: x => x.ReleaseRequestDetailGUID,
                        principalTable: "EntryDetails",
                        principalColumn: "EntryDetailGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReleaseRequestDetails_ReleaseRequests_ReleaseRequestDetailGUID",
                        column: x => x.ReleaseRequestDetailGUID,
                        principalTable: "ReleaseRequests",
                        principalColumn: "ReleaseRequestGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseRequestMovements",
                columns: table => new
                {
                    ReleaseRequestMovementGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReleaseRequestGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowStatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLastAction = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseRequestMovements", x => x.ReleaseRequestMovementGUID);
                    table.ForeignKey(
                        name: "FK_ReleaseRequestMovements_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReleaseRequestMovements_ReleaseRequests_ReleaseRequestMovementGUID",
                        column: x => x.ReleaseRequestMovementGUID,
                        principalTable: "ReleaseRequests",
                        principalColumn: "ReleaseRequestGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DutyStationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseParentGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DutyStationGUID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseGUID);
                    table.ForeignKey(
                        name: "FK_Warehouses_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouses_DutyStations_DutyStationGUID1",
                        column: x => x.DutyStationGUID1,
                        principalTable: "DutyStations",
                        principalColumn: "DutyStationGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDeterminers",
                columns: table => new
                {
                    ProductDeterminerGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeterminerTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDeterminers", x => x.ProductDeterminerGUID);
                    table.ForeignKey(
                        name: "FK_ProductDeterminers_DeterminerTypes_DeterminerTypeGUID",
                        column: x => x.DeterminerTypeGUID,
                        principalTable: "DeterminerTypes",
                        principalColumn: "DeterminerTypeGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDeterminers_Products_ProductGUID",
                        column: x => x.ProductGUID,
                        principalTable: "Products",
                        principalColumn: "ProductGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    ProductFeatureGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.ProductFeatureGUID);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductGUID",
                        column: x => x.ProductGUID,
                        principalTable: "Products",
                        principalColumn: "ProductGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    TranslationGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.TranslationGUID);
                    table.ForeignKey(
                        name: "FK_Translations_Products_ProductGUID",
                        column: x => x.ProductGUID,
                        principalTable: "Products",
                        principalColumn: "ProductGUID");
                });

            migrationBuilder.CreateTable(
                name: "ProductByWarehouse",
                columns: table => new
                {
                    ProductByWarehouseGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductByWarehouse", x => x.ProductByWarehouseGUID);
                    table.ForeignKey(
                        name: "FK_ProductByWarehouse_Products_ProductGUID",
                        column: x => x.ProductGUID,
                        principalTable: "Products",
                        principalColumn: "ProductGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductByWarehouse_Warehouses_WarehouseGUID",
                        column: x => x.WarehouseGUID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentRequests",
                columns: table => new
                {
                    ShipmentRequestGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentTypeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentNumber = table.Column<int>(type: "int", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SupplierGUID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentRequests", x => x.ShipmentRequestGUID);
                    table.ForeignKey(
                        name: "FK_ShipmentRequests_EntryDetails_ShipmentRequestGUID",
                        column: x => x.ShipmentRequestGUID,
                        principalTable: "EntryDetails",
                        principalColumn: "EntryDetailGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentRequests_Suppliers_SupplierGUID1",
                        column: x => x.SupplierGUID1,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentRequests_Warehouses_WarehouseGUID",
                        column: x => x.WarehouseGUID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarehosueFocalPoints",
                columns: table => new
                {
                    WarehosueFocalPointGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserFocalPointId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehosueFocalPoints", x => x.WarehosueFocalPointGUID);
                    table.ForeignKey(
                        name: "FK_WarehosueFocalPoints_AspNetUsers_UserFocalPointId",
                        column: x => x.UserFocalPointId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehosueFocalPoints_Warehouses_WarehouseGUID",
                        column: x => x.WarehouseGUID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentRequestDetails",
                columns: table => new
                {
                    ShipmentRequestDetailGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentRequestGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    USDPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocalCurrencyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EruoPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarehoudGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentRequestDetails", x => x.ShipmentRequestDetailGUID);
                    table.ForeignKey(
                        name: "FK_ShipmentRequestDetails_ShipmentRequests_ShipmentRequestGUID",
                        column: x => x.ShipmentRequestGUID,
                        principalTable: "ShipmentRequests",
                        principalColumn: "ShipmentRequestGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentRequestMovements",
                columns: table => new
                {
                    ShipmentRequestMovementGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentRequestGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowStatusGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsLastAction = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ShipmentRequestGUID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentRequestMovements", x => x.ShipmentRequestMovementGUID);
                    table.ForeignKey(
                        name: "FK_ShipmentRequestMovements_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentRequestMovements_ShipmentRequests_ShipmentRequestGUID1",
                        column: x => x.ShipmentRequestGUID1,
                        principalTable: "ShipmentRequests",
                        principalColumn: "ShipmentRequestGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTables_CreatedByUserId",
                table: "CodeTables",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeTableValues_TableGUID",
                table: "CodeTableValues",
                column: "TableGUID");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLocations_CountryGUID",
                table: "CountryLocations",
                column: "CountryGUID");

            migrationBuilder.CreateIndex(
                name: "IX_DutyStations_InstitutionGUID",
                table: "DutyStations",
                column: "InstitutionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_EntryMovements_CreatedByUserId",
                table: "EntryMovements",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionByCountries_CountryGUID",
                table: "InstitutionByCountries",
                column: "CountryGUID");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionByCountries_OrganizationGUID",
                table: "InstitutionByCountries",
                column: "OrganizationGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductByWarehouse_ProductGUID",
                table: "ProductByWarehouse",
                column: "ProductGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductByWarehouse_WarehouseGUID",
                table: "ProductByWarehouse",
                column: "WarehouseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeterminers_DeterminerTypeGUID",
                table: "ProductDeterminers",
                column: "DeterminerTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeterminers_ProductGUID",
                table: "ProductDeterminers",
                column: "ProductGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductGUID",
                table: "ProductFeatures",
                column: "ProductGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandGUID",
                table: "Products",
                column: "BrandGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSubCategoryGUID",
                table: "Products",
                column: "ProductSubCategoryGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeGUID",
                table: "Products",
                column: "ProductTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubCategories_ProductCategoryGUID",
                table: "ProductSubCategories",
                column: "ProductCategoryGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseRequestMovements_UsersId",
                table: "ReleaseRequestMovements",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseRequests_RequestTypeGUID",
                table: "ReleaseRequests",
                column: "RequestTypeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequestDetails_ShipmentRequestGUID",
                table: "ShipmentRequestDetails",
                column: "ShipmentRequestGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequestMovements_CreatedByUserId",
                table: "ShipmentRequestMovements",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequestMovements_ShipmentRequestGUID1",
                table: "ShipmentRequestMovements",
                column: "ShipmentRequestGUID1");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequests_SupplierGUID1",
                table: "ShipmentRequests",
                column: "SupplierGUID1");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequests_WarehouseGUID",
                table: "ShipmentRequests",
                column: "WarehouseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_LocationGUID",
                table: "Suppliers",
                column: "LocationGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_ProductGUID",
                table: "Translations",
                column: "ProductGUID");

            migrationBuilder.CreateIndex(
                name: "IX_WarehosueFocalPoints_UserFocalPointId",
                table: "WarehosueFocalPoints",
                column: "UserFocalPointId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehosueFocalPoints_WarehouseGUID",
                table: "WarehosueFocalPoints",
                column: "WarehouseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CreatedByUserId",
                table: "Warehouses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_DutyStationGUID1",
                table: "Warehouses",
                column: "DutyStationGUID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CodeTableValues");

            migrationBuilder.DropTable(
                name: "EntryDeterminers");

            migrationBuilder.DropTable(
                name: "EntryMovements");

            migrationBuilder.DropTable(
                name: "ProductByWarehouse");

            migrationBuilder.DropTable(
                name: "ProductDeterminers");

            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "ReleaseRequestDetails");

            migrationBuilder.DropTable(
                name: "ReleaseRequestMovements");

            migrationBuilder.DropTable(
                name: "ShipmentRequestDetails");

            migrationBuilder.DropTable(
                name: "ShipmentRequestMovements");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "WarehosueFocalPoints");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CodeTables");

            migrationBuilder.DropTable(
                name: "DeterminerTypes");

            migrationBuilder.DropTable(
                name: "EntryDetailPrices");

            migrationBuilder.DropTable(
                name: "ReleaseRequests");

            migrationBuilder.DropTable(
                name: "ShipmentRequests");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RequesterTypes");

            migrationBuilder.DropTable(
                name: "EntryDetails");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductSubCategories");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "CountryLocations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DutyStations");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "InstitutionByCountries");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
