using DevExpress.EntityFrameworkCore.Security;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppifySheets.Desktop.Launcher;

public class AppifySheetsDesktopApplication : WinApplication
{
    readonly IServiceProvider _serviceProvider;

    public AppifySheetsDesktopApplication(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
    {
        var dbFactory = _serviceProvider.GetService<IDbContextFactory<ApplicationDbContext>>();
        var efCoreObjectSpaceProvider = new SecuredEFCoreObjectSpaceProvider<ApplicationDbContext>((ISelectDataSecurityProvider)Security, dbFactory, TypesInfo);
        args.ObjectSpaceProviders.Add(efCoreObjectSpaceProvider);
        args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
    }

    protected override void OnSetupComplete()
    {
        base.OnSetupComplete();
            
        Model.Options.DataAccessMode = CollectionSourceDataAccessMode.Server;
    }

    protected override ApplicationModelManager CreateModelManager(IEnumerable<Type> boModelTypes)
    {
        var modelManager = base.CreateModelManager(boModelTypes);
        
        
        return modelManager;
    }
}