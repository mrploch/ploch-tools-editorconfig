using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ploch.EditorConfigTools.Data.SqlServver.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "ConfigSectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedExtensions = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigSectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileExtensions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingCategories_SettingCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SettingCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SettingDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SettingNameRegex = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValueTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandlerType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueTypes", x => x.Id);
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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConfigSectionTypeFileExtension",
                columns: table => new
                {
                    ConfigSectionTypesId = table.Column<int>(type: "int", nullable: false),
                    FileExtensionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigSectionTypeFileExtension", x => new { x.ConfigSectionTypesId, x.FileExtensionsId });
                    table.ForeignKey(
                        name: "FK_ConfigSectionTypeFileExtension_ConfigSectionTypes_ConfigSectionTypesId",
                        column: x => x.ConfigSectionTypesId,
                        principalTable: "ConfigSectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigSectionTypeFileExtension_FileExtensions_FileExtensionsId",
                        column: x => x.FileExtensionsId,
                        principalTable: "FileExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingCategorySettingDefinition",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    SettingDefinitionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingCategorySettingDefinition", x => new { x.CategoriesId, x.SettingDefinitionsId });
                    table.ForeignKey(
                        name: "FK_SettingCategorySettingDefinition_SettingCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "SettingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingCategorySettingDefinition_SettingDefinitions_SettingDefinitionsId",
                        column: x => x.SettingDefinitionsId,
                        principalTable: "SettingDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValueDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValueDefinitions_ValueTypes_ValueTypeId",
                        column: x => x.ValueTypeId,
                        principalTable: "ValueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditorConfigFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRoot = table.Column<bool>(type: "bit", nullable: false),
                    FileHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorConfigFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditorConfigFiles_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingDefinitionValueDefinition",
                columns: table => new
                {
                    AllowedValuesId = table.Column<int>(type: "int", nullable: false),
                    ValueSettingDefinitionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingDefinitionValueDefinition", x => new { x.AllowedValuesId, x.ValueSettingDefinitionsId });
                    table.ForeignKey(
                        name: "FK_SettingDefinitionValueDefinition_SettingDefinitions_ValueSettingDefinitionsId",
                        column: x => x.ValueSettingDefinitionsId,
                        principalTable: "SettingDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingDefinitionValueDefinition_ValueDefinitions_AllowedValuesId",
                        column: x => x.AllowedValuesId,
                        principalTable: "ValueDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfigSectionTypeId = table.Column<int>(type: "int", nullable: true),
                    EditorConfigFileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigSections_ConfigSectionTypes_ConfigSectionTypeId",
                        column: x => x.ConfigSectionTypeId,
                        principalTable: "ConfigSectionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConfigSections_EditorConfigFiles_EditorConfigFileId",
                        column: x => x.EditorConfigFileId,
                        principalTable: "EditorConfigFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConfigEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfigSectionId = table.Column<int>(type: "int", nullable: true),
                    SettingDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigEntries_ConfigSections_ConfigSectionId",
                        column: x => x.ConfigSectionId,
                        principalTable: "ConfigSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConfigEntries_SettingDefinitions_SettingDefinitionId",
                        column: x => x.SettingDefinitionId,
                        principalTable: "SettingDefinitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConfigSectionFileExtension",
                columns: table => new
                {
                    ConfigSectionsId = table.Column<int>(type: "int", nullable: false),
                    FileExtensionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigSectionFileExtension", x => new { x.ConfigSectionsId, x.FileExtensionsId });
                    table.ForeignKey(
                        name: "FK_ConfigSectionFileExtension_ConfigSections_ConfigSectionsId",
                        column: x => x.ConfigSectionsId,
                        principalTable: "ConfigSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigSectionFileExtension_FileExtensions_FileExtensionsId",
                        column: x => x.FileExtensionsId,
                        principalTable: "FileExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfigSectionId = table.Column<int>(type: "int", nullable: true),
                    ConfigEntryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_ConfigEntries_ConfigEntryId",
                        column: x => x.ConfigEntryId,
                        principalTable: "ConfigEntries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_ConfigSections_ConfigSectionId",
                        column: x => x.ConfigSectionId,
                        principalTable: "ConfigSections",
                        principalColumn: "Id");
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
                name: "IX_Comment_ConfigEntryId",
                table: "Comment",
                column: "ConfigEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ConfigSectionId",
                table: "Comment",
                column: "ConfigSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigEntries_ConfigSectionId",
                table: "ConfigEntries",
                column: "ConfigSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigEntries_SettingDefinitionId",
                table: "ConfigEntries",
                column: "SettingDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigSectionFileExtension_FileExtensionsId",
                table: "ConfigSectionFileExtension",
                column: "FileExtensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigSections_ConfigSectionTypeId",
                table: "ConfigSections",
                column: "ConfigSectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigSections_EditorConfigFileId",
                table: "ConfigSections",
                column: "EditorConfigFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigSectionTypeFileExtension_FileExtensionsId",
                table: "ConfigSectionTypeFileExtension",
                column: "FileExtensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigSectionTypes_NormalizedExtensions",
                table: "ConfigSectionTypes",
                column: "NormalizedExtensions");

            migrationBuilder.CreateIndex(
                name: "IX_EditorConfigFiles_ProjectId",
                table: "EditorConfigFiles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingCategories_ParentId",
                table: "SettingCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingCategorySettingDefinition_SettingDefinitionsId",
                table: "SettingCategorySettingDefinition",
                column: "SettingDefinitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingDefinitionValueDefinition_ValueSettingDefinitionsId",
                table: "SettingDefinitionValueDefinition",
                column: "ValueSettingDefinitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ValueDefinitions_ValueTypeId",
                table: "ValueDefinitions",
                column: "ValueTypeId");
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
                name: "Comment");

            migrationBuilder.DropTable(
                name: "ConfigSectionFileExtension");

            migrationBuilder.DropTable(
                name: "ConfigSectionTypeFileExtension");

            migrationBuilder.DropTable(
                name: "SettingCategorySettingDefinition");

            migrationBuilder.DropTable(
                name: "SettingDefinitionValueDefinition");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ConfigEntries");

            migrationBuilder.DropTable(
                name: "FileExtensions");

            migrationBuilder.DropTable(
                name: "SettingCategories");

            migrationBuilder.DropTable(
                name: "ValueDefinitions");

            migrationBuilder.DropTable(
                name: "ConfigSections");

            migrationBuilder.DropTable(
                name: "SettingDefinitions");

            migrationBuilder.DropTable(
                name: "ValueTypes");

            migrationBuilder.DropTable(
                name: "ConfigSectionTypes");

            migrationBuilder.DropTable(
                name: "EditorConfigFiles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
