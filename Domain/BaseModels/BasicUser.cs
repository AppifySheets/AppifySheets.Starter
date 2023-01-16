using System.ComponentModel;
using AppifySheets.Domain.Common;

namespace AppifySheets.Barbarosa.Domain.BaseModels;

[DefaultProperty(nameof(DisplayName))]
public class BasicUser : BasicApplicationUser<BasicUser>
{
}