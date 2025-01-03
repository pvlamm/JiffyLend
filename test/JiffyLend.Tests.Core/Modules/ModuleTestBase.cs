namespace JiffyLend.Tests.Core.Modules;

using Microsoft.AspNetCore.Mvc.Testing;

public abstract class ModuleTestBase
{
    protected readonly WebApplicationFactory<Program> _webAPIFactory;

    protected ModuleTestBase(FunctionalCoreWebAPIFactory webAPIFactory)
    {
        _webAPIFactory = webAPIFactory;
    }
}
