
# **Gestion des Personnes et Emplois - Application ASP.NET Core**

## **Description de l'application**

Cette application permet de g�rer des **personnes** et leurs **emplois**. Chaque personne peut avoir plusieurs emplois avec des chevauchements de dates. Les principales fonctionnalit�s incluent l'ajout de personnes et d'emplois, la r�cup�ration de listes de personnes, et la consultation des emplois par plage de dates ou par entreprise.

## **Fonctionnalit�s principales**

- Ajouter une personne (avec validation d'�ge).
- Ajouter un emploi � une personne (avec dates de d�but et de fin).
- Lister les personnes par ordre alphab�tique avec leur �ge et emploi(s) actuel(s).
- Lister les personnes ayant travaill� dans une entreprise donn�e.
- R�cup�rer les emplois d'une personne entre deux dates.

## **Pr�requis**

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

## **�tapes d'ex�cution**

### 2. **Configurer la cha�ne de connexion :**

Modifiez le fichier `appsettings.json` avec votre cha�ne de connexion SQL Server. Recherchez la section `ConnectionStrings` et mettez-la � jour comme suit :

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=GestionPersonnesEmploisDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Assurez-vous que les informations de connexion correspondent � votre configuration SQL Server.

### 3. **Restaurer les d�pendances :**

Dans le terminal, acc�dez au r�pertoire du projet et ex�cutez la commande suivante pour restaurer les packages n�cessaires :

```bash
dotnet restore
```

Une fois la commande ex�cut�e avec succ�s, tous les packages n�cessaires seront t�l�charg�s et pr�ts � �tre utilis�s dans le projet.

### 4. **Migration de la base de donn�es :**

Avant d'ex�cuter l'application, vous devez g�n�rer et appliquer la migration de la base de donn�es.

- **G�n�rer une migration :** Ex�cutez la commande suivante dans le terminal pour cr�er une migration initiale :

  ```bash
  dotnet ef migrations add InitialCreate
  ```

- **Appliquer la migration :** Ensuite, mettez � jour la base de donn�es avec la commande suivante :

  ```bash
  dotnet ef database update
  ```

Apr�s avoir ex�cut� ces commandes, la base de donn�es sera configur�e selon le mod�le d�fini dans le projet.

### 5. **Ex�cuter l'application :**

Apr�s avoir migr� la base de donn�es, vous pouvez d�marrer l'application avec :

```bash
dotnet run
```

Si la commande s'ex�cute correctement, vous verrez un message indiquant que l'application a d�marr�. L'application sera alors accessible � l'adresse suivante :

- **HTTP** : `http://localhost:5000`

### 6. **Acc�der � Swagger pour tester l'API :**

Swagger est int�gr� pour faciliter les tests des diff�rentes routes de l'API. Vous pouvez y acc�der via les liens suivants :

- **HTTP** : `http://localhost:5000/swagger`

## **Ports expos�s**

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

2. **Ajouter un emploi � une personne**
   - `POST /api/personnes/{id}/emploi`
   - Exemple de payload :
     ```json
     {
       "nomEntreprise": "TechCorp",
       "posteOccupe": "D�veloppeur",
       "dateDebut": "2018-05-15",
       "dateFin": "2020-03-30"
     }
     ```

3. **Lister les personnes par ordre alphab�tique**
   - `GET /api/personnes`

4. **Lister les personnes ayant travaill� dans une entreprise**
   - `GET /api/personnes/entreprise/{nomEntreprise}`

5. **Lister les emplois d'une personne entre deux dates**
   - `GET /api/personnes/{id}/emplois?startDate=yyyy-mm-dd&endDate=yyyy-mm-dd`

## **Besoins �nonc�s**

1. **Endpoints Cr��s :**
   - **Sauvegarder une nouvelle personne :** 
     - V�rifie que l'�ge de la personne est inf�rieur � 150 ans avant de l'enregistrer. 
     - Renvoie une erreur si la validation �choue.
   - **Ajouter un emploi � une personne :** 
     - Permet d'ajouter un emploi avec des dates de d�but et de fin.
     - La date de fin est facultative pour le poste actuellement occup�.
     - Supporte plusieurs emplois pour une m�me personne, m�me si les dates se chevauchent.
   - **Obtenir toutes les personnes :** 
     - Renvoie une liste de toutes les personnes enregistr�es par ordre alphab�tique.
     - Inclut l'�ge et les emplois actuels des personnes.
   - **Obtenir les personnes par entreprise :** 
     - Renvoie toutes les personnes ayant travaill� pour une entreprise donn�e.
   - **Obtenir les emplois d'une personne entre deux plages de dates :** 
     - Renvoie tous les emplois d'une personne en fonction de deux dates sp�cifi�es.

2. **Structure de l'application :**
   - Utilisation de ASP.NET Core avec Entity Framework pour la gestion de la base de donn�es.
   - La structure est conforme aux principes SOLID et utilise LINQ pour les requ�tes.
   - S�paration des pr�occupations � travers des couches (Contr�leurs, Services, Repositories).

3. **Documentation API :**
   - G�n�ration d'une documentation API utilisant Swagger.
   - Fournit une interface utilisateur pour tester les endpoints de l'API.

## **Auto-�valuation**

### **Points Positifs :**
- **Conformit� aux besoins :** L'application r�pond � toutes les exigences fonctionnelles �nonc�es dans le projet.
- **Validation :** La logique de validation pour l'enregistrement des personnes est correctement impl�ment�e.
- **Flexibilit� :** Permet de g�rer plusieurs emplois et d'effectuer des recherches selon divers crit�res.
- **Documentation :** La documentation API g�n�r�e avec Swagger est compl�te et facilite l'utilisation de l'API.

### **Axes d'Am�lioration :**
- **Tests Unitaires :** Ajouter des tests unitaires pour valider le comportement des endpoints et des services.
- **Gestion des erreurs :** Am�liorer la gestion des erreurs pour offrir des r�ponses plus d�taill�es en cas de probl�mes.
- **Optimisation des performances :** R�viser les requ�tes LINQ pour s'assurer qu'elles sont optimis�es pour des jeux de donn�es volumineux.
- **S�curit� :** Impl�menter des mesures de s�curit�, comme l'authentification et l'autorisation pour certaines op�rations.

