using CarMaintenance.Api.Data;
using CarMaintenance.Api.Enterprise;
using CarMaintenance.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

// Dependency Injection for EntityDbContext and ECs
builder.Services.AddDbContext<EntityDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AuthService
builder.Services.AddScoped<IAuthService, AuthenticationService>();

// Register Enterprise Components
builder.Services.AddScoped<UserEc>();
builder.Services.AddScoped<CarEc>();
builder.Services.AddScoped<MaintenanceItemEc>();

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

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

// Add authentication middleware - this line is crucial!
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();