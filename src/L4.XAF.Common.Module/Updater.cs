using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using L2.EfCore.Infrastructure;

namespace L4.XAF.Common.Module;

public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDbVersion) :
        base(objectSpace, currentDbVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        
        var userUser = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "User");
        if(userUser == null) {
            userUser = ObjectSpace.CreateObject<ApplicationUser>();
            userUser.UserName = "User";
            userUser.DisplayName = "User";
            // Set a password if the standard authentication type is used
            userUser.SetPassword("");

            // The UserLoginInfo object requires a user object Id (Oid).
            // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
            ObjectSpace.CommitChanges(); //This line persists created object(s).
            ((ISecurityUserWithLoginInfo)userUser).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(userUser));
        }
        // var defaultRole = CreateDefaultRole();
        // sampleUser.Roles.Add(defaultRole);

        const string admin = "Admin";
        var userAdmin = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == admin);
        if(userAdmin == null) {
            userAdmin = ObjectSpace.CreateObject<ApplicationUser>();
            userAdmin.UserName = admin;
            userAdmin.DisplayName = admin;
            // Set a password if the standard authentication type is used
            userAdmin.SetPassword("");

            // The UserLoginInfo object requires a user object Id (Oid).
            // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
            ObjectSpace.CommitChanges(); //This line persists created object(s).
            var loginInfo = ((ISecurityUserWithLoginInfo)userAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(userAdmin));
            //((ISecurityUserWithLoginInfo)userAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(userAdmin));
            ObjectSpace.CommitChanges(); //This line persists created object(s).
        }

        const string administrators = "Administrators";
        // If a role with the Administrators name doesn't exist in the database, create this role
        var adminRole = ObjectSpace.FirstOrDefault<ApplicationRole>(r => r.Name == administrators);
        if(adminRole == null) {
            adminRole = ObjectSpace.CreateObject<ApplicationRole>();
            adminRole.Name = administrators;
        }
        
        // If a role with the Users name doesn't exist in the database, create this role
        var userRole = ObjectSpace.FirstOrDefault<ApplicationRole>(role => role.Name == "Users");
        if(userRole == null) {
            userRole = ObjectSpace.CreateObject<ApplicationRole>();
            userRole.Name = "Users";
            userRole.PermissionPolicy = SecurityPermissionPolicy.AllowAllByDefault;
            userRole.AddNavigationPermission("Application/NavigationItems/Items/Default/Items/PermissionPolicyRole_ListView", SecurityPermissionState.Deny);
            userRole.AddNavigationPermission("Application/NavigationItems/Items/Default/Items/ApplicationUser_ListView", SecurityPermissionState.Deny);
            userRole.AddTypePermission<PermissionPolicyRole>(SecurityOperations.FullAccess, SecurityPermissionState.Deny);
            userRole.AddTypePermission<PermissionPolicyUser>(SecurityOperations.FullAccess, SecurityPermissionState.Deny);
            userRole.AddObjectPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.ReadOnlyAccess, cm => cm.ID == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
            userRole.AddMemberPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", null, SecurityPermissionState.Allow);
            userRole.AddMemberPermissionFromLambda<PermissionPolicyUser>(SecurityOperations.Write, "StoredPassword", null, SecurityPermissionState.Allow);
            userRole.AddTypePermission<PermissionPolicyTypePermissionObject>("Write;Delete;Create", SecurityPermissionState.Deny);
            userRole.AddTypePermission<PermissionPolicyMemberPermissionsObject>("Write;Delete;Create", SecurityPermissionState.Deny);
            userRole.AddTypePermission<PermissionPolicyObjectPermissionsObject>("Write;Delete;Create", SecurityPermissionState.Deny);
            userRole.AddTypePermission<PermissionPolicyNavigationPermissionObject>("Write;Delete;Create", SecurityPermissionState.Deny);
            userRole.AddTypePermission<PermissionPolicyActionPermissionObject>("Write;Delete;Create", SecurityPermissionState.Deny);
            userRole.AddObjectPermissionFromLambda<AuditDataItemPersistent>(SecurityOperations.Read, a => a.UserObject.Key != CurrentUserIdOperator.CurrentUserId().ToString(), SecurityPermissionState.Deny);
        }
        
        // If a user named 'John' doesn't exist in the database, create this user
        var user2 = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "John");
        if(user2 == null) {
            user2 = ObjectSpace.CreateObject<ApplicationUser>();
            user2.UserName = "John";
            user2.DisplayName = "John";
            // Set a password if the standard authentication type is used
            user2.SetPassword("");

            // The UserLoginInfo object requires a user object Id (Oid).
            // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
            ObjectSpace.CommitChanges(); //This line persists created object(s).
            ((ISecurityUserWithLoginInfo)user2).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(user2));
        }
        
        adminRole.IsAdministrative = true;
        userAdmin.Roles.Add(adminRole);
        userUser.Roles.Add(userRole);
        ObjectSpace.CommitChanges(); //This line persists created object(s).
    }
}