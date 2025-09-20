# 📚 BookLibrary (Full-Stack .NET + Angular Test Project)

This project is built as part of the .NET Code Test.  
It demonstrates **Clean Architecture**, **best practices**, and a simple **Angular UI**.

## Technologies

- **Backend:** C# .NET (ASP.NET Core)
- **Database:** Any SQL or NoSQL database (configured in `appsettings.json`)
- **Frontend:** Angular / React / Vue.js (choose the one implemented)
- **Mapping:** AutoMapper (free version compatible with .NET Core)
- **Design Patterns:** Repository, Mediator, Strategy, Decorator, etc.

## Features

- Full CRUD operations for Books and Authors
- Proper error handling
- Clean architecture with layered project structure
- Scalable and maintainable code


## Project Structure

BookStore.sln
 ├── BookStore.Domain
 │    ├── Entities/        (Book, Author)
 │    ├── Exceptions/      (custom domain errors)
 │    └── Strategies/      (IDiscountStrategy + implementations)
 ├── BookStore.Application
 │    ├── Interfaces/      (IBookService, IRepositories)
 │    ├── Services/        (BookService, with validation & discount use)
 │    ├── Books/           (CQRS folders: Queries, Commands with MediatR)
 │    └── DTOs/            (BookDto, CreateBookDto, UpdateBookDto)
 ├── BookStore.Infrastructure
 │    └── Repositories/    (EF Core repositories for Book & Author)
 ├── BookStore.API
 │    ├── Controllers/     (BooksController – thin, uses MediatR)
 │    └── Program.cs       (DI, Swagger, CORS, MediatR, Strategy config)
 └── BookStore.UI (Angular)
      ├── core/services/   (BookService, AuthorService – API calls)
      └── features/books/  (BookList + BookForm standalone components)
 
 ## Setup Instructions

1. Clone the repository:

   ```bash
   git clone <repository-url>
   cd BookStoreDemo
   
2. Configure your database connection in appsettings.json.

3. Run database migrations (if using EF Core):
	dotnet ef database update
	
4. Restore dependencies and run the project:
	dotnet restore
	dotnet run
	
5. Navigate to the frontend folder and start the UI (if applicable):
	cd Frontend
	npm install
	npm start


