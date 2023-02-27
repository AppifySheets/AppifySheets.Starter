using AppifySheets.EfCore.Infrastructure.ProxyInfrastructure;
using CSharpFunctionalExtensions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.EFCore;
using L1.Domain.Models;

namespace L3.XAF.Common.Module;

[DomainComponent]
public class CityProxy : EntityXafProxy<City, long>
{
    public override bool OpenInPopup => true;

    protected override void UpdateValuesFromPersistent(City entity)
    {
        CityName = entity.CityName;
    }

    public string? CityName { get; set; }

    protected override Result<City> CreateEntityBeforeSaving()
        => new City
        {
            CityName = CityName,
        };

    protected override Result SaveCore(City entity)
    {
        return Result.Success();
    }

    public override string SaveExceptionHandler(Exception exception) => exception.Message;

    public CityProxy(City entity, EFCoreObjectSpace efCoreObjectSpace) : base(entity, efCoreObjectSpace)
    {
    }

    public CityProxy(EFCoreObjectSpace efCoreObjectSpace) : base(efCoreObjectSpace)
    {
    }
}