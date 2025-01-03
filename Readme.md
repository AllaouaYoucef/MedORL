# Gestion de Cabinet ORL - Application Web MVC

## Description

Cette application web MVC, développée avec .NET Core, est conçue pour la gestion d'un cabinet ORL (Oto-Rhino-Laryngologie). Elle permet de gérer les patients, les rendez-vous, les ordonnances et l'historique des dossiers médicaux de manière efficace et sécurisée.

L'application est basée sur une architecture 3-layer (présentation, logique métier, accès aux données) pour une meilleure modularité et maintenabilité.

## Fonctionnalités principales
### Gestion des Patients :

- Ajouter, modifier, supprimer et consulter les informations des patients.

- Rechercher des patients par nom, prénom ou numéro de dossier.

### Gestion des Rendez-vous :

- Planifier, modifier et annuler des rendez-vous.

- Visualiser le calendrier des rendez-vous par jour, semaine ou mois.

### Gestion des Ordonnances :

- Créer, éditer et archiver des ordonnances.

- Associer des ordonnances à un patient et à un rendez-vous.

### Historique des Dossiers Patients :

- Consulter l'historique complet des consultations, diagnostics et traitements d'un patient.

- Exporter l'historique au format PDF.

## Architecture 3-Layer
L'application est structurée en trois couches principales :

### Présentation (Presentation Layer) :

- Contient les vues (Views), les contrôleurs (Controllers) et les modèles de vue (ViewModels).

- Gère l'interaction avec l'utilisateur et l'affichage des données.

### Logique Métier (Business Logic Layer) :

- Contient les services métier et les règles de gestion.

- Valide les données et applique la logique spécifique au domaine.

### Accès aux Données (Data Access Layer) :

- Gère l'interaction avec la base de données.

- Utilise Entity Framework Core pour les opérations CRUD (Create, Read, Update, Delete).

## Technologies utilisées
- Backend : .NET Core 6 (ou version ultérieure)

- Frontend : ASP.NET Core MVC, Razor Views, HTML/CSS, JavaScript (optionnel)

- Base de données : SQL Server (ou autre SGBD compatible avec Entity Framework Core)

- ORM : Entity Framework Core

- Authentification : ASP.NET Core Identity (optionnel pour la gestion des utilisateurs)

- Autres outils : LINQ, AutoMapper (pour le mapping des DTOs), Dependency Injection
