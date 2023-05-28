using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    private readonly string databaseName = $"dbApiTeste_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    public ServiceProvider ServiceProvider { get; private set; }

    public DbTeste()
    {
        //var configuration = new ConfigurationBuilder()
        //    .SetBasePath(GetProjectPath())
        //    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: false)
        //    .Build();

        //var connectionString = configuration.GetConnectionString("DevelopmentConnection");
        //var serviceCollection = new ServiceCollection();

        //serviceCollection.AddDbContext<MyContext>(o =>
        //    o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
        //    ServiceLifetime.Transient
        //);

        var serviceCollection = new ServiceCollection();
        var connectionString = $"Persist Security Info=True;Server=127.0.0.1;Database={databaseName};User=root;Password=1234";
        serviceCollection.AddDbContext<MyContext>(o =>
            o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
            ServiceLifetime.Transient
        );


        ServiceProvider = serviceCollection.BuildServiceProvider();

        using var context = ServiceProvider.GetService<MyContext>();
        context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        using var context = ServiceProvider.GetService<MyContext>();
        context.Database.EnsureDeleted();
    }

    //private static string GetProjectPath()
    //{
    //    var currentDirectory = Directory.GetCurrentDirectory();
    //    var solutionDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName;

    //    if (solutionDirectory != null)
    //    {
    //        var appPath = Path.Combine(solutionDirectory, "../../src/Api.Application");
    //        if (Directory.Exists(appPath))
    //            return appPath;
    //    }

    //    throw new ApplicationException("Unable to locate the project root directory.");
    //}
}




//connectionString.Replace("{databaseName}", databaseName), ServerVersion.AutoDetect(connectionString)