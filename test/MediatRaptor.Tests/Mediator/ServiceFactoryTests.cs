using FluentAssertions;
using MediatRaptor.Mediator.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRaptor.Tests.Mediator
{
    public class ServiceFactoryTests
    {
        [Fact]
        public void GetInstance_Should_Return_Registered_Service()
        {
            var services = new ServiceCollection();
            services.AddSingleton<string>("Hello");
            var provider = services.BuildServiceProvider();

            ServiceFactory factory = t => provider.GetService(t);
            var result = factory.GetInstance<string>(typeof(string));

            result.Should().Be("Hello");
        }

        [Fact]
        public void GetInstances_Should_Return_Empty_If_NotRegistered()
        {
            var services = new ServiceCollection();
            var provider = services.BuildServiceProvider();

            ServiceFactory factory = t => provider.GetService(t);
            var results = factory.GetInstances<string>(typeof(string));

            results.Should().BeEmpty();
        }
    }
}
