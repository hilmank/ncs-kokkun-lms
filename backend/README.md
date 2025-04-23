# 📘 API Development Flow – CQRS + DDD

This project follows the **Clean Architecture** approach using **CQRS** (Command Query Responsibility Segregation) and **Domain-Driven Design** principles.

---

## 🧱 1. Define the Database Schema
- Design tables and relationships (e.g., PostgreSQL, SQL Server)
- Use normalized structure with appropriate foreign keys
- Example: `Users`, `Courses`, `Assignments`, `Announcements`

---

## 🏗️ 2. Create Domain Entities
- Create entity classes in the **Domain Layer**
- Include core properties and business logic
- Avoid annotations or infrastructure concerns

```csharp
public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    // ...
}
```

---

## 📦 3. Define DTOs (Data Transfer Objects)
- Located in the **Shared Layer** or **Contracts**
- Use for incoming requests and outgoing responses
- Format `DateTime` as `string` (ISO 8601)

```csharp
public class CreateUserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    // ...
}
```

---

## 🧩 4. Create Application Interfaces
- Repositories (`IUserRepository`, `ICourseRepository`, etc.)
- Located in the **Application Layer**
- Abstract away persistence logic

```csharp
public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
}
```

---

## 🛠️ 5. Implement Repository Interfaces
- Located in **Infrastructure Layer**
- Use EF Core, Dapper, or custom SQL
- Connect directly to the database

```csharp
public class UserRepository : IUserRepository
{
    // Implementation using DbContext
}
```

---

## 💡 6. Create Commands & Queries
- Located in the **Application Layer**
- Each command/query uses MediatR’s `IRequest<T>`

```csharp
public record CreateUserCommand(string Username, string Email, string Password) : IRequest<Guid>;
```

---

## 🔧 7. Create Command & Query Handlers
- Handle write and read logic
- Use repositories + map to/from entities
- Apply business logic inside handlers

```csharp
public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // handle logic
    }
}
```

---

## ✅ 8. Add FluentValidation
- Validate incoming command data
- Use `AbstractValidator<TCommand>`

```csharp
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
```

---

## 🌐 9. Add API Controller Endpoints
- Accept DTOs via `[FromBody]`
- Call `_mediator.Send(command)`
- Return standard `IActionResult`

```csharp
[HttpPost]
public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
{
    var command = new CreateUserCommand(...);
    var id = await _mediator.Send(command);
    return Ok(id);
}
```

---

## 🧪 10. Testing (Optional but Recommended)
- Unit test handlers, validators, and repository logic
- Use in-memory DB for integration testing

---

## 🔁 11. Optional Enhancements
- Add caching (e.g., for queries)
- Audit trails (track changes)
- Authorization filters
- Pagination & filtering for list endpoints

---

## 🗂️ Project Folder Structure (Clean Architecture)

```plaintext
/src
│
├── 🧠 Domain                     # Business rules and core logic
│   ├── Entities                # Aggregates and domain models
│   ├── ValueObjects            # Immutable value types (e.g. Email, DateRange)
│
├── 🧩 Application               # Use cases and orchestration
│   ├── Interfaces             # Abstractions for repositories and services
│   ├── DTOs                   # Transport objects for API↔Application
│   ├── Commands               # Write actions (create, update, delete)
│   ├── Queries                # Read actions (get, list)
│   ├── Handlers               # Command/Query logic
│   └── Validators             # FluentValidation rules
│
├── 🏗 Infrastructure            # External system interaction
│   ├── Persistence
│   │   ├── Queries            # Dapper-based SQL logic
│   │   └── Repositories      # Implements domain interfaces
│   └── Services               # Utilities like DbConnectionFactory, SMTP
│
├── 🌐 API                       # HTTP Layer
│   ├── Controllers            # Web endpoints
│   └── Middlewares           # Error handling, logging, auth
│
├── ♻️ Shared                   # Common/shared resources
│   ├── DTOs                   # Cross-context data models
│   └── Utilities              # Time providers, extensions, helpers
│
└── 🧪 Tests                     # Test projects
    ├── DomainTests
    ├── ApplicationTests
    ├── InfrastructureTests
    ├── APITests
    └── SharedTests
```

## 📄 Description by Layer
- **Domain:** Pure business rules with no dependencies
- **Application:** Defines behaviors with no infrastructure
- **Infrastructure:** Implements interfaces using external systems
- **API:** Entry point, defines endpoints and dependencies
- **Shared:** Common contracts, DTOs, and utilities

