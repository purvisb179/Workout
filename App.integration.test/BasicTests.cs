using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Data;
using App.Data.Repositories;
using App.Enum;
using App.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace App.integration.test;

public class BasicTests 
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public BasicTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        var client = _factory.CreateClient();
        
        var response = await client.GetAsync(url);
        
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("text/plain; charset=utf-8", 
            response.Content.Headers.ContentType?.ToString());
    }
    
    [Fact]
    public async Task TestBaseRepository()
    {
        using var scope = _factory.Services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var baseRepository = scopedServices.GetService<BaseRepository>();
        var expected = new WorkoutModel()
        {
            Id = Guid.NewGuid(),
            Name = "test",
            WorkoutMuscle = new List<Muscle>{Muscle.Abdominals}
        };

        await baseRepository.Set<WorkoutModel, Workout>(expected);

        var actual = await baseRepository.Get<Workout, WorkoutModel>(expected.Id);
        
        Assert.Equal(expected.Id, actual.Id);
    }
}