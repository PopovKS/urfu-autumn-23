using MassTransit;
using Microsoft.EntityFrameworkCore;
using Urfu23.Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebApplicationDbContext>(optionsBuilder =>
{
    var dbConnection = builder.Configuration.GetConnectionString("WebApplication");
    optionsBuilder.UseNpgsql(dbConnection);
});

builder.Services.AddMassTransit(x =>
{
    //x.AddConsumer<SomeConsumer>();
                
    x.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));
                    
        configurator.ConfigureEndpoints(context);
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();



