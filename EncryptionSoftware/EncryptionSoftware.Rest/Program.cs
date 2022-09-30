using EncryptionSoftware.Application.FraseEncriptar;
using EncryptionSoftware.Application.Product;
using EncryptionSoftware.Persistence;
using EncryptionSoftware.Rest.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

const string myCors = "MyCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
var connectionString = builder.Configuration.GetConnectionString("HerokuConnection");
builder.Services.AddDbContext<EncryptionSoftwareContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myCors, corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        corsPolicyBuilder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(typeof(GetProducts.Handler).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePhrase>();

var app = builder.Build();

app.UseMiddleware<MiddlewareErrorHandler>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();