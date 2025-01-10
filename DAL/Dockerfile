# Utiliser le .NET SDK pour compiler la couche d'accès aux données
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

COPY ./DAL ./DAL
WORKDIR /app/DAL
RUN dotnet build
