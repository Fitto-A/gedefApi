using EmailService;
using gedefApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.Configure<FormOptions>(o => {
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GedefDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

//options.WithOrigins("http://localhost:7672", "http://200.32.51.124:7672/API/", "http://gedef.grupoveraz.com.ar:7672")
//.AllowAnyMethod()
//.AllowAnyHeader());

if (app.Environment.IsDevelopment()){
    app.UseCors(options =>
        options.WithOrigins("http://localhost:7672")
    .AllowAnyMethod()
    .AllowAnyHeader());
}else if (app.Environment.IsProduction())
{ 
    app.UseCors(options =>
        options.WithOrigins("http://200.32.51.124:7672/API/", "http://gedef.grupoveraz.com.ar:7672")
    .AllowAnyMethod()
    .AllowAnyHeader());
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
