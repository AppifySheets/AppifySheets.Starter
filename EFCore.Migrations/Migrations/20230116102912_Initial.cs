using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppifySheets.EFCore.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsAdministrative = table.Column<bool>(type: "boolean", nullable: false),
                    CanEditModel = table.Column<bool>(type: "boolean", nullable: false),
                    PermissionPolicy = table.Column<int>(type: "integer", nullable: false),
                    IsAllowPermissionPriority = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    AllowEditProxy = table.Column<bool>(type: "boolean", nullable: true),
                    IsControlling = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ChangePasswordOnFirstLogon = table.Column<bool>(type: "boolean", nullable: false),
                    StoredPassword = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpiredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    LastModifiedById = table.Column<int>(type: "integer", nullable: true),
                    ExpiredById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_ApplicationUsers_ExpiredById",
                        column: x => x.ExpiredById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_ApplicationUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditEFCoreWeakReference",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    DefaultString = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEFCoreWeakReference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DashboardsData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    SynchronizeTitle = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardsData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FileDatas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDatas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelDifferences",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ContextId = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModulesInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AssemblyFileName = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<string>(type: "text", nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportDatasV2",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTypeName = table.Column<string>(type: "text", nullable: true),
                    IsInplaceReport = table.Column<bool>(type: "boolean", nullable: false),
                    PredefinedReportTypeName = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<byte[]>(type: "bytea", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    ParametersObjectTypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDatasV2", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyActionPermissionObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: true),
                    ActionId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyActionPermissionObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyActionPermissionObjects_ApplicationRoles_Ro~",
                        column: x => x.RoleID,
                        principalTable: "ApplicationRoles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyNavigationPermissionObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(type: "integer", nullable: true),
                    ItemPath = table.Column<string>(type: "text", nullable: true),
                    TargetTypeFullName = table.Column<string>(type: "text", nullable: true),
                    NavigateState = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyNavigationPermissionObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyNavigationPermissionObjects_ApplicationRole~",
                        column: x => x.RoleID,
                        principalTable: "ApplicationRoles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyTypePermissionObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TargetTypeFullName = table.Column<string>(type: "text", nullable: true),
                    RoleID = table.Column<int>(type: "integer", nullable: true),
                    ReadState = table.Column<int>(type: "integer", nullable: true),
                    WriteState = table.Column<int>(type: "integer", nullable: true),
                    CreateState = table.Column<int>(type: "integer", nullable: true),
                    DeleteState = table.Column<int>(type: "integer", nullable: true),
                    NavigateState = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyTypePermissionObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyTypePermissionObjects_ApplicationRoles_Role~",
                        column: x => x.RoleID,
                        principalTable: "ApplicationRoles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserLoginInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginProviderName = table.Column<string>(type: "text", nullable: false),
                    ProviderUserKey = table.Column<string>(type: "text", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLoginInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicationUserLoginInfos_ApplicationUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpiredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpiredById = table.Column<int>(type: "integer", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: true),
                    LastModifiedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_ApplicationUsers_ExpiredById",
                        column: x => x.ExpiredById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_ApplicationUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyRolePermissionPolicyUser",
                columns: table => new
                {
                    RolesID = table.Column<int>(type: "integer", nullable: false),
                    UsersID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyRolePermissionPolicyUser", x => new { x.RolesID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRolePermissionPolicyUser_ApplicationRoles_R~",
                        column: x => x.RolesID,
                        principalTable: "ApplicationRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRolePermissionPolicyUser_ApplicationUsers_U~",
                        column: x => x.UsersID,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OperationType = table.Column<string>(type: "text", nullable: true),
                    PropertyName = table.Column<string>(type: "text", nullable: true),
                    OldValue = table.Column<string>(type: "text", nullable: true),
                    NewValue = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AuditedObjectID = table.Column<int>(type: "integer", nullable: true),
                    OldObjectID = table.Column<int>(type: "integer", nullable: true),
                    NewObjectID = table.Column<int>(type: "integer", nullable: true),
                    UserObjectID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_AuditedObjectID",
                        column: x => x.AuditedObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_NewObjectID",
                        column: x => x.NewObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_OldObjectID",
                        column: x => x.OldObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_UserObjectID",
                        column: x => x.UserObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ModelDifferenceAspects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Xml = table.Column<string>(type: "text", nullable: true),
                    OwnerID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferenceAspects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModelDifferenceAspects_ModelDifferences_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "ModelDifferences",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyMemberPermissionsObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Members = table.Column<string>(type: "text", nullable: true),
                    Criteria = table.Column<string>(type: "text", nullable: true),
                    ReadState = table.Column<int>(type: "integer", nullable: true),
                    WriteState = table.Column<int>(type: "integer", nullable: true),
                    TypePermissionObjectID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyMemberPermissionsObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyMemberPermissionsObjects_PermissionPolicyTy~",
                        column: x => x.TypePermissionObjectID,
                        principalTable: "PermissionPolicyTypePermissionObjects",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyObjectPermissionsObjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Criteria = table.Column<string>(type: "text", nullable: true),
                    ReadState = table.Column<int>(type: "integer", nullable: true),
                    WriteState = table.Column<int>(type: "integer", nullable: true),
                    DeleteState = table.Column<int>(type: "integer", nullable: true),
                    NavigateState = table.Column<int>(type: "integer", nullable: true),
                    TypePermissionObjectID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyObjectPermissionsObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyObjectPermissionsObjects_PermissionPolicyTy~",
                        column: x => x.TypePermissionObjectID,
                        principalTable: "PermissionPolicyTypePermissionObjects",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLoginInfos_LoginProviderName_ProviderUserKey",
                table: "ApplicationUserLoginInfos",
                columns: new[] { "LoginProviderName", "ProviderUserKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLoginInfos_UserID",
                table: "ApplicationUserLoginInfos",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CreatedById",
                table: "ApplicationUsers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_ExpiredById",
                table: "ApplicationUsers",
                column: "ExpiredById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_LastModifiedById",
                table: "ApplicationUsers",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserName_IsActive",
                table: "ApplicationUsers",
                columns: new[] { "UserName", "IsActive" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_AuditedObjectID",
                table: "AuditData",
                column: "AuditedObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_NewObjectID",
                table: "AuditData",
                column: "NewObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_OldObjectID",
                table: "AuditData",
                column: "OldObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_UserObjectID",
                table: "AuditData",
                column: "UserObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityName",
                table: "Cities",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedById",
                table: "Cities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ExpiredById",
                table: "Cities",
                column: "ExpiredById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LastModifiedById",
                table: "Cities",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDifferenceAspects_OwnerID",
                table: "ModelDifferenceAspects",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyActionPermissionObjects_RoleID",
                table: "PermissionPolicyActionPermissionObjects",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyMemberPermissionsObjects_TypePermissionObje~",
                table: "PermissionPolicyMemberPermissionsObjects",
                column: "TypePermissionObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyNavigationPermissionObjects_RoleID",
                table: "PermissionPolicyNavigationPermissionObjects",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyObjectPermissionsObjects_TypePermissionObje~",
                table: "PermissionPolicyObjectPermissionsObjects",
                column: "TypePermissionObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyRolePermissionPolicyUser_UsersID",
                table: "PermissionPolicyRolePermissionPolicyUser",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyTypePermissionObjects_RoleID",
                table: "PermissionPolicyTypePermissionObjects",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserLoginInfos");

            migrationBuilder.DropTable(
                name: "AuditData");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "DashboardsData");

            migrationBuilder.DropTable(
                name: "FileDatas");

            migrationBuilder.DropTable(
                name: "ModelDifferenceAspects");

            migrationBuilder.DropTable(
                name: "ModulesInfo");

            migrationBuilder.DropTable(
                name: "PermissionPolicyActionPermissionObjects");

            migrationBuilder.DropTable(
                name: "PermissionPolicyMemberPermissionsObjects");

            migrationBuilder.DropTable(
                name: "PermissionPolicyNavigationPermissionObjects");

            migrationBuilder.DropTable(
                name: "PermissionPolicyObjectPermissionsObjects");

            migrationBuilder.DropTable(
                name: "PermissionPolicyRolePermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "ReportDatasV2");

            migrationBuilder.DropTable(
                name: "AuditEFCoreWeakReference");

            migrationBuilder.DropTable(
                name: "ModelDifferences");

            migrationBuilder.DropTable(
                name: "PermissionPolicyTypePermissionObjects");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");
        }
    }
}
