# Utiliser le .NET SDK pour compiler la couche logique métier
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

COPY ./BLL ./BLL
WORKDIR /app/BLL
RUN dotnet build
