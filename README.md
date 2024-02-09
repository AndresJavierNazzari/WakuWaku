# WakuWak

Application that helps users to achieve mastery of a particular skill or set of skills over the course of a year.

1. Skill Selection: 
- Users start by selecting a skill they wanto to master over the year. It could be anything from learning a new language, masteing a musical instrument, becoming proficient in a programming language, or developing a new athletic skill.
2. Goal Setting: Users set specific, measurable, and achievable goals related to their chosen skill. These goals could include milestones, projectos, or levels of proficiency they aim to reach within the year.
3. Progress Tracking: The app allows users to track their progress over time. They can input achievements, completed lessons, or any relevan milestones. The app could visually represent their journey, providing a sense of accomplishment as they see how far thay've come.
4. Yearly Summary: At the end of the year, the app generates a summary of the user's journey, showcasing their achievements and progress. This summary can be shared on social media or kept as a personal record.

The goal of this Task is for you to architect a soluction for this given application, so you must use diagramas, images or pictures to show the architecture of the application and the Domain model.
You can use C4 Diagrams.

## Database Connection

### Step 1: Install PostgreSQL

Install PostgreSQL on your system. You can download it from the [official PostgreSQL website](https://www.postgresql.org/download/).

### Step 2: Create Database

Once PostgreSQL is installed, create the required database: `klockandb`.

### Step 3: Install Necessary Packages

Inside the `KlockanAPI.Infrastructure` directory, run the following commands to install the necessary packages:

```bash
Install-Package Microsoft.EntityFrameworkCore -Version 8.0.1
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.1
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.1
```

### Step 4: Update Password in `appsettings.json`

In the Presentation layer, update the password in `DefaultConnection`.

### Step 5: Database Migrations

Inside `KlockanAPI.Infrastructure`, follow these steps:

1. Set the default project to Infrastructure.
2. Run the following command to add a new migration:

   ```bash
   Add-Migration InitialCreate -OutputDir Data/Migrations
   ```

3. Update the database:
   ```bash
   Update-Database
   ```

#### Alternatively, you can use these .NET Core CLI commands:

1. Move to `KlockanAPI.Infrastructure` directory

   ```bash
   cd KlockanAPI/src/KlockanAPI.Infrastructure/
   ```

1. Run the following command to add a new migration:

   ```bash
   dotnet ef migrations add InitialCreate --output-dir Data/Migrations --project ../KlockanAPI.Infrastructure/ --startup-project ../KlockanAPI.Presentation/
   ```

1. Update the database:
   ```bash
   dotnet ef database update --project ../KlockanAPI.Infrastructure/ --startup-project ../KlockanAPI.Presentation/
   ```