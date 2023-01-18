using AppifySheets.Users.Infrastructure;
using L1.Domain.BaseModels;

namespace L2.EfCore.Infrastructure;

public class ApplicationUserLoginInfo : ApplicationUserLoginInfo<ApplicationUser, BasicUser, ApplicationUserLoginInfo, ApplicationRole>
{
}
