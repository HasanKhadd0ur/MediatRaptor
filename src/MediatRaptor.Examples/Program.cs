using MediatRaptor.Examples.Examples.PingPongExample;
using MediatRaptor.Examples.Notifications;
using MediatRaptor.Mediator.Abstractions;
using MediatRaptor.Mediator.Core;
using Microsoft.Extensions.DependencyInjection;

// Setup DI
var services = new ServiceCollection();

// Register MediatRaptor
services.AddMediatRaptor(typeof(PingCommand).Assembly);
services.AddMediatRaptor(typeof(NotificationDemo).Assembly);

// Build provider
var provider = services.BuildServiceProvider();

// Resolve mediator
var mediator = provider.GetRequiredService<IMediator>();

// Run Ping → Pong example
Console.WriteLine("Sending PingCommand...");
var result = await mediator.Send(new PingCommand("Hello from Ping!"));

Console.WriteLine($"[Request Result] {result}");

// Run Notifications Demo 
var NotificationDemo = new NotificationDemo(mediator);

await NotificationDemo.Run();
