using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaStore.DB;


var builder = WebApplication.CreateBuilder(args);
//configure swagger for builder
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Making the Pizzas you love",
        Version = "v1"
    });
});
var app = builder.Build();
//configure swagger for app
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

app.MapGet("/", () => "Hello World!");

//GET: Fetch a resource
app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapGet("/pizzas", () => PizzaDB.GetPizzas());

//POST: Create a resource
app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));

//PUT: Update a resource
app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));

//DELETE: Remove a resource
app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));

app.Run();
