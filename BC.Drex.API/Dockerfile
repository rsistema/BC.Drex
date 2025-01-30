#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM postgres:15.3-alpine AS postgres
ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=admin@2025
ENV POSTGRES_DB=my_database
EXPOSE 5432

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BC.Drex.API/BC.Drex.API.csproj", "BC.Drex.API/"]
RUN dotnet restore "./BC.Drex.API/BC.Drex.API.csproj"
COPY . .
WORKDIR "/src/BC.Drex.API"
RUN dotnet build "./BC.Drex.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BC.Drex.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BC.Drex.API.dll"]