FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY FarmerAPI.sln .
COPY FarmerAPI/FarmerAPI.csproj FarmerAPI/
RUN dotnet restore

COPY . .
RUN dotnet publish FarmerAPI/FarmerAPI.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

EXPOSE 5000
ENTRYPOINT ["dotnet", "FarmerAPI.dll"]
