using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using MyWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<UserDbContext>(option => 
//     option.UseMySql("Server=localhost;Port=3306;Database=Users;User=root;Password=password;", new MySqlServerVersion(new Version(8, 0, 29))));
// 
// builder.Services.AddDbContext<UserDbContext>(options =>
//     options.UseMySql("Server=assignmentDB;Port=3306;Database=Users;User=root;Password=password;", new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySql("Server=13.237.137.147;Port=3306;Database=Users;User=tnt;Password=tnt@odds;", new MySqlServerVersion(new Version(8, 0, 29)),
     mySqlOptions =>
            {
                mySqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            }
    ));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

