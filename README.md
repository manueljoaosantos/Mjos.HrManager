# Mjos.HrManager
```
dotnet new sln
dotnet new classlib -o Mjos.HrManager.Application
dotnet new classlib -o Mjos.HrManager.Core
dotnet new classlib -o Mjos.HrManager.Infrastructure
dotnet sln add .\Mjos.HrManager.Application\
dotnet sln add .\Mjos.HrManager.Infrastructure\
dotnet sln add .\Mjos.HrManager.Core\

dotnet new xunit -o Mjos.HrManager.UnitTests
dotnet sln add .\Mjos.HrManager.UnitTests\
```