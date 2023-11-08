#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TiendaServicios.Api.Libro/TiendaServicios.Api.Libro.csproj", "TiendaServicios.Api.Libro/"]
RUN dotnet restore "TiendaServicios.Api.Libro/TiendaServicios.Api.Libro.csproj"
COPY . .
WORKDIR "/src/TiendaServicios.Api.Libro"
RUN dotnet build "TiendaServicios.Api.Libro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TiendaServicios.Api.Libro.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendaServicios.Api.Libro.dll"]