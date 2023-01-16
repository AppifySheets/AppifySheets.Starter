﻿// <auto-generated />
using System;
using EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppifySheets.EFCore.Migrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230116102912_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("text")
                        .HasColumnName("DisplayName");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("text")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers", (string)null);
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Domain.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ExpiredById")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ExpiredOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid");

                    b.HasKey("Id");

                    b.HasIndex("CityName");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ExpiredById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Module.EFCore.BarbarosaLoginInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("LoginProviderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProviderUserKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.HasIndex("LoginProviderName", "ProviderUserKey")
                        .IsUnique();

                    b.ToTable("ApplicationUserLoginInfos", (string)null);
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.AuditRelated.AsAuditDataItemPersistent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("AuditedObjectID")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("NewObjectID")
                        .HasColumnType("integer");

                    b.Property<string>("NewValue")
                        .HasColumnType("text");

                    b.Property<int?>("OldObjectID")
                        .HasColumnType("integer");

                    b.Property<string>("OldValue")
                        .HasColumnType("text");

                    b.Property<string>("OperationType")
                        .HasColumnType("text");

                    b.Property<string>("PropertyName")
                        .HasColumnType("text");

                    b.Property<int?>("UserObjectID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("AuditedObjectID");

                    b.HasIndex("NewObjectID");

                    b.HasIndex("OldObjectID");

                    b.HasIndex("UserObjectID");

                    b.ToTable("AuditData");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.AuditRelated.AsAuditEFCoreWeakReference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("DefaultString")
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TypeName")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("AuditEFCoreWeakReference", (string)null);
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.ModelDifferenceTypes.AsDashboardData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<bool>("SynchronizeTitle")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("DashboardsData");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.ModelDifferenceTypes.AsModelDifference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ContextId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("ModelDifferences");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.ModelDifferenceTypes.AsModelDifferenceAspect", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OwnerID")
                        .HasColumnType("integer");

                    b.Property<string>("Xml")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("ModelDifferenceAspects");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyActionPermissionObject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ActionId")
                        .HasColumnType("text");

                    b.Property<int?>("RoleID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("PermissionPolicyActionPermissionObjects", (string)null);
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyMemberPermissionsObject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Criteria")
                        .HasColumnType("text");

                    b.Property<string>("Members")
                        .HasColumnType("text");

                    b.Property<int?>("ReadState")
                        .HasColumnType("integer");

                    b.Property<int?>("TypePermissionObjectID")
                        .HasColumnType("integer");

                    b.Property<int?>("WriteState")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("TypePermissionObjectID");

                    b.ToTable("PermissionPolicyMemberPermissionsObjects", (string)null);
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyNavigationPermissionObject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ItemPath")
                        .HasColumnType("text");

                    b.Property<int?>("NavigateState")
                        .HasColumnType("integer");

                    b.Property<int?>("RoleID")
                        .HasColumnType("integer");

                    b.Property<string>("TargetTypeFullName")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("PermissionPolicyNavigationPermissionObjects", (string)null);
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyObjectPermissionsObject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Criteria")
                        .HasColumnType("text");

                    b.Property<int?>("DeleteState")
                        .HasColumnType("integer");

                    b.Property<int?>("NavigateState")
                        .HasColumnType("integer");

                    b.Property<int?>("ReadState")
                        .HasColumnType("integer");

                    b.Property<int?>("TypePermissionObjectID")
                        .HasColumnType("integer");

                    b.Property<int?>("WriteState")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("TypePermissionObjectID");

                    b.ToTable("PermissionPolicyObjectPermissionsObjects", (string)null);
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRoleBase", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<bool>("CanEditModel")
                        .HasColumnType("boolean");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdministrative")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAllowPermissionPriority")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PermissionPolicy")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("ApplicationRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("AsPermissionPolicyRoleBase");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyTypePermissionObject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("CreateState")
                        .HasColumnType("integer");

                    b.Property<int?>("DeleteState")
                        .HasColumnType("integer");

                    b.Property<int?>("NavigateState")
                        .HasColumnType("integer");

                    b.Property<int?>("ReadState")
                        .HasColumnType("integer");

                    b.Property<int?>("RoleID")
                        .HasColumnType("integer");

                    b.Property<string>("TargetTypeFullName")
                        .HasColumnType("text");

                    b.Property<int?>("WriteState")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("PermissionPolicyTypePermissionObjects", (string)null);
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<bool>("ChangePasswordOnFirstLogon")
                        .HasColumnType("boolean");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("StoredPassword")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("text")
                        .HasColumnName("UserName");

                    b.HasKey("ID");

                    b.ToTable("ApplicationUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("AsPermissionPolicyUser");
                });

            modelBuilder.Entity("AsPermissionPolicyRoleAsPermissionPolicyUser", b =>
                {
                    b.Property<int>("RolesID")
                        .HasColumnType("integer");

                    b.Property<int>("UsersID")
                        .HasColumnType("integer");

                    b.HasKey("RolesID", "UsersID");

                    b.HasIndex("UsersID");

                    b.ToTable("PermissionPolicyRolePermissionPolicyUser", (string)null);
                });

            modelBuilder.Entity("DevExpress.ExpressApp.EFCore.Updating.ModuleInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AssemblyFileName")
                        .HasColumnType("text");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ModulesInfo");
                });

            modelBuilder.Entity("DevExpress.Persistent.BaseImpl.EF.FileData", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Content")
                        .HasColumnType("bytea");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("FileDatas");
                });

            modelBuilder.Entity("DevExpress.Persistent.BaseImpl.EF.ReportDataV2", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Content")
                        .HasColumnType("bytea");

                    b.Property<string>("DataTypeName")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<bool>("IsInplaceReport")
                        .HasColumnType("boolean");

                    b.Property<string>("ParametersObjectTypeName")
                        .HasColumnType("text");

                    b.Property<string>("PredefinedReportTypeName")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ReportDatasV2");
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Module.EFCore.BarbarosaUser", b =>
                {
                    b.HasBaseType("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyUser");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("text")
                        .HasColumnName("DisplayName");

                    b.Property<int?>("ExpiredById")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ExpiredOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastModifiedById")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ExpiredById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("UserName", "IsActive")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("BarbarosaUser");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRole", b =>
                {
                    b.HasBaseType("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRoleBase");

                    b.HasDiscriminator().HasValue("AsPermissionPolicyRole");
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Module.EFCore.BarbarosaRole", b =>
                {
                    b.HasBaseType("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRole");

                    b.Property<bool>("AllowEditProxy")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsControlling")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("BarbarosaRole");
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", b =>
                {
                    b.HasOne("AppifySheets.Barbarosa.Module.EFCore.BarbarosaUser", null)
                        .WithOne("BasicApplicationUser")
                        .HasForeignKey("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Domain.Models.City", b =>
                {
                    b.HasOne("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", "ExpiredBy")
                        .WithMany()
                        .HasForeignKey("ExpiredById");

                    b.HasOne("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("ExpiredBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Module.EFCore.BarbarosaLoginInfo", b =>
                {
                    b.HasOne("AppifySheets.Barbarosa.Module.EFCore.BarbarosaUser", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.AuditRelated.AsAuditDataItemPersistent", b =>
                {
                    b.HasOne("AppifySheets.Common.EfCore.AuditRelated.AsAuditEFCoreWeakReference", "AuditedObject")
                        .WithMany("AuditItems")
                        .HasForeignKey("AuditedObjectID");

                    b.HasOne("AppifySheets.Common.EfCore.AuditRelated.AsAuditEFCoreWeakReference", "NewObject")
                        .WithMany("NewItems")
                        .HasForeignKey("NewObjectID");

                    b.HasOne("AppifySheets.Common.EfCore.AuditRelated.AsAuditEFCoreWeakReference", "OldObject")
                        .WithMany("OldItems")
                        .HasForeignKey("OldObjectID");

                    b.HasOne("AppifySheets.Common.EfCore.AuditRelated.AsAuditEFCoreWeakReference", "UserObject")
                        .WithMany("UserItems")
                        .HasForeignKey("UserObjectID");

                    b.Navigation("AuditedObject");

                    b.Navigation("NewObject");

                    b.Navigation("OldObject");

                    b.Navigation("UserObject");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.ModelDifferenceTypes.AsModelDifferenceAspect", b =>
                {
                    b.HasOne("AppifySheets.Common.EfCore.ModelDifferenceTypes.AsModelDifference", "Owner")
                        .WithMany("Aspects")
                        .HasForeignKey("OwnerID");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyActionPermissionObject", b =>
                {
                    b.HasOne("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRoleBase", "Role")
                        .WithMany("ActionPermissions")
                        .HasForeignKey("RoleID");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyMemberPermissionsObject", b =>
                {
                    b.HasOne("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyTypePermissionObject", "TypePermissionObject")
                        .WithMany("MemberPermissions")
                        .HasForeignKey("TypePermissionObjectID");

                    b.Navigation("TypePermissionObject");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyNavigationPermissionObject", b =>
                {
                    b.HasOne("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRoleBase", "Role")
                        .WithMany("NavigationPermissions")
                        .HasForeignKey("RoleID");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyObjectPermissionsObject", b =>
                {
                    b.HasOne("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyTypePermissionObject", "TypePermissionObject")
                        .WithMany("ObjectPermissions")
                        .HasForeignKey("TypePermissionObjectID");

                    b.Navigation("TypePermissionObject");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyTypePermissionObject", b =>
                {
                    b.HasOne("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRoleBase", "Role")
                        .WithMany("TypePermissions")
                        .HasForeignKey("RoleID");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AsPermissionPolicyRoleAsPermissionPolicyUser", b =>
                {
                    b.HasOne("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRole", null)
                        .WithMany()
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyUser", null)
                        .WithMany()
                        .HasForeignKey("UsersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Module.EFCore.BarbarosaUser", b =>
                {
                    b.HasOne("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", "ExpiredBy")
                        .WithMany()
                        .HasForeignKey("ExpiredById");

                    b.HasOne("AppifySheets.Barbarosa.Domain.BaseModels.BasicUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("ExpiredBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.AuditRelated.AsAuditEFCoreWeakReference", b =>
                {
                    b.Navigation("AuditItems");

                    b.Navigation("NewItems");

                    b.Navigation("OldItems");

                    b.Navigation("UserItems");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.ModelDifferenceTypes.AsModelDifference", b =>
                {
                    b.Navigation("Aspects");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyRoleBase", b =>
                {
                    b.Navigation("ActionPermissions");

                    b.Navigation("NavigationPermissions");

                    b.Navigation("TypePermissions");
                });

            modelBuilder.Entity("AppifySheets.Common.EfCore.UsersRelated.AsPermissionPolicyTypePermissionObject", b =>
                {
                    b.Navigation("MemberPermissions");

                    b.Navigation("ObjectPermissions");
                });

            modelBuilder.Entity("AppifySheets.Barbarosa.Module.EFCore.BarbarosaUser", b =>
                {
                    b.Navigation("BasicApplicationUser")
                        .IsRequired();

                    b.Navigation("UserLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
