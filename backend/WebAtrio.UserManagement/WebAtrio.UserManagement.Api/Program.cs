using Microsoft.EntityFrameworkCore;
using WebAtrio.UserManagement.Business;
using WebAtrio.UserManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS support (to enable the local Angular client to call the API)
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var configuration = builder.Configuration;
builder.Services.AddDbContext<UMDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("UserDatabase")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use the CORS middleware
app.UseCors("DevelopmentPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
