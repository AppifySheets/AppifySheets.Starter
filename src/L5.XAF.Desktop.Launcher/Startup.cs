using System.Net.Http;
using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.DbContext;
using AppifySheets.Users.Infrastructure;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Services;
using EfCore.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace AppifySheets.Desktop.Launcher;

public class Startup
{
    static readonly HttpClient HttpClient = new();
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =  configuration.GetConnectionString("ConnectionString");

        services.AddScoped(serviceProvider => ApplicationBuilder.BuildApplication(connectionString, serviceProvider));
        //var winApplication = ApplicationBuilder.BuildApplication(connectionString, services.BuildServiceProvider());

        // services.AddDbContextFactory<AppifySheetsEfCoreDbContext>(Configure, ServiceLifetime.Singleton);
        void Configure(IServiceProvider serviceProvider, DbContextOptionsBuilder options)
        {
            // Uncomment this code to use an in-memory database. This database is recreated each time the server starts. With the in-memory database, you don't need to make a migration when the data model is changed.
            // Do not use this code in production environment to avoid data loss.
            // We recommend that you refer to the following help topic before you use an in-memory database: https://docs.microsoft.com/en-us/ef/core/testing/in-memory
            //options.UseInMemoryDatabase("InMemory");
            // var connectionString = ;//.ConnectionString;// GetConnectionString() Configuration.GetConnectionString("ConnectionString");
            // options.UseSqlServer(connectionString);
            options.UseNpgsql(connectionString);
            options.UseLazyLoadingProxies();
            options.UseSecurity(serviceProvider);
            // options.UseAudit();
        }

        services.AddScoped<IObjectSerializer, JsonSerializer>();

        services.AddXafSecurity(options =>
        {
            options.Events.OnSecurityStrategyCreated = securityStrategy =>
            {
                ((SecurityStrategy)securityStrategy).AllowAnonymousAccess = true;

                // ((SecurityStrategy)securityStrategy).AnonymousAllowedTypes.Use(anonymousAllowedTypes =>
                // {
                //     anonymousAllowedTypes.Add(typeof(HospitalizationEventStore));
                //     anonymousAllowedTypes.Add(typeof(Clinic));
                //     anonymousAllowedTypes.Add(typeof(ClinicBeds));
                //     anonymousAllowedTypes.Add(typeof(ClinicService));
                //     anonymousAllowedTypes.Add(typeof(ClinicOutage));
                //     anonymousAllowedTypes.Add(typeof(Service));
                //     anonymousAllowedTypes.Add(typeof(ServiceGroupCategory));
                //     anonymousAllowedTypes.Add(typeof(ServiceGroup));
                // });
            };

            options.RoleType = typeof(ApplicationRole);
            // ApplicationUser descends from PermissionPolicyUser and supports the OAuth authentication. For more information, refer to the following topic: https://docs.devexpress.com/eXpressAppFramework/402197
            // If your application uses PermissionPolicyUser or a custom user type, set the UserType property as follows:
            options.UserType = typeof(ApplicationUser);
            // ApplicationUserLoginInfo is only necessary for applications that use the ApplicationUser user type.
            // If you use PermissionPolicyUser or a custom user type, comment out the following line:
            options.UserLoginInfoType = typeof(ApplicationUserLoginInfo);

            options.SupportNavigationPermissionsForTypes = false;
        });


        // services.AddSingleton<DevExpress.EntityFrameworkCore.Security.Infrastructure.ISecurityEnabledOption>();
        services.AddDbContextFactory<ApplicationDbContext>(Configure);
        services.AddSingleton<IDateTime, DateTimeWrapper>();
        services.AddSingleton(_ => HttpClient);
        
        // services.AddMediatR(typeof(OrderDetailCustomizationCommand).Assembly);
        // services.AddScoped<IDbContextFactory<AppifySheetsEfCoreDbContext>>();

        // services.AddAuditedDbContextFactory<AppifySheetsEfCoreDbContext, AppifySheetsAuditingDbContext>();

        // return services.AddScoped<IXafDbContextFactory<AppifySheetsEfCoreDbContext>>(serviceProvider => new dbcontextfactory<TBusinessObjectDbContext, TAuditHistoryDbContext>(ServiceProviderServiceExtensions.GetService<IDbContextFactory<TBusinessObjectDbContext>>(serviceProvider), ServiceProviderServiceExtensions.GetService<IDbContextFactory<TAuditHistoryDbContext>>(serviceProvider), ServiceProviderServiceExtensions.GetService<IAuditTrailServiceFactory>(serviceProvider))));
        // return services.AddScoped<IXafDbContextFactory<TBusinessObjectDbContext>, AuditedDbContextFactory<TBusinessObjectDbContext, TAuditHistoryDbContext>>((Func<IServiceProvider, AuditedDbContextFactory<TBusinessObjectDbContext, TAuditHistoryDbContext>>) (serviceProvider => new AuditedDbContextFactory<TBusinessObjectDbContext, TAuditHistoryDbContext>(ServiceProviderServiceExtensions.GetService<IDbContextFactory<TBusinessObjectDbContext>>(serviceProvider), ServiceProviderServiceExtensions.GetService<IDbContextFactory<TAuditHistoryDbContext>>(serviceProvider), ServiceProviderServiceExtensions.GetService<IAuditTrailServiceFactory>(serviceProvider))));


        // services.AddScoped<IXafDbContextFactory<AppifySheetsEfCoreDbContext>>(serviceProvider => new XafSampleDesignTimeDbContextFactory(serviceProvider.GetRequiredService<IDomainEventDispatcher>()));


        // services.AddDbContext<AppifySheetsEfCoreDbContext>((serviceProvider, options) => {
        //     // Uncomment this code to use an in-memory database. This database is recreated each time the server starts. With the in-memory database, you don't need to make a migration when the data model is changed.
        //     // Do not use this code in production environment to avoid data loss.
        //     // We recommend that you refer to the following help topic before you use an in-memory database: https://docs.microsoft.com/en-us/ef/core/testing/in-memory
        //     //options.UseInMemoryDatabase("InMemory");
        //     string connectionString = Configuration.GetConnectionString("ConnectionString");
        //     options.UseSqlServer(connectionString);
        //     options.UseLazyLoadingProxies();
        //     options.UseSecurity(serviceProvider);
        //     options.UseAudit();
        // });
        services.AddScoped<IDomainEventDispatcher, MediatrDomainEventDispatcher>();
        services.AddMediatR(typeof(MediatrDomainEventDispatcher).Assembly);
        // services.AddMediatR(typeof(OnClinicConfigurationChangedHandler).Assembly);
        services.AddDbContextFactory<AppifySheetsAuditingDbContext>((serviceProvider, options) =>
        {
            // var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // = Configuration.GetConnectionString("ConnectionString");
            // var connectionString = configuration.GetConnectionString("ConnectionString"); //.ConnectionString;// GetConnectionString() Configuration.GetConnectionString("ConnectionString");
            options.UseNpgsql(connectionString);
            options.UseLazyLoadingProxies();
        }, ServiceLifetime.Scoped);
    }
}

public class JsonSerializer : IObjectSerializer
{
    public string SerializeObject(object value)
    {
        return JsonConvert.SerializeObject(value);
    }

    public object? DeserializeObject(string value, Type type)
    {
        return JsonConvert.DeserializeObject(value, type);
    }
}