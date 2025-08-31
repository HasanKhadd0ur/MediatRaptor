# 🦖 MediatRaptor
---
## 📄 Project Description

**MediatRaptor** is a lightweight and extensible implementation of the **Mediator** pattern with built-in support for **CQRS (Command Query Responsibility Segregation)**.
It is designed as a modern, minimal alternative to heavier mediator libraries, providing developers with a clean and structured way to implement **Commands, Queries, Notifications, and Handlers**.

The library emphasizes:

* 📦 **Lightweight** – No unnecessary dependencies, minimal overhead.
* 🦖 **Mediator-first** – Core focus on mediator pattern with request/response pipelines.
* ⚡ **CQRS-ready** – First-class support for commands and queries.
* 🛠️ **Extensible** – Add behaviors like logging, validation, or caching with pipeline decorators.
* ✅ **Test-friendly** – Promotes separation of concerns and easy testing of handlers.


**MediatRaptor** is a lightweight implementation of the **Mediator** pattern with built-in support for **CQRS** (Command/Query Responsibility Segregation).  
Inspired by [MediatR](https://github.com/jbogard/MediatR), but built to be minimal, extensible, and fun.  

---

## ✨ Features
- 🦖 Clean Mediator abstraction (`IMediator`)  
- ⚡ CQRS-ready (Commands, Queries, Notifications)  
- 🔗 Pipeline behaviors (logging, validation, caching, etc.)  
- 🛠️ No external dependencies – minimal and fast  
- ✅ Easy to test, extend, and integrate  

---

## 📦 Installation

Coming soon to NuGet:  

```bash
dotnet add package MediatRaptor
````

---

## 📂 Project Structure

```
MediatRaptor/
│
├── src/
│   └── MediatRaptor/
│       ├── Mediator/       # Core mediator abstractions and pipeline
│       ├── CQRS/           # CQRS-specific slices (commands, queries, handlers)
│       └── MediatRaptor.csproj
│
├── examples/
│   └── ConsoleApp/         # Example project using MediatRaptor
│
├── tests/
│   └── MediatRaptor.Tests/ # Unit tests
│
└── README.md
```

---

## 🚀 Getting Started

### 1. Define a Command

```csharp
public record CreateUserCommand(string Username, string Email) : ICommand<Guid>;
```

### 2. Create a Handler

```csharp
public class CreateUserHandler : ICommandHandler<CreateUserCommand, Guid>
{
    public Task<Guid> Handle(CreateUserCommand command, CancellationToken ct)
    {
        // business logic
        return Task.FromResult(Guid.NewGuid());
    }
}
```

### 3. Use the Mediator

```csharp
var mediator = new MediatorRaptor(cfg =>
{
    cfg.RegisterHandlers(typeof(CreateUserHandler).Assembly);
});

var userId = await mediator.Send(new CreateUserCommand("hasan", "test@example.com"));
```

---

## 🧪 Examples

Check the [`examples/`](./examples) folder for runnable projects:

* **ConsoleApp** – basic CQRS setup with commands, queries, and handlers

---

## 🛠️ Roadmap

* [ ] Publish NuGet package
* [ ] Add notification/event broadcasting
* [ ] Add pipeline behaviors (logging, validation)
* [ ] ASP.NET Core integration package

---

## 📜 License

MIT – free to use, modify, and share.

