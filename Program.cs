using MinimalApi.Data;
using MinimalApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/clientes", (AppDbContext context) =>
{
    var clientes = context.Clientes.ToList();
    return Results.Ok(clientes);
});

app.MapPost("/clientes", (AppDbContext context, CreateClienteViewModel model) =>
{
    var cliente = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    context.Clientes.Add(cliente);
    context.SaveChanges();

    return Results.Created($"/clientes/{cliente.Id}", cliente);

});

app.UseSwaggerUI();

app.Run();


