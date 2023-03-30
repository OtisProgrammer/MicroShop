#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/services/Ordering/Api/Ordering.Api/Ordering.Api.csproj", "src/services/Ordering/Api/Ordering.Api/"]
COPY ["src/BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "src/BuildingBlocks/EventBus.Messages/"]
COPY ["src/services/Ordering/Infrastructure/Ordering.Infrastructure.Persistence.Sql/Ordering.Infrastructure.Persistence.Sql.csproj", "src/services/Ordering/Infrastructure/Ordering.Infrastructure.Persistence.Sql/"]
COPY ["src/services/Ordering/Core/Ordering.Domain/Ordering.Domain.csproj", "src/services/Ordering/Core/Ordering.Domain/"]
COPY ["src/services/Ordering/Infrastructure/Ordering.Infrastructure.DependencyInjection/Ordering.Infrastructure.DependencyInjection.csproj", "src/services/Ordering/Infrastructure/Ordering.Infrastructure.DependencyInjection/"]
COPY ["src/services/Ordering/Core/Ordering.Application/Ordering.Application.csproj", "src/services/Ordering/Core/Ordering.Application/"]
RUN dotnet restore "src/services/Ordering/Api/Ordering.Api/Ordering.Api.csproj"
COPY . .
WORKDIR "/src/src/services/Ordering/Api/Ordering.Api"
RUN dotnet build "Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.Api.dll"]