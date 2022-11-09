using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    { 
        options.AddDefaultPolicy(
            builder =>
            {
                builder.WithOrigins("http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            }
        );
    }
);

// Add services to the container.

/// Database Connection
builder.Services.AddDbContext<AppointmentDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DatabaseConnection")
    )
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

// Custom middleware for exceptions
app.UseCustomExceptionMiddleware();

app.MapControllers();

app.Run();
