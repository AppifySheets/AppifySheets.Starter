using AppifySheets.Barbarosa.Domain.Models;
using AppifySheets.EfCore.Infrastructure.DbContext;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using EfCore.Infrastructure;

namespace AppifySheets.Module;

public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDbVersion) :
        base(objectSpace, currentDbVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        
        var sampleUser = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "User");
        if(sampleUser == null) {
            sampleUser = ObjectSpace.CreateObject<ApplicationUser>();
            sampleUser.UserName = "User";
            // Set a password if the standard authentication type is used
            sampleUser.SetPassword("");

            // The UserLoginInfo object requires a user object Id (Oid).
            // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
            ObjectSpace.CommitChanges(); //This line persists created object(s).
            ((ISecurityUserWithLoginInfo)sampleUser).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(sampleUser));
        }
        // var defaultRole = CreateDefaultRole();
        // sampleUser.Roles.Add(defaultRole);

        const string admin = "Sam2";
        var userAdmin = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == admin);
        if(userAdmin == null) {
            userAdmin = ObjectSpace.CreateObject<ApplicationUser>();
            userAdmin.UserName = admin;
            // Set a password if the standard authentication type is used
            userAdmin.SetPassword("");

            // The UserLoginInfo object requires a user object Id (Oid).
            // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
            ObjectSpace.CommitChanges(); //This line persists created object(s).
            var loginInfo = ((ISecurityUserWithLoginInfo)userAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(userAdmin));
            //((ISecurityUserWithLoginInfo)userAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(userAdmin));
            ObjectSpace.CommitChanges(); //This line persists created object(s).
        }

        var administrators = "Administrators";
        // If a role with the Administrators name doesn't exist in the database, create this role
        var adminRole = ObjectSpace.FirstOrDefault<BarbarosaRole>(r => r.Name == administrators);
        if(adminRole == null) {
            adminRole = ObjectSpace.CreateObject<BarbarosaRole>();
            adminRole.Name = administrators;
        }
        adminRole.IsAdministrative = true;
        userAdmin.Roles.Add(adminRole);
        ObjectSpace.CommitChanges(); //This line persists created object(s).
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
    }

    // BarbarosaRole CreateDefaultRole() {
    //     const string user = "User";
    //
    //     var defaultRole = ObjectSpace.FirstOrDefault<BarbarosaRole>(role => role.Name == user);
    //     if (defaultRole != null) return defaultRole;
    //     
    //     defaultRole = ObjectSpace.CreateObject<BarbarosaRole>();
    //     defaultRole.Name = user;
    //
    //     defaultRole.AddObjectPermissionFromLambda<BarbarosaUser>(SecurityOperations.Read, cm => cm.ID == (int)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
    //     defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
    //     defaultRole.AddMemberPermissionFromLambda<BarbarosaUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", cm => cm.ID == (int)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
    //     defaultRole.AddMemberPermissionFromLambda<BarbarosaUser>(SecurityOperations.Write, "StoredPassword", cm => cm.ID == (int)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
    //     defaultRole.AddTypePermissionsRecursively<BarbarosaRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
    //     defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
    //     defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
    //     defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
    //     defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);
    //     defaultRole.AddTypePermission<AuditDataItemPersistent>(SecurityOperations.Read, SecurityPermissionState.Deny);
    //     defaultRole.AddObjectPermissionFromLambda<AuditDataItemPersistent>(SecurityOperations.Read, a => a.UserObject.Key == CurrentUserIdOperator.CurrentUserId().ToString(), SecurityPermissionState.Allow);
    //     defaultRole.AddTypePermission<AuditEFCoreWeakReference>(SecurityOperations.Read, SecurityPermissionState.Allow);
    //     return defaultRole;
    // }
}