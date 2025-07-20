
# 🏡 MagicVilla – Property Management System  
*Built with ASP.NET Core MVC & RESTful API*


---

## 🌟 Overview  
**MagicVilla** is a comprehensive property management system built with **ASP.NET Core MVC** and a fully decoupled **RESTful API** backend.  
It provides complete features for managing villas, user authentication, admin dashboard, and role-based access control.

---

## ✨ Key Features  

### 🏠 Villa Management  
- Full CRUD operations for villas and villa numbers  
- Image upload and media management  
- Special details and availability tracking  
- Pricing and occupancy control  

### 🔐 Secure Authentication  
- JWT-based authentication for API access  
- Role-based access control (Admin / Customer)  
- Cookie-based session management for MVC frontend  
- User registration, login, and logout flows  

### 📊 API Features  
- RESTful endpoints with appropriate HTTP status codes  
- Global error handling middleware  
- Request validation using **Data Annotations**  
- API documentation via **Swagger/OpenAPI**

---

## 🛠️ Technology Stack  

### 🔙 Backend  
- ASP.NET Core 8.0  
- Entity Framework Core  
- AutoMapper  
- JWT Authentication  
- Newtonsoft.Json  

### 🎨 Frontend  
- Razor Views (MVC)  
- Bootstrap 5  
- jQuery  

### 🧱 Architecture  
- Repository Pattern  
- Unit of Work  
- DTO Pattern  
- Clean Layered Architecture  

---

## 📂 Project Structure  

MagicVilla/
├── Controllers/ # MVC and API controllers
├── Models/ # Domain models and DTOs
├── Services/ # Business logic services
├── Utilities/ # Constants and helper classes
├── Views/ # Razor views
├── wwwroot/ # Static files (CSS, JS, images)
└── appsettings.json # App configuration and connection strings

## 🚀 Getting Started  

### ✅ Prerequisites  
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- SQL Server  
- Visual Studio 2022 or VS Code  

### 📦 Installation  

1. **Clone the repository**  
   ```bash
   git clone https://github.com/yourusername/MagicVilla_API.git
Configure the database in appsettings.json

Apply EF Core migrations
dotnet ef database update
Run the application
dotnet run
### 🔧 Configuration
Set your JWT secret key in appsettings.json

Configure base URLs for API services

Set up email service for sending notifications (optional)

### 📘 API Documentation
Once the project is running locally, access the Swagger UI:
https://localhost:{your-port}/swagger
This provides detailed documentation for all available endpoints.

### 🤝 Contributing
We welcome contributions from the community! To contribute:

Fork the repository

Create a new feature branch

Commit your changes

Push to your branch

Open a Pull Request

### 📄 License
Distributed under the MIT License.
See the LICENSE file for more information.

### 📧 Contact
Your Name – mohamedmongy96@gmail.com

Project Link: https://github.com/M-Mongy/MagicVilla_API
