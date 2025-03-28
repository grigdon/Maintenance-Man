using CarMaintenance.Api.Data;
using CarMaintenance.Api.Enterprise;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder => 
        builder
            .WithOrigins("http://localhost:5173", "http://localhost:5191") 
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection for CarDbContext and CarEC

builder.Services.AddDbContext<CarDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CarEC>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add CORS middleware
app.UseCors("AllowReactApp");

// *** Disabled for development **
// *** This should be re-enabled for launch ***

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();