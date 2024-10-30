﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ploch.EditorConfigTools.DataAccess;

#nullable disable

namespace Ploch.EditorConfigTools.Data.SqlServer.Migrations
{
    [DbContext(typeof(EditorConfigDbContext))]
    [Migration("20241029202241_ConfigSectionParentChildren")]
    partial class ConfigSectionParentChildren
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FilePatternFileType", b =>
                {
                    b.Property<int>("FilePatternsId")
                        .HasColumnType("int");

                    b.Property<int>("FileTypesId")
                        .HasColumnType("int");

                    b.HasKey("FilePatternsId", "FileTypesId");

                    b.HasIndex("FileTypesId");

                    b.ToTable("FilePatternFileType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConfigEntryId")
                        .HasColumnType("int");

                    b.Property<int?>("ConfigSectionId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigEntryId");

                    b.HasIndex("ConfigSectionId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConfigSectionId")
                        .HasColumnType("int");

                    b.Property<string>("Modifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SettingDefinitionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigSectionId");

                    b.HasIndex("SettingDefinitionId");

                    b.ToTable("ConfigEntries");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConfigSectionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EditorConfigFileId")
                        .HasColumnType("int");

                    b.Property<int>("FilePatternId")
                        .HasColumnType("int");

                    b.Property<string>("GlobPattern")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConfigSectionTypeId");

                    b.HasIndex("EditorConfigFileId");

                    b.HasIndex("FilePatternId");

                    b.HasIndex("ParentId");

                    b.ToTable("ConfigSections");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigSectionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilePatternId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedExtensions")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FilePatternId");

                    b.HasIndex("NormalizedExtensions");

                    b.ToTable("ConfigSectionTypes");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.EditorConfigFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("EditorConfigFiles");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.FileExtension", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FileTypeId");

                    b.ToTable("FileExtension");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.FilePattern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GlobPattern")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePattern")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FilePatterns");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.FileType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.SettingCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("SettingCategories");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.SettingDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SettingDefinitionGroupId")
                        .HasColumnType("int");

                    b.Property<string>("SettingNameRegex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SettingDefinitionGroupId");

                    b.ToTable("SettingDefinitions");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.SettingDefinitionGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DefinitionGroupNameRegex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SettingDefinitionGroup");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ValueDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValueTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ValueTypeId");

                    b.ToTable("ValueDefinitions");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ValueType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HandlerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ValueTypes");
                });

            modelBuilder.Entity("SettingCategorySettingDefinition", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<Guid>("SettingDefinitionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "SettingDefinitionsId");

                    b.HasIndex("SettingDefinitionsId");

                    b.ToTable("SettingCategorySettingDefinition");
                });

            modelBuilder.Entity("SettingDefinitionValueDefinition", b =>
                {
                    b.Property<int>("AllowedValuesId")
                        .HasColumnType("int");

                    b.Property<Guid>("ValueSettingDefinitionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AllowedValuesId", "ValueSettingDefinitionsId");

                    b.HasIndex("ValueSettingDefinitionsId");

                    b.ToTable("SettingDefinitionValueDefinition");
                });

            modelBuilder.Entity("FilePatternFileType", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.FilePattern", null)
                        .WithMany()
                        .HasForeignKey("FilePatternsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ploch.EditorConfigTools.Models.FileType", null)
                        .WithMany()
                        .HasForeignKey("FileTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ploch.EditorConfigTools.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.Comment", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ConfigEntry", "ConfigEntry")
                        .WithMany("Comments")
                        .HasForeignKey("ConfigEntryId");

                    b.HasOne("Ploch.EditorConfigTools.Models.ConfigSection", "ConfigSection")
                        .WithMany("Comments")
                        .HasForeignKey("ConfigSectionId");

                    b.Navigation("ConfigEntry");

                    b.Navigation("ConfigSection");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigEntry", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ConfigSection", "ConfigSection")
                        .WithMany("ConfigEntries")
                        .HasForeignKey("ConfigSectionId");

                    b.HasOne("Ploch.EditorConfigTools.Models.SettingDefinition", "SettingDefinition")
                        .WithMany("ConfigEntries")
                        .HasForeignKey("SettingDefinitionId");

                    b.Navigation("ConfigSection");

                    b.Navigation("SettingDefinition");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigSection", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ConfigSectionType", "ConfigSectionType")
                        .WithMany("ConfigSections")
                        .HasForeignKey("ConfigSectionTypeId");

                    b.HasOne("Ploch.EditorConfigTools.Models.EditorConfigFile", "EditorConfigFile")
                        .WithMany("ConfigSections")
                        .HasForeignKey("EditorConfigFileId");

                    b.HasOne("Ploch.EditorConfigTools.Models.FilePattern", "FilePattern")
                        .WithMany("ConfigSections")
                        .HasForeignKey("FilePatternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ploch.EditorConfigTools.Models.ConfigSection", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("ConfigSectionType");

                    b.Navigation("EditorConfigFile");

                    b.Navigation("FilePattern");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigSectionType", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.FilePattern", "FilePattern")
                        .WithMany("ConfigSectionTypes")
                        .HasForeignKey("FilePatternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilePattern");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.EditorConfigFile", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.Project", "Project")
                        .WithMany("EditorConfigFiles")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.FileExtension", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.FileType", "FileType")
                        .WithMany("FileExtensions")
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileType");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.Project", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ApplicationUser", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.SettingCategory", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.SettingCategory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.SettingDefinition", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.SettingDefinitionGroup", "SettingDefinitionGroup")
                        .WithMany("SettingDefinitions")
                        .HasForeignKey("SettingDefinitionGroupId");

                    b.Navigation("SettingDefinitionGroup");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ValueDefinition", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ValueType", "ValueType")
                        .WithMany("ValueDefinitions")
                        .HasForeignKey("ValueTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ValueType");
                });

            modelBuilder.Entity("SettingCategorySettingDefinition", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.SettingCategory", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ploch.EditorConfigTools.Models.SettingDefinition", null)
                        .WithMany()
                        .HasForeignKey("SettingDefinitionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SettingDefinitionValueDefinition", b =>
                {
                    b.HasOne("Ploch.EditorConfigTools.Models.ValueDefinition", null)
                        .WithMany()
                        .HasForeignKey("AllowedValuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ploch.EditorConfigTools.Models.SettingDefinition", null)
                        .WithMany()
                        .HasForeignKey("ValueSettingDefinitionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ApplicationUser", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigEntry", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigSection", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Comments");

                    b.Navigation("ConfigEntries");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ConfigSectionType", b =>
                {
                    b.Navigation("ConfigSections");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.EditorConfigFile", b =>
                {
                    b.Navigation("ConfigSections");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.FilePattern", b =>
                {
                    b.Navigation("ConfigSectionTypes");

                    b.Navigation("ConfigSections");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.FileType", b =>
                {
                    b.Navigation("FileExtensions");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.Project", b =>
                {
                    b.Navigation("EditorConfigFiles");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.SettingCategory", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.SettingDefinition", b =>
                {
                    b.Navigation("ConfigEntries");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.SettingDefinitionGroup", b =>
                {
                    b.Navigation("SettingDefinitions");
                });

            modelBuilder.Entity("Ploch.EditorConfigTools.Models.ValueType", b =>
                {
                    b.Navigation("ValueDefinitions");
                });
#pragma warning restore 612, 618
        }
    }
}
