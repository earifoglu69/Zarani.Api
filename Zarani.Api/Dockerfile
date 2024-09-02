#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Zarani.Api/Zarani.Api.csproj", "Zarani.Api/"]
COPY ["Zarani.Application/Zarani.Application.csproj", "Zarani.Application/"]
COPY ["Zarani.Common/Zarani.Common.csproj", "Zarani.Common/"]
COPY ["Zarani.Domain/Zarani.Domain.csproj", "Zarani.Domain/"]
COPY ["Zarani.Infrastructure/Zarani.Infrastructure.csproj", "Zarani.Infrastructure/"]
RUN dotnet restore "./Zarani.Api/Zarani.Api.csproj"
COPY . .
WORKDIR "/src/Zarani.Api"
RUN dotnet build "./Zarani.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Zarani.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zarani.Api.dll"]