using App.Extensions;
using AspNetCoreRateLimit;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiServices();
builder.Services.ConfigureCors();
builder.Services.ConfigureRateLimiting();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*DbContext Configuration
builder.Services.AddDbContext<ApiContext>(opts => {
    string connection = builder.Configuration.GetConnectionString("ConnectionMysql") ?? throw new Exception("Fatal Error: cannot connect to database");

    opts.UseMySql(connection, ServerVersion.AutoDetect(connection));
});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

//app.UseRateLimiter();
app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
