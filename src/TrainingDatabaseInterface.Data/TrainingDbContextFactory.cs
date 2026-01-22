using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TrainingDatabaseInterface.Data;

public class TrainingDbContextFactory : IDesignTimeDbContextFactory<TrainingDbContext>
{
    public TrainingDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile(Path.Combine("..", "TrainingDatabaseInterface.App", "appsettings.json"), optional: true)
            .AddEnvironmentVariables();

        var configuration = configBuilder.Build();
        var connectionString = configuration.GetConnectionString("TrainingDatabase")
            ?? "Server=localhost\\SQLEXPRESS;Database=TrainingDatabaseInterface;Trusted_Connection=True;TrustServerCertificate=True;";

        var optionsBuilder = new DbContextOptionsBuilder<TrainingDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new TrainingDbContext(optionsBuilder.Options);
    }
}
