using Forum_DAL.Repositories;
using Forum_DAL.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
//builder.Configuration.AddJsonFile("appsetings.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile($"appsetings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


// Connection/Transaction for ADO.NET/DAPPER database
builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("MSSQLConnection")));
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});
//Connection for EF database + DbContext
/*builder.Services.AddDbContext<MyEventsDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString);
});*/
// Dependendency Injection for Repositories/UOW from ADO.NET DAL

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepisotory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Dependendency Injection for Repositories/UOW from EF DAL



var app = builder.Build();


//////////////////////////////////////////
// MIDDLEWARE - йнмбе╙п напнайх гюохрс
// Configure the HTTP request pipeline.
//////////////////////////////////////////


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
