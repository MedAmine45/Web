
# **Gestion des Personnes et Emplois - Application ASP.NET Core**

## **Description de l'application**

Cette application permet de gérer des **personnes** et leurs **emplois**. Chaque personne peut avoir plusieurs emplois avec des chevauchements de dates. Les principales fonctionnalités incluent l'ajout de personnes et d'emplois, la récupération de listes de personnes, et la consultation des emplois par plage de dates ou par entreprise.

## **Fonctionnalités principales**

- Ajouter une personne (avec validation d'âge).
- Ajouter un emploi à une personne (avec dates de début et de fin).
- Lister les personnes par ordre alphabétique avec leur âge et emploi(s) actuel(s).
- Lister les personnes ayant travaillé dans une entreprise donnée.
- Récupérer les emplois d'une personne entre deux dates.

## **Prérequis**

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

## **Étapes d'exécution**

### 2. **Configurer la chaîne de connexion :**

Modifiez le fichier `appsettings.json` avec votre chaîne de connexion SQL Server. Recherchez la section `ConnectionStrings` et mettez-la à jour comme suit :

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=GestionPersonnesEmploisDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Assurez-vous que les informations de connexion correspondent à votre configuration SQL Server.

### 3. **Restaurer les dépendances :**

Dans le terminal, accédez au répertoire du projet et exécutez la commande suivante pour restaurer les packages nécessaires :

```bash
dotnet restore
```

Une fois la commande exécutée avec succès, tous les packages nécessaires seront téléchargés et prêts à être utilisés dans le projet.

### 4. **Migration de la base de données :**

Avant d'exécuter l'application, vous devez générer et appliquer la migration de la base de données.

- **Générer une migration :** Exécutez la commande suivante dans le terminal pour créer une migration initiale :

  ```bash
  dotnet ef migrations add InitialCreate
  ```

- **Appliquer la migration :** Ensuite, mettez à jour la base de données avec la commande suivante :

  ```bash
  dotnet ef database update
  ```

Après avoir exécuté ces commandes, la base de données sera configurée selon le modèle défini dans le projet.

### 5. **Exécuter l'application :**

Après avoir migré la base de données, vous pouvez démarrer l'application avec :

```bash
dotnet run
```

Si la commande s'exécute correctement, vous verrez un message indiquant que l'application a démarré. L'application sera alors accessible à l'adresse suivante :

- **HTTP** : `http://localhost:5000`

### 6. **Accéder à Swagger pour tester l'API :**

Swagger est intégré pour faciliter les tests des différentes routes de l'API. Vous pouvez y accéder via les liens suivants :

- **HTTP** : `http://localhost:5000/swagger`

## **Ports exposés**

- **HTTP** : `5000`

## **Appels API**

1. **Ajouter une personne**
   - `POST /api/personnes`
   - Exemple de payload :
     ```json
     {
       "nom": "Dupont",
       "prenom": "Jean",
       "dateDeNaissance": "1980-05-15"
     }
     ```

2. **Ajouter un emploi à une personne**
   - `POST /api/personnes/{id}/emploi`
   - Exemple de payload :
     ```json
     {
       "nomEntreprise": "TechCorp",
       "posteOccupe": "Développeur",
       "dateDebut": "2018-05-15",
       "dateFin": "2020-03-30"
     }
     ```

3. **Lister les personnes par ordre alphabétique**
   - `GET /api/personnes`

4. **Lister les personnes ayant travaillé dans une entreprise**
   - `GET /api/personnes/entreprise/{nomEntreprise}`

5. **Lister les emplois d'une personne entre deux dates**
   - `GET /api/personnes/{id}/emplois?startDate=yyyy-mm-dd&endDate=yyyy-mm-dd`

## **Besoins Énoncés**

1. **Endpoints Créés :**
   - **Sauvegarder une nouvelle personne :** 
     - Vérifie que l'âge de la personne est inférieur à 150 ans avant de l'enregistrer. 
     - Renvoie une erreur si la validation échoue.
   - **Ajouter un emploi à une personne :** 
     - Permet d'ajouter un emploi avec des dates de début et de fin.
     - La date de fin est facultative pour le poste actuellement occupé.
     - Supporte plusieurs emplois pour une même personne, même si les dates se chevauchent.
   - **Obtenir toutes les personnes :** 
     - Renvoie une liste de toutes les personnes enregistrées par ordre alphabétique.
     - Inclut l'âge et les emplois actuels des personnes.
   - **Obtenir les personnes par entreprise :** 
     - Renvoie toutes les personnes ayant travaillé pour une entreprise donnée.
   - **Obtenir les emplois d'une personne entre deux plages de dates :** 
     - Renvoie tous les emplois d'une personne en fonction de deux dates spécifiées.

2. **Structure de l'application :**
   - Utilisation de ASP.NET Core avec Entity Framework pour la gestion de la base de données.
   - La structure est conforme aux principes SOLID et utilise LINQ pour les requêtes.
   - Séparation des préoccupations à travers des couches (Contrôleurs, Services, Repositories).

3. **Documentation API :**
   - Génération d'une documentation API utilisant Swagger.
   - Fournit une interface utilisateur pour tester les endpoints de l'API.

## **Auto-évaluation**

### **Points Positifs :**
- **Conformité aux besoins :** L'application répond à toutes les exigences fonctionnelles énoncées dans le projet.
- **Validation :** La logique de validation pour l'enregistrement des personnes est correctement implémentée.
- **Flexibilité :** Permet de gérer plusieurs emplois et d'effectuer des recherches selon divers critères.
- **Documentation :** La documentation API générée avec Swagger est complète et facilite l'utilisation de l'API.

### **Axes d'Amélioration :**
- **Tests Unitaires :** Ajouter des tests unitaires pour valider le comportement des endpoints et des services.
- **Gestion des erreurs :** Améliorer la gestion des erreurs pour offrir des réponses plus détaillées en cas de problèmes.
- **Optimisation des performances :** Réviser les requêtes LINQ pour s'assurer qu'elles sont optimisées pour des jeux de données volumineux.
- **Sécurité :** Implémenter des mesures de sécurité, comme l'authentification et l'autorisation pour certaines opérations.

