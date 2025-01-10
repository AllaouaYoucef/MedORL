# Étape 1 : Utiliser l'image .NET SDK pour compiler
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier les projets dans le conteneur
COPY ./WebUi ./WebUi
COPY ./BLL ./BLL
COPY ./DAL ./DAL

# Restaurer les dépendances
WORKDIR /app/WebUi
RUN dotnet restore

# Compiler et publier
RUN dotnet publish -c Release -o /publish

# Étape 2 : Utiliser l'image runtime pour l'exécution
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .

ENV ASPNETCORE_HTTP_PORTS=46535
# Exposer le port utilisé par l'application
EXPOSE 46535
EXPOSE 44307

ENTRYPOINT ["dotnet", "WebUi.dll"]
