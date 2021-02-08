# Starta ett EF projekt

```cmd
dotnet new sln
dotnet new tool-manifest
dotnet tool install dotnet-ef
dotnet new classlib --lang C# -o myLib
dotnet sln add myLib
dotnet add myLib package Microsoft.EntityFrameworkCore.Sqlite
dotnet new xunit --lang C# -o myLibTest
dotnet sln add myLibTest
dotnet add myLibTest reference myLib
```
