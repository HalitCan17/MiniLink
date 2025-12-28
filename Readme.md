# 🚀 MiniLink - URL Shortener Service

MiniLink is a lightweight, high-performance URL shortening service built with the latest **.NET 10** and **ASP.NET Core MVC**. It demonstrates modern software architecture principles, including **N-Tier Architecture**, **Service Layer Pattern**, and **PostgreSQL** integration.

![.NET](https://img.shields.io/badge/.NET-10-purple)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue)
![License](https://img.shields.io/badge/License-MIT-green)

## ✨ Features
* **🔗 Smart URL Shortening:** Generates unique, collision-free short codes using a custom Base62 algorithm.
* **📊 Analytics Dashboard:** Tracks and displays click counts for every generated link.
* **⚡ Instant Redirection:** Redirects users to the original URL with low latency.
* **🛡️ Duplicate Prevention:** Checks if a URL is already shortened to optimize database usage.
* **📱 Responsive UI:** Clean and modern interface built with **Bootstrap 5**.

## 🛠️ Tech Stack & Architecture
This project follows the **Separation of Concerns** principle to ensure maintainability.

* **Backend:** C# / .NET 10 (ASP.NET Core MVC)
* **Database:** PostgreSQL (via Entity Framework Core)
* **ORM:** EF Core (Code-First Approach)
* **Dependency Injection:** Built-in .NET DI Container
* **Frontend:** Razor Views, Bootstrap 5

## 📂 Project Structure
The project is organized to separate interfaces (contracts) from their implementations:

```text
MiniLink/
├── Controllers/         # Handles HTTP requests and application flow
├── Data/                # EF Core DbContext and Database configurations
├── Models/              # Database Entities (ShortUrl.cs)
├── Services/            # Business Logic Layer
│   ├── Contracts/       # Interfaces defining system behavior (IUrlShorteningService)
│   └── UrlShorteningService.cs  # Implementation of the logic
├── Views/               # User Interface (Razor Pages)
├── wwwroot/             # Static files (CSS, JS, Images)
└── appsettings.json     # Database connection strings and configurations

🚀 How to Run the Project (Step-by-Step)
Follow these instructions to run the project on your local machine.

1️⃣ Prerequisites
Make sure you have the following installed:

.NET 10 SDK (or .NET 8.0+)
PostgreSQL (and a management tool like pgAdmin or Valentina Studio)
Git

2️⃣ Clone the Repository
Open your terminal and run:
git clone [https://github.com/YOUR_USERNAME/MiniLink.git](https://github.com/YOUR_USERNAME/MiniLink.git)
cd MiniLink

3️⃣ Configure the Database
Open the appsettings.json file.
Locate the ConnectionStrings section.
Update Username and Password with your local PostgreSQL credentials.

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=MiniLinkDb;Username=postgres;Password=YOUR_LOCAL_PASSWORD"
}

4️⃣ Create the Database (Migrations)
Run the following command in the terminal to apply the database schema:
dotnet ef database update

5️⃣ Run the Application
Start the server:
dotnet run