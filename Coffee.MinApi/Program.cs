using Microsoft.EntityFrameworkCore;
using Coffee.MinApi;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// var connectionString = builder.Configuration.GetConnectionString("Orders") ?? "Data Source=Orders.db";
var connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=CoffeeAppDb";

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSqlServer<OrderDbContext>(connectionString);
//builder.Services.AddSqlite<OrderDbContext>(connectionString);


builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", builder =>
    {
        builder.AllowAnyOrigin();
    });
});

var app = builder.Build();

//await CreateDb(app.Services, app.Logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.MapGet("/orders/{id}", (int id, IOrderService orderService) =>
{
    var order = orderService.GetOrderById(id);

    if (order == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(order);
})
.WithName("Get order by id");

app.MapGet("/orders", (IOrderService orderService) =>
{
    return Results.Ok(orderService.GetOrders());
})
.WithName("Get orders");

app.MapPost("/orders", (Order newOrder, IOrderService orderService) =>
{
    var createdOrder = orderService.AddOrder(newOrder);

    return Results.Created($"/orders/{createdOrder.Id}", createdOrder);
})
.WithName("Add order");

app.MapPut("/orders/{id}", (int id, Order updatedOrder, IOrderService orderService) =>
{
    orderService.UpdateOrder(id, updatedOrder);

    return Results.NoContent();
})
.WithName("Update Order");

app.MapDelete("/orders/{id}", (int id, IOrderService orderService) =>
{
    orderService.DeleteOrder(id);

    return Results.Ok();
})
.WithName("Delete order");

app.Run();

//async Task CreateDb(IServiceProvider services, ILogger logger)
//{
//    using var db = services.CreateScope().ServiceProvider.GetRequiredService<OrderDbContext>();
//    await db.Database.MigrateAsync();
//}