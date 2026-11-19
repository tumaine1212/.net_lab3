# Pig Pass (WinForms desktop app)

Pig farm registry and sick-pig reporting for African swine fever response.
Lab 3 project: Windows Forms + SQLite database + MVC architecture.

Student: Tumayine Desire | Lecturer: NDAGIJIMANA Adonia | Adventist University of Central Africa

## Features
- Login with roles (Administrator, Veterinarian, Farmer)
- Farm registry: add, view, update, deactivate, search (duplicate check by phone + sector)
- Sick/dead pig reports linked to a farm, with an automatic case reference number
- Data stored in a SQLite database (`pigpass.db`), created automatically on first run

## Architecture (MVC)
| Layer | Folder | Content |
|---|---|---|
| Model | `PigPass/Models` | User, Farm, SickReport, ReportRow |
| View | `PigPass/Views` | LoginForm, MainForm, FarmForm, ReportForm |
| Controller | `PigPass/Controllers` | AuthController, FarmController, ReportController, Session |
| Data | `PigPass/Data` | AppDbContext (EF Core), DbSeeder |

Forms never access the database directly; they call controllers.

## How to run
1. Install Visual Studio 2022 with the ".NET desktop development" workload (.NET 8 SDK).
2. Open `PigPass.sln` and press F5 (NuGet packages restore automatically).
3. Log in with a demo account:

| Username | Password | Role |
|---|---|---|
| admin | admin123 | Administrator |
| vet | vet123 | Veterinarian |
| farmer | farmer123 | Farmer |

## Technologies
C#, .NET 8, Windows Forms, Entity Framework Core 8, SQLite
