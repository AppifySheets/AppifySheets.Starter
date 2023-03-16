@echo off
set /p id="Enter Migration Name "

set ASPNETCORE_ENVIRONMENT=Development

dotnet ef migrations add %id% & dotnet ef database update

pause