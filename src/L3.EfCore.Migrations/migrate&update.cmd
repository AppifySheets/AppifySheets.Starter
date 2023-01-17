@echo off
set /p id="Enter Migration Name "

dotnet ef migrations add %id% & dotnet ef database update

pause