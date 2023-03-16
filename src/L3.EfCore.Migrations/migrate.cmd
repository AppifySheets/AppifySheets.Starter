dotnet tool install --global dotnet-ef

@echo off
set /p id="Enter Migration Name "

set ASPNETCORE_ENVIRONMENT=Development

dotnet ef migrations add %id% 

pause