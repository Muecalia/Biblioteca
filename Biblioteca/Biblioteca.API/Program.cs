using Biblioteca.Application.Configs;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Configs;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection String
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaConnection")));

builder.Services.AddIdentity<User, IdentityRole>(optinos => 
{
    optinos.Password.RequiredLength = 4;
    optinos.Password.RequireDigit = false;
    optinos.Password.RequireLowercase = true;
    optinos.Password.RequireUppercase = true;
    optinos.Password.RequireNonAlphanumeric = false;

    optinos.User.RequireUniqueEmail = true;
    //optinos.SignIn.RequireConfirmedPhoneNumber = true;
})
.AddEntityFrameworkStores<BibliotecaContext>()
.AddDefaultTokenProviders();

//Injecção de Dependência
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

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
