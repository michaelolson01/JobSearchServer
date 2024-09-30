using JobSearchServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "server=localhost;port=3306;database=JobsDatabase;user=root;password=G0l14rd$25";

builder.Services
    .AddDbContext<ApplicationDbContext>(
        options => options
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
        )
    .AddGraphQLServer()
    .AddMutationConventions()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
     // The name of this function changes with the project name.
    .AddJobSearchServerTypes();

builder
    .Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });


var app = builder.Build();

app.UseCors();

app.MapGraphQL();

await app.RunWithGraphQLCommandsAsync(args);
