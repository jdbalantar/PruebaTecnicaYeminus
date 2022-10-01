using EncryptionSoftware.Application.FraseEncriptar;
using EncryptionSoftware.Application.Product;
using EncryptionSoftware.Application.UtilImplementation;
using EncryptionSoftware.Helpers;
using EncryptionSoftware.Persistence;
using EncryptionSoftware.Rest.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200/");
            policy.AllowAnyOrigin();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
var connectionString = builder.Configuration.GetConnectionString("HerokuConnection");
builder.Services.AddDbContext<EncryptionSoftwareContext>(options => options.UseNpgsql(connectionString));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(typeof(GetProducts.Handler).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePhrase>();
builder.Services.AddScoped<IUtil, Util>();
var app = builder.Build();

app.UseMiddleware<MiddlewareErrorHandler>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();