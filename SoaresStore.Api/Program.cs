using Microsoft.EntityFrameworkCore;
using SoaresStore.Infrastructure.Data;
using SoaresStore.Application;
using MediatR;
using SoaresStore.Domain.Entities;
using SoaresStore.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x =>
    {
        x.MigrationsAssembly("SoaresStore.Api");
    });
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/v1/products", (IProductRepository repository, CancellationToken cancellationToken) =>
{
    var products = repository.GetAllAsync(cancellationToken);

    return Results.Ok(products);
});

app.MapGet("/v1/products/{id}", async (ISender sender, Guid id, CancellationToken cancellationToken) =>
{
    var command = new SoaresStore.Application.UseCases.Products.GetById.Command(id);
    var result = await sender.Send(command, cancellationToken);

    return result.IsSuccess ?
        Results.Ok(result.Value) :
        Results.BadRequest(result.Error);
});

app.MapPost("/v1/products/", (Product product, IProductRepository repository, CancellationToken token) =>
{
    repository.CreateAsync(product, token);

    return Results.Ok(product);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();