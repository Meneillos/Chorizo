using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Chorizo.Data;
using Chorizo.Interfaces;
using Chorizo.Middleware;
using Chorizo.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<RequestFrom>();
builder.Services.AddScoped<ValidateToken>();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<IPerson, PersonService>();
builder.Services.AddScoped<ISubject, SubjectService>();
builder.Services.AddScoped<IEnrollment, EnrollmentService>();
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AllowNullCollections = true;
    mc.AddProfile(new MapperService());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseMiddleware<CustomMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapControllers();

app.Run();
