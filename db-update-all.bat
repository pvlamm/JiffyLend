dotnet ef database update -s .\src\JiffyLend.WebAPI\ -p .\src\JiffyLend.Module.Core.Infrastructure\ -c CoreDbContext -v
dotnet ef database update -s .\src\JiffyLend.WebAPI\ -p .\src\JiffyLend.Module.Card.Infrastructure\ -c CardDbContext -v

