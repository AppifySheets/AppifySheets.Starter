mkdir c:\root\.nuget\packages
mkdir /root/.nuget/packages

dotnet tool install --global dotnet-ef

set ASPNETCORE_ENVIRONMENT=Development

echo "Updating database schema with initial migrations"
dotnet ef database update --project ..\src\L3.EfCore.Migrations\L3.EfCore.Migrations.csproj

echo "Seeding database"

dotnet run --project "..\src\L5.XAF.Blazor.Server\L5.XAF.Blazor.Server.csproj" --updateDatabase --silent

echo "DONE updating database Schema & Data"

pause