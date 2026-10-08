using Biblioteca_Jogos;
using Biblioteca_Usuario;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter());
});
builder.Services.AddSwaggerGen();

   
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<MyContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddScoped<ServiceJogo>();
builder.Services.AddScoped<RepositoryJogo>();
builder.Services.AddScoped<ServiceUsuario>();
builder.Services.AddScoped<RepositoryUsuario>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();   
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();


app.MapControllers();

app.Run();
