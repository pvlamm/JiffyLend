namespace JiffyLend.Tests.Core.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotNet.Testcontainers.Builders;

using Testcontainers.RabbitMq;

public sealed class RabbitMQFixture : IAsyncLifetime
{
    private readonly RabbitMqContainer _rabbitContainer = new RabbitMqBuilder()
        .WithImage("rabbitmq:3-management")
        .WithUsername("guest")
        .WithPassword("guest")
        .WithPortBinding(5600, 5672)
        .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5672))
        .Build();
    public Task InitializeAsync()
    {
        return _rabbitContainer.StartAsync();
    }

    public Task DisposeAsync()
    {
        _rabbitContainer.DisposeAsync();

        return Task.CompletedTask;
    }

}
