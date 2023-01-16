using System;
using System.Collections.Generic;
using AppifySheets.Blazor.Module.Controllers;
using AppifySheets.EfCore.ApplicationBase;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Core;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using EfCore.Infrastructure;

namespace AppifySheets.Blazor.Server;

public class BarbarosaApplication : AppifySheetsBlazorApplicationBase<ApplicationDbContext>
{
    protected override string ApplicationNameCore => "AppifySheets Template";
}