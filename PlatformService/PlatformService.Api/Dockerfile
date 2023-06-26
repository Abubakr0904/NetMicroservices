#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PlatformService.Api/PlatformService.Api.csproj", "PlatformService.Api/"]
COPY ["PlatformService.Db/PlatformService.Db.csproj", "PlatformService.Db/"]
COPY ["PlatformService.DependecyInjector/PlatformService.DependecyInjector.csproj", "PlatformService.DependecyInjector/"]
COPY ["PlatformService.Domain/PlatformService.Domain.csproj", "PlatformService.Domain/"]
COPY ["PlatformService.Repository/PlatformService.Repository.csproj", "PlatformService.Repository/"]
COPY ["PlatformService.Services/PlatformService.Services.csproj", "PlatformService.Services/"]
RUN dotnet restore "PlatformService.Api/PlatformService.Api.csproj"
COPY . .
WORKDIR "/src/PlatformService.Api"
RUN dotnet build "PlatformService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlatformService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlatformService.Api.dll"]