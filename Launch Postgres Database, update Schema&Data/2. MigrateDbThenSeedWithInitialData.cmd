echo "Updating database schema with initial migrations"
dotnet ef database update --project ..\src\L3.EfCore.Migrations\L3.EfCore.Migrations.csproj
..\src\L3.EfCore.Migrations\update-database.cmd

echo "Seeding database"

dotnet run --project "..\src\L5.XAF.Blazor.Server\L5.XAF.Blazor.Server.csproj" --updateDatabase --silent

echo "DONE updating database Schema & Data"

pause