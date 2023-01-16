using AppifySheets.EfCore.Infrastructure;

namespace EfCore.Infrastructure;

public static class ConnectionStringsInitializer
{
    public static void InitializeConnectionStrings()
    {
        ConnectionStrings.SetDevelopmentConnectionString(DevelopmentConnectionString);
        ConnectionStrings.SetProductionConnectionString(ProductionConnectionString);
    }

    const string ProductionConnectionString = "Server=postgres;Port=5432;Database=appifysheets;User Id=_appifysheets_user_;Password=ryI^^Tn7%rl39X2TbpI6l";
    const string DevelopmentConnectionString = "Server=postgres;Port=5432;Database=appifysheets;User Id=_appifysheets_user_;Password=ryI^^Tn7%rl39X2TbpI6l";
}