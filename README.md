Fullstack PC Store project using ASP.NET, Blazor and EF Core
SQLite was more of a requirement, than a choice
PJATK TIN Project

# Build instructions

Install .net SDK 10
https://dotnet.microsoft.com/en-us/download/dotnet/10.0

```
git clone https://github.com/YAUIO/TIN-PRO.git
cd TIN-PRO
dotnet restore
dotnet ef database update -s TIN.Api -p TIN.Data
dotnet build
```

## Backend:
```
dotnet run --project TIN.Api
```
Db connection string is in TIN.Api/appsettings.json


## Frontend: Two options
### Serve via any http server as SPA
```
dotnet publish
cd bin/Release/net10.0/publish/wwwroot

// serve
python3 -m http.server 5221
```
Backend connection string is in appsettings.json


### Serve via dotnet
```
dotnet run --project TIN.Frontend

// serve
python3 -m http.server 5221
```
Backend connection string is in TIN.Api/appsettings.json
