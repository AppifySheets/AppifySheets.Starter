using System.ComponentModel;
using AppifySheets.Domain.Common;

namespace L1.Domain.BaseModels;

[DefaultProperty(nameof(DisplayName))]
public class BasicUser : BasicApplicationUser<BasicUser>
{
}