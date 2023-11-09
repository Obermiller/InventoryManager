using System.Text;
using InventoryManager.Data.Repositories.Characters;
using InventoryManager.Data.Repositories.Characters.Contracts;
using InventoryManager.Data.Repositories.Inventories;
using InventoryManager.Data.Repositories.Inventories.Contracts;
using InventoryManager.Data.Repositories.Items;
using InventoryManager.Data.Repositories.Items.Contracts;
using InventoryManager.Logic.Characters;
using InventoryManager.Logic.Characters.Contracts;
using InventoryManager.Logic.Inventories;
using InventoryManager.Logic.Inventories.Contracts;
using InventoryManager.Logic.Items;
using InventoryManager.Logic.Items.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddSingleton<ICharacterLogic, CharacterLogic>();
builder.Services.AddSingleton<ICharacterRepository, CharacterRepository>();
builder.Services.AddSingleton<IInventoryLogic, InventoryLogic>();
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IItemLogic, ItemLogic>();
builder.Services.AddSingleton<IItemRepository, ItemRepository>();

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(bearer =>
{
    bearer.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
