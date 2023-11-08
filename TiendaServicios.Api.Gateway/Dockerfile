#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TiendaServicios.Api.Gateway/TiendaServicios.Api.Gateway.csproj", "TiendaServicios.Api.Gateway/"]
RUN dotnet restore "TiendaServicios.Api.Gateway/TiendaServicios.Api.Gateway.csproj"
COPY . .
WORKDIR "/src/TiendaServicios.Api.Gateway"
RUN dotnet build "TiendaServicios.Api.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TiendaServicios.Api.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendaServicios.Api.Gateway.dll"]