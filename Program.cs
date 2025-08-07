using Abarrotes.BaseDedatos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<AbarrotesReyesContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors();
// app.UseHttpsRedirection(); comentado
app.UseAuthorization();
app.MapControllers();
app.Run();

// Configure the HTTP request pipeline.

// app.UseHttpsRedirection(); comentado

app.Run();

