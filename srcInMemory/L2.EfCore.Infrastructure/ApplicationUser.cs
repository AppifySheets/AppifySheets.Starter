using System.ComponentModel;
using AppifySheets.Users.Infrastructure;
using L1.Domain.BaseModels;

namespace L2.EfCore.Infrastructure;

[DefaultProperty(nameof(DisplayName))]
// ReSharper disable once ClassNeverInstantiated.Global
public class ApplicationUser : ApplicationUserBase<ApplicationUser, BasicUser, ApplicationUserLoginInfo, ApplicationRole>
{
    protected override ApplicationUserLoginInfo Creator() => new();
}