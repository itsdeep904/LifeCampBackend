using LifeCamp.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register CORS policy before building the app

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React dev server
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register the JwtTokenService
builder.Services.AddSingleton<JwtTokenService>(); // Or AddScoped if it's a scoped service
// Add services to the container.

builder.Services.AddControllers();
// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = "https://localhost:7184",
            ValidAudience = "myapi",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LifeCampWebsiteByDeep_secretkey_B58PQ"))
        };
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
