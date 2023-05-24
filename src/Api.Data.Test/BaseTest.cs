using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test;

public abstract class BaseTest
{
    public BaseTest()
    {

    }
}

public class DbTeste : IDisposable
{
    private string databaseName = $"dbApiTeste_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    public ServiceProvider ServiceProvider { get; private set; }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
