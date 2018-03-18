# Hello EF Core 2.1

1. Create an ASP.NET Core 2.1 Web API project in Visual Studio 2017 version 15.7 or greater.
2. Add NuGet Package: Microsoft.EntityFrameworkCore.SqlServer.
3. Add a `Product` class.

    ```csharp
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
    ```

4. Add a `TestDbContext` class.

    ```csharp
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }    
    ```

5. Add a connection string to appSettings.json.

    ```json
    "ConnectionStrings": {
    "TestDbContext": "Data Source=(localdb)\\MSSQLLocalDB;initial catalog=HelloEf21;Integrated Security=True; MultipleActiveResultSets=True"
    }
    ```

6. Update the `Startup.ConfigureServices` method.

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
            .AddJsonOptions(options =>
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.All)
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        var connectionString = Configuration.GetConnectionString(nameof(TestDbContext));
        services.AddDbContext<TestDbContext>(options => options.UseSqlServer(connectionString));
    }
    ```

7. Install the dotnet-ef tools

    ```
    dotnet install tool -g Microsoft.EntityFrameworkCore.Tools.DotNet --version 2.1.0-preview1-final
    ```

8. Add a migration and update the database.

    ```
    dotnet ef migrations add initial
    dotnet database update
    ```

9. Add a customizable razor templates

    ```
    dotnet new -i "AspNetCore.WebApi.Templates::1.0.0-*"
    dotnet new webapi-templates
    ```
