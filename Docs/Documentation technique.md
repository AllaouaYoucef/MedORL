# Documentation Technique : Application Web pour un Cabinet Médical ORL
## Table des Matières

1- Introduction

2- Architecture de l'Application

3- Technologies Utilisées

4- Structure des Couches

- Couche de Présentation (MVC)

- Couche de Service (Business Layer)

- Couche de Données (Data Access Layer)

5- Configurations Clés

- AutoMapper

- ILogger

6- Base de Données

- Conception (Data-First)

- Connexion à SQL Server

7- Gestion de Version avec GitHub

8- Déploiement et Environnement

9- Tests et Maintenance



## 1. Introduction

Cette application web gère les opérations quotidiennes d'un cabinet médical spécialisé en ORL. Elle fournit des fonctionnalités pour gérer les patients, les rendez-vous, et les rapports médicaux, tout en garantissant une interface utilisateur intuitive et une performance optimale.

## 2. Architecture de l'Application

L'application utilise une architecture 3-Layer :

- Couche de présentation (MVC) : Gère les interactions utilisateur.

- Couche de service (Business Layer) : Contient la logique métier.

- Couche d’accès aux données (DAL) : Gère l'accès à la base de données.

Cette architecture garantit une séparation claire des responsabilités, facilitant la maintenance et l'évolutivité.

## 3. Technologies Utilisées

- Framework : .NET Core (Version 6 ou supérieure)

- Architecture : MVC

- Base de données : SQL Server (modèle Data-First)

- Automapper : Mapping des objets entre les couches.

- ILogger : Journalisation centralisée des logs.

- Contrôle de version : GitHub

- Gestion de projet : Jira

## 4. Structure des Couches

### 4.1 Couche de Présentation (MVC)

Cette couche utilise le modèle MVC pour organiser le code en trois composants principaux :

- Modèles : Définissent les structures de données utilisées par la vue.

- Vues : Génèrent l'interface utilisateur avec Razor.

- Contrôleurs : Gèrent les requêtes HTTP et la logique de navigation.

### 4.2 Couche de Service (Business Logic Layer - BLL)

- Contient les services pour implémenter la logique métier.

- Utilise des DTOs (Data Transfer Objects) pour transmettre les données entre les couches (Dossier Models).

- Exemple de service : Gestion des rendez-vous.

### 4.3 Couche d'Accès aux Données (Data Acces Layer - DAL)

- Implémente l'accès aux données via Entity Framework.

- Réalise le modèle "Data-First" pour générer des entités directement à partir de la base de données.

- Exemple : Requêtes LINQ pour interagir avec la base.

## 5. Configurations Clés

### 5.1 AutoMapper

AutoMapper est utilisé pour mapper automatiquement les entités et les DTOs.

Configuration

Dans Program.cs :


```rb
builder.Services.AddAutoMapper(typeof(AutoMapperProfileBLL), typeof(AutoMapperProfileWebUi));
```
Créez des profils de mappage dans chaque projet :

```rb
public class AutoMapperProfileWebUi : Profile
{
    public AutoMapperProfileWebUi()
    {
        CreateMap<Patient, PatientDto>();
        CreateMap<Appointment, AppointmentDto>();
    }
}
```
### 5.2 ILogger

ILogger fournit une gestion centralisée des logs pour surveiller l’application.

Exemple d’implémentation :

Dans Program.cs :
```rb
 // Configuration de la journalisation
 builder.Logging.ClearProviders(); // Supprime les fournisseurs de logs par défaut
 builder.Logging.AddConsole();     // Ajoute la journalisation dans la console
 builder.Logging.AddDebug();       // Ajoute la journalisation dans la sortie de débogage
 builder.Logging.AddEventSourceLogger(); // Ajoute la journalisation EventSource
```
Dans un contrôleur ou service :
```rb
private readonly ILogger<AppointmentService> _logger;

public AppointmentService(ILogger<AppointmentService> logger)
{
    _logger = logger;
}

public void ScheduleAppointment(Appointment appointment)
{
    _logger.LogInformation("Scheduling appointment for patient ID {0}", appointment.PatientId);
}
```

# 6. Base de Données

## 6.1 Conception ~~~ a faire

La base de données suit un modèle relationnel avec des tables pour :

- Patients : Informations personnelles.

- Appointments : Gestion des rendez-vous.

...

## 6.2 Connexion à SQL Server

Configurer la connexion dans appsettings.json :

```rb
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ORLClinic;Trusted_Connection=True;"
}
```

Injection du contexte dans program.cs :
```rb
// Add services to the container.
builder.Services.AddDbContext<OrlManagementContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
```
# 7. Gestion de Version avec GitHub

## Workflow Git
### 1- Branches principales :

### main :
- Contient le code prêt pour la production.
- Chaque commit sur main doit être stable et testé.
### develop :
- Contient le code de la version en cours de développement.
- Sert de base pour intégrer des fonctionnalités avant leur validation finale.

### 2- Branches secondaires :

### - feature/nom-fonctionnalité :
- Utilisée pour le développement de nouvelles fonctionnalités ou améliorations.
- Basée sur develop.
### - hotfix/nom-correctif :
- Utilisée pour des corrections urgentes sur main.
- asée sur main et fusionnée dans main et develop.
### -release/nom-version :
- Prépare une version avant son déploiement.
- Basée sur develop et fusionnée dans main.



8. Déploiement et Environnement ~~ a revoir 

- Déploiement : Utilisez Azure App Service ou IIS pour héberger l’application.

- CI/CD : Configurez GitHub Actions pour automatiser le déploiement.

- Fichiers sensibles : Assurez-vous que appsettings.json contient des placeholders pour les environnements de production.








