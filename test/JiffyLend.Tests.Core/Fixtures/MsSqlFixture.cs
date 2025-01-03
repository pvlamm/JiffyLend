namespace JiffyLend.Tests.Core.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotNet.Testcontainers.Builders;

using Testcontainers.MsSql;

public sealed class MsSqlFixture : IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-CU16-ubuntu-22.04")
        .WithPassword("password")
        .WithPortBinding(6500, 1433)
        .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))
        .Build();

    public string ConnectionString => _msSqlContainer.GetConnectionString();

    public Task InitializeAsync()
    {
        return _msSqlContainer.StartAsync();
    }
    public Task DisposeAsync()
    {
        _msSqlContainer.DisposeAsync();
        return Task.CompletedTask;
    }
}
