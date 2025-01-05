set edition=001

dotnet ef migrations add %edition%-Updates -s .\src\JiffyLend.WebAPI\ -p .\src\JiffyLend.Module.Core.Infrastructure\JiffyLend.Module.Core.Infrastructure.csproj -c CoreDbContext -v
dotnet ef migrations add %edition%-Updates -s .\src\JiffyLend.WebAPI\ -p .\src\JiffyLend.Module.Card.Infrastructure\JiffyLend.Module.Card.Infrastructure.csproj -c CardDbContext -v
