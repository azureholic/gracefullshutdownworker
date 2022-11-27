
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "GracefullEvictionWorker.dll"]