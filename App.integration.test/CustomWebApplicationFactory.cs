using System;
using System.Linq;
using App.Data;
using App.Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.integration.test;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{ 
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();
        var connectionString = config.GetConnectionString("Application");
        builder.UseConfiguration(config);
        builder.UseEnvironment("Development");
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<AppDbContext>));

            if (descriptor != null) services.Remove(descriptor);

            services.AddDbContext<AppDbContext>(options =>
            {
                if (connectionString != null)
                {
                    options.UseMySql(connectionString,  ServerVersion.AutoDetect(connectionString));
                }
                else
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                }
            });
            services.AddTransient<BaseRepository>();
        });
    }
}